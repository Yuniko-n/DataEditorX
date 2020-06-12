﻿// ZipStorer, by Jaime Olivares
// Website: zipstorer.codeplex.com
// Version: 2.35 (March 14, 2010)

using System.Collections.Generic;
using System.Text;

namespace System.IO.Compression
{
    /// <summary>
    /// Unique class for compression/decompression file. Represents a Zip file.
    /// </summary>
    public class ZipStorer : IDisposable
    {
        /// <summary>
        /// Compression method enumeration
        /// </summary>
        public enum Compression : ushort
        {
            /// <summary>Uncompressed storage</summary> 
            Store = 0,
            /// <summary>Deflate compression method</summary>
            Deflate = 8
        }

        #region ZipFileEntry
        /// <summary>
        /// Represents an entry in Zip file directory
        /// </summary>
        public struct ZipFileEntry
        {
            /// <summary>Compression method</summary>
            public Compression Method;
            /// <summary>Full path and filename as stored in Zip</summary>
            public string FilenameInZip;
            /// <summary>Original file size</summary>
            public uint FileSize;
            /// <summary>Compressed file size</summary>
            public uint CompressedSize;
            /// <summary>Offset of header information inside Zip storage</summary>
            public uint HeaderOffset;
            /// <summary>Offset of file inside Zip storage</summary>
            public uint FileOffset;
            /// <summary>Size of header information</summary>
            public uint HeaderSize;
            /// <summary>32-bit checksum of entire file</summary>
            public uint Crc32;
            /// <summary>Last modification time of file</summary>
            public DateTime ModifyTime;
            /// <summary>User comment for file</summary>
            public string Comment;
            /// <summary>True if UTF8 encoding for filename and comments, false if default (CP 437)</summary>
            public bool EncodeUTF8;

            /// <summary>Overriden method</summary>
            /// <returns>Filename in Zip</returns>
            public override string ToString()
            {
                return this.FilenameInZip;
            }
        }
        #endregion

        #region Public fields
        /// <summary>True if UTF8 encoding for filename and comments, false if default (CP 437)</summary>
        public bool EncodeUTF8 = true;
        /// <summary>Force deflate algotithm even if it inflates the stored file. Off by default.</summary>
        public bool ForceDeflating = false;
        #endregion

        #region Private fields
        // List of files to store
        private readonly List<ZipFileEntry> files = new List<ZipFileEntry>();
        // Filename of storage file
        private string fileName;
        // Stream object of storage file
        private Stream zipFileStream;
        // General comment
        private string comment = "";
        // Central dir image
        private byte[] centralDirImage = null;
        // Existing files in zip
        private ushort existingFiles = 0;
        // File access for Open method
        private FileAccess access;
        // Static CRC32 Table
        private static readonly uint[] _crcTable = null;
        // Default filename encoder
        private static readonly Encoding _defaultEncoding = Encoding.GetEncoding(437);
        #endregion

        #region Public methods
        // Static constructor. Just invoked once in order to create the CRC32 lookup table.
        static ZipStorer()
        {
            // Generate CRC32 table
            _crcTable = new uint[256];
            for (int i = 0; i < _crcTable.Length; i++)
            {
                uint c = (uint)i;
                for (int j = 0; j < 8; j++)
                {
                    if ((c & 1) != 0)
                    {
                        c = 3988292384 ^ (c >> 1);
                    }
                    else
                    {
                        c >>= 1;
                    }
                }
                _crcTable[i] = c;
            }
        }
        /// <summary>
        /// Method to create a new storage file
        /// </summary>
        /// <param name="_filename">Full path of Zip file to create</param>
        /// <param name="_comment">General comment for Zip file</param>
        /// <returns>A valid ZipStorer object</returns>
        public static ZipStorer Create(string _filename, string _comment)
        {
            Stream stream = new FileStream(_filename, FileMode.Create, FileAccess.ReadWrite);

            ZipStorer zip = Create(stream, _comment);
            zip.comment = _comment;
            zip.fileName = _filename;

            return zip;
        }
        /// <summary>
        /// Method to create a new zip storage in a stream
        /// </summary>
        /// <param name="_stream"></param>
        /// <param name="_comment"></param>
        /// <returns>A valid ZipStorer object</returns>
        public static ZipStorer Create(Stream _stream, string _comment)
        {
            ZipStorer zip = new ZipStorer
            {
                comment = _comment,
                zipFileStream = _stream,
                access = FileAccess.Write
            };

            return zip;
        }
        /// <summary>
        /// Method to open an existing storage file
        /// </summary>
        /// <param name="_filename">Full path of Zip file to open</param>
        /// <param name="_access">File access mode as used in FileStream constructor</param>
        /// <returns>A valid ZipStorer object</returns>
        public static ZipStorer Open(string _filename, FileAccess _access)
        {
            Stream stream = new FileStream(_filename, FileMode.Open, _access == FileAccess.Read ? FileAccess.Read : FileAccess.ReadWrite);

            ZipStorer zip = Open(stream, _access);
            zip.fileName = _filename;

            return zip;
        }
        /// <summary>
        /// Method to open an existing storage from stream
        /// </summary>
        /// <param name="_stream">Already opened stream with zip contents</param>
        /// <param name="_access">File access mode for stream operations</param>
        /// <returns>A valid ZipStorer object</returns>
        public static ZipStorer Open(Stream _stream, FileAccess _access)
        {
            if (!_stream.CanSeek && _access != FileAccess.Read)
            {
                throw new InvalidOperationException("Stream cannot seek");
            }

            ZipStorer zip = new ZipStorer
            {
                //zip.FileName = _filename;
                zipFileStream = _stream,
                access = _access
            };

            if (zip.ReadFileInfo())
            {
                return zip;
            }

            throw new InvalidDataException();
        }
        /// <summary>
        /// Add full contents of a file into the Zip storage
        /// </summary>
        /// <param name="_method">Compression method</param>
        /// <param name="_pathname">Full path of file to add to Zip storage</param>
        /// <param name="_filenameInZip">Filename and path as desired in Zip directory</param>
        /// <param name="_comment">Comment for stored file</param>        
        public void AddFile(string _pathname, string _filenameInZip, string _comment)
        {
            Compression _method=Compression.Deflate;
            if (this.access == FileAccess.Read)
            {
                throw new InvalidOperationException("Writing is not alowed");
            }

            FileStream stream = new FileStream(_pathname, FileMode.Open, FileAccess.Read);
            this.AddStream(_method, _filenameInZip, stream, File.GetLastWriteTime(_pathname), _comment);
            stream.Close();
        }
        /// <summary>
        /// Add full contents of a file into the Zip storage
        /// </summary>
        /// <param name="_method">Compression method</param>
        /// <param name="_pathname">Full path of file to add to Zip storage</param>
        /// <param name="_filenameInZip">Filename and path as desired in Zip directory</param>
        /// <param name="_comment">Comment for stored file</param>        
        public void AddFile(Compression _method, string _pathname, string _filenameInZip, string _comment)
        {
            if (this.access == FileAccess.Read)
            {
                throw new InvalidOperationException("Writing is not alowed");
            }

            FileStream stream = new FileStream(_pathname, FileMode.Open, FileAccess.Read);
            this.AddStream(_method, _filenameInZip, stream, File.GetLastWriteTime(_pathname), _comment);
            stream.Close();
        }
        /// <summary>
        /// Add full contents of a stream into the Zip storage
        /// </summary>
        /// <param name="_method">Compression method</param>
        /// <param name="_filenameInZip">Filename and path as desired in Zip directory</param>
        /// <param name="_source">Stream object containing the data to store in Zip</param>
        /// <param name="_modTime">Modification time of the data to store</param>
        /// <param name="_comment">Comment for stored file</param>
        public void AddStream(Compression _method, string _filenameInZip, Stream _source, DateTime _modTime, string _comment)
        {
            if (this.access == FileAccess.Read)
            {
                throw new InvalidOperationException("Writing is not alowed");
            }

            if (this.files.Count == 0)
            {
            }
            else
            {
                ZipFileEntry last = this.files[this.files.Count-1];
                _ = last.HeaderOffset + last.HeaderSize;
            }

            // Prepare the fileinfo
            ZipFileEntry zfe = new ZipFileEntry
            {
                Method = _method,
                EncodeUTF8 = this.EncodeUTF8,
                FilenameInZip = this.NormalizedFilename(_filenameInZip),
                Comment = (_comment ?? ""),

                // Even though we write the header now, it will have to be rewritten, since we don't know compressed size or crc.
                Crc32 = 0,  // to be updated later
                HeaderOffset = (uint)this.zipFileStream.Position,  // offset within file of the start of this local record
                ModifyTime = _modTime
            };

            // Write local header
            this.WriteLocalHeader(ref zfe);
            zfe.FileOffset = (uint)this.zipFileStream.Position;

            // Write file to zip (store)
            this.Store(ref zfe, _source);
            _source.Close();

            this.UpdateCrcAndSizes(ref zfe);

            this.files.Add(zfe);
        }
        /// <summary>
        /// Updates central directory (if pertinent) and close the Zip storage
        /// </summary>
        /// <remarks>This is a required step, unless automatic dispose is used</remarks>
        public void Close()
        {
            if (this.access != FileAccess.Read)
            {
                uint centralOffset = (uint)this.zipFileStream.Position;
                uint centralSize = 0;

                if (this.centralDirImage != null)
                {
                    this.zipFileStream.Write(this.centralDirImage, 0, this.centralDirImage.Length);
                }

                for (int i = 0; i < this.files.Count; i++)
                {
                    long pos = this.zipFileStream.Position;
                    this.WriteCentralDirRecord(this.files[i]);
                    centralSize += (uint)(this.zipFileStream.Position - pos);
                }

                if (this.centralDirImage != null)
                {
                    this.WriteEndRecord(centralSize + (uint)this.centralDirImage.Length, centralOffset);
                }
                else
                {
                    this.WriteEndRecord(centralSize, centralOffset);
                }
            }

            if (this.zipFileStream != null)
            {
                this.zipFileStream.Flush();
                this.zipFileStream.Dispose();
                this.zipFileStream = null;
            }
        }
        /// <summary>
        /// Read all the file records in the central directory 
        /// </summary>
        /// <returns>List of all entries in directory</returns>
        public List<ZipFileEntry> ReadCentralDir()
        {
            if (this.centralDirImage == null)
            {
                throw new InvalidOperationException("Central directory currently does not exist");
            }

            List<ZipFileEntry> result = new List<ZipFileEntry>();

            for (int pointer = 0; pointer < this.centralDirImage.Length;)
            {
                uint signature = BitConverter.ToUInt32(this.centralDirImage, pointer);
                if (signature != 0x02014b50)
                {
                    break;
                }

                bool encodeUTF8 = (BitConverter.ToUInt16(this.centralDirImage, pointer + 8) & 0x0800) != 0;
                ushort method = BitConverter.ToUInt16(this.centralDirImage, pointer + 10);
                uint modifyTime = BitConverter.ToUInt32(this.centralDirImage, pointer + 12);
                uint crc32 = BitConverter.ToUInt32(this.centralDirImage, pointer + 16);
                uint comprSize = BitConverter.ToUInt32(this.centralDirImage, pointer + 20);
                uint fileSize = BitConverter.ToUInt32(this.centralDirImage, pointer + 24);
                ushort filenameSize = BitConverter.ToUInt16(this.centralDirImage, pointer + 28);
                ushort extraSize = BitConverter.ToUInt16(this.centralDirImage, pointer + 30);
                ushort commentSize = BitConverter.ToUInt16(this.centralDirImage, pointer + 32);
                uint headerOffset = BitConverter.ToUInt32(this.centralDirImage, pointer + 42);
                uint headerSize = (uint)( 46 + filenameSize + extraSize + commentSize);

                Encoding encoder = encodeUTF8 ? Encoding.UTF8 : _defaultEncoding;

                ZipFileEntry zfe = new ZipFileEntry
                {
                    Method = (Compression)method,
                    FilenameInZip = encoder.GetString(this.centralDirImage, pointer + 46, filenameSize),
                    FileOffset = this.GetFileOffset(headerOffset),
                    FileSize = fileSize,
                    CompressedSize = comprSize,
                    HeaderOffset = headerOffset,
                    HeaderSize = headerSize,
                    Crc32 = crc32,
                    ModifyTime = this.DosTimeToDateTime(modifyTime)
                };
                if (commentSize > 0)
                {
                    zfe.Comment = encoder.GetString(this.centralDirImage, pointer + 46 + filenameSize + extraSize, commentSize);
                }

                result.Add(zfe);
                pointer += (46 + filenameSize + extraSize + commentSize);
            }

            return result;
        }
        /// <summary>
        /// Copy the contents of a stored file into a physical file
        /// </summary>
        /// <param name="_zfe">Entry information of file to extract</param>
        /// <param name="_filename">Name of file to store uncompressed data</param>
        /// <returns>True if success, false if not.</returns>
        /// <remarks>Unique compression methods are Store and Deflate</remarks>
        public bool ExtractFile(ZipFileEntry _zfe, string _filename)
        {
            // Make sure the parent directory exist
            string path = Path.GetDirectoryName(_filename);

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            // Check it is directory. If so, do nothing
            if (Directory.Exists(_filename))
            {
                return true;
            }

            Stream output = new FileStream(_filename, FileMode.Create, FileAccess.Write);
            bool result = this.ExtractFile(_zfe, output);
            if (result)
            {
                output.Close();
            }

            File.SetCreationTime(_filename, _zfe.ModifyTime);
            File.SetLastWriteTime(_filename, _zfe.ModifyTime);

            return result;
        }
        /// <summary>
        /// Copy the contents of a stored file into an opened stream
        /// </summary>
        /// <param name="_zfe">Entry information of file to extract</param>
        /// <param name="_stream">Stream to store the uncompressed data</param>
        /// <returns>True if success, false if not.</returns>
        /// <remarks>Unique compression methods are Store and Deflate</remarks>
        public bool ExtractFile(ZipFileEntry _zfe, Stream _stream)
        {
            if (!_stream.CanWrite)
            {
                throw new InvalidOperationException("Stream cannot be written");
            }

            // check signature
            byte[] signature = new byte[4];
            this.zipFileStream.Seek(_zfe.HeaderOffset, SeekOrigin.Begin);
            this.zipFileStream.Read(signature, 0, 4);
            if (BitConverter.ToUInt32(signature, 0) != 0x04034b50)
            {
                return false;
            }

            // Select input stream for inflating or just reading
            Stream inStream;
            if (_zfe.Method == Compression.Store)
            {
                inStream = this.zipFileStream;
            }
            else if (_zfe.Method == Compression.Deflate)
            {
                inStream = new DeflateStream(this.zipFileStream, CompressionMode.Decompress, true);
            }
            else
            {
                return false;
            }

            // Buffered copy
            byte[] buffer = new byte[16384];
            this.zipFileStream.Seek(_zfe.FileOffset, SeekOrigin.Begin);
            uint bytesPending = _zfe.FileSize;
            while (bytesPending > 0)
            {
                int bytesRead = inStream.Read(buffer, 0, (int)Math.Min(bytesPending, buffer.Length));
                _stream.Write(buffer, 0, bytesRead);
                bytesPending -= (uint)bytesRead;
            }
            _stream.Flush();

            if (_zfe.Method == Compression.Deflate)
            {
                inStream.Dispose();
            }

            return true;
        }
        /// <summary>
        /// Removes one of many files in storage. It creates a new Zip file.
        /// </summary>
        /// <param name="_zip">Reference to the current Zip object</param>
        /// <param name="_zfes">List of Entries to remove from storage</param>
        /// <returns>True if success, false if not</returns>
        /// <remarks>This method only works for storage of type FileStream</remarks>
        public static bool RemoveEntries(ref ZipStorer _zip, List<ZipFileEntry> _zfes)
        {
            if (!(_zip.zipFileStream is FileStream))
            {
                throw new InvalidOperationException("RemoveEntries is allowed just over streams of type FileStream");
            }


            //Get full list of entries
            List<ZipFileEntry> fullList = _zip.ReadCentralDir();

            //In order to delete we need to create a copy of the zip file excluding the selected items
            string tempZipName = Path.GetTempFileName();
            string tempEntryName = Path.GetTempFileName();

            try
            {
                ZipStorer tempZip = Create(tempZipName, string.Empty);

                foreach (ZipFileEntry zfe in fullList)
                {
                    if (!_zfes.Contains(zfe))
                    {
                        if (_zip.ExtractFile(zfe, tempEntryName))
                        {
                            tempZip.AddFile(zfe.Method, tempEntryName, zfe.FilenameInZip, zfe.Comment);
                        }
                    }
                }
                _zip.Close();
                tempZip.Close();

                File.Delete(_zip.fileName);
                File.Move(tempZipName, _zip.fileName);

                _zip = Open(_zip.fileName, _zip.access);
            }
            catch
            {
                return false;
            }
            finally
            {
                if (File.Exists(tempZipName))
                {
                    File.Delete(tempZipName);
                }

                if (File.Exists(tempEntryName))
                {
                    File.Delete(tempEntryName);
                }
            }
            return true;
        }
        #endregion

        #region Private methods
        // Calculate the file offset by reading the corresponding local header
        private uint GetFileOffset(uint _headerOffset)
        {
            byte[] buffer = new byte[2];

            this.zipFileStream.Seek(_headerOffset + 26, SeekOrigin.Begin);
            this.zipFileStream.Read(buffer, 0, 2);
            ushort filenameSize = BitConverter.ToUInt16(buffer, 0);
            this.zipFileStream.Read(buffer, 0, 2);
            ushort extraSize = BitConverter.ToUInt16(buffer, 0);

            return (uint)(30 + filenameSize + extraSize + _headerOffset);
        }
        /* Local file header:
            local file header signature     4 bytes  (0x04034b50)
            version needed to extract       2 bytes
            general purpose bit flag        2 bytes
            compression method              2 bytes
            last mod file time              2 bytes
            last mod file date              2 bytes
            crc-32                          4 bytes
            compressed size                 4 bytes
            uncompressed size               4 bytes
            filename length                 2 bytes
            extra field length              2 bytes

            filename (variable size)
            extra field (variable size)
        */
        private void WriteLocalHeader(ref ZipFileEntry _zfe)
        {
            long pos = this.zipFileStream.Position;
            Encoding encoder = _zfe.EncodeUTF8 ? Encoding.UTF8 : _defaultEncoding;
            byte[] encodedFilename = encoder.GetBytes(_zfe.FilenameInZip);

            this.zipFileStream.Write(new byte[] { 80, 75, 3, 4, 20, 0 }, 0, 6); // No extra header
            this.zipFileStream.Write(BitConverter.GetBytes((ushort)(_zfe.EncodeUTF8 ? 0x0800 : 0)), 0, 2); // filename and comment encoding 
            this.zipFileStream.Write(BitConverter.GetBytes((ushort)_zfe.Method), 0, 2);  // zipping method
            this.zipFileStream.Write(BitConverter.GetBytes(this.DateTimeToDosTime(_zfe.ModifyTime)), 0, 4); // zipping date and time
            this.zipFileStream.Write(new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, 0, 12); // unused CRC, un/compressed size, updated later
            this.zipFileStream.Write(BitConverter.GetBytes((ushort)encodedFilename.Length), 0, 2); // filename length
            this.zipFileStream.Write(BitConverter.GetBytes((ushort)0), 0, 2); // extra length

            this.zipFileStream.Write(encodedFilename, 0, encodedFilename.Length);
            _zfe.HeaderSize = (uint)(this.zipFileStream.Position - pos);
        }
        /* Central directory's File header:
            central file header signature   4 bytes  (0x02014b50)
            version made by                 2 bytes
            version needed to extract       2 bytes
            general purpose bit flag        2 bytes
            compression method              2 bytes
            last mod file time              2 bytes
            last mod file date              2 bytes
            crc-32                          4 bytes
            compressed size                 4 bytes
            uncompressed size               4 bytes
            filename length                 2 bytes
            extra field length              2 bytes
            file comment length             2 bytes
            disk number start               2 bytes
            internal file attributes        2 bytes
            external file attributes        4 bytes
            relative offset of local header 4 bytes

            filename (variable size)
            extra field (variable size)
            file comment (variable size)
        */
        private void WriteCentralDirRecord(ZipFileEntry _zfe)
        {
            Encoding encoder = _zfe.EncodeUTF8 ? Encoding.UTF8 : _defaultEncoding;
            byte[] encodedFilename = encoder.GetBytes(_zfe.FilenameInZip);
            byte[] encodedComment = encoder.GetBytes(_zfe.Comment);

            this.zipFileStream.Write(new byte[] { 80, 75, 1, 2, 23, 0xB, 20, 0 }, 0, 8);
            this.zipFileStream.Write(BitConverter.GetBytes((ushort)(_zfe.EncodeUTF8 ? 0x0800 : 0)), 0, 2); // filename and comment encoding 
            this.zipFileStream.Write(BitConverter.GetBytes((ushort)_zfe.Method), 0, 2);  // zipping method
            this.zipFileStream.Write(BitConverter.GetBytes(this.DateTimeToDosTime(_zfe.ModifyTime)), 0, 4);  // zipping date and time
            this.zipFileStream.Write(BitConverter.GetBytes(_zfe.Crc32), 0, 4); // file CRC
            this.zipFileStream.Write(BitConverter.GetBytes(_zfe.CompressedSize), 0, 4); // compressed file size
            this.zipFileStream.Write(BitConverter.GetBytes(_zfe.FileSize), 0, 4); // uncompressed file size
            this.zipFileStream.Write(BitConverter.GetBytes((ushort)encodedFilename.Length), 0, 2); // Filename in zip
            this.zipFileStream.Write(BitConverter.GetBytes((ushort)0), 0, 2); // extra length
            this.zipFileStream.Write(BitConverter.GetBytes((ushort)encodedComment.Length), 0, 2);

            this.zipFileStream.Write(BitConverter.GetBytes((ushort)0), 0, 2); // disk=0
            this.zipFileStream.Write(BitConverter.GetBytes((ushort)0), 0, 2); // file type: binary
            this.zipFileStream.Write(BitConverter.GetBytes((ushort)0), 0, 2); // Internal file attributes
            this.zipFileStream.Write(BitConverter.GetBytes((ushort)0x8100), 0, 2); // External file attributes (normal/readable)
            this.zipFileStream.Write(BitConverter.GetBytes(_zfe.HeaderOffset), 0, 4);  // Offset of header

            this.zipFileStream.Write(encodedFilename, 0, encodedFilename.Length);
            this.zipFileStream.Write(encodedComment, 0, encodedComment.Length);
        }
        /* End of central dir record:
            end of central dir signature    4 bytes  (0x06054b50)
            number of this disk             2 bytes
            number of the disk with the
            start of the central directory  2 bytes
            total number of entries in
            the central dir on this disk    2 bytes
            total number of entries in
            the central dir                 2 bytes
            size of the central directory   4 bytes
            offset of start of central
            directory with respect to
            the starting disk number        4 bytes
            zipfile comment length          2 bytes
            zipfile comment (variable size)
        */
        private void WriteEndRecord(uint _size, uint _offset)
        {
            Encoding encoder = this.EncodeUTF8 ? Encoding.UTF8 : _defaultEncoding;
            byte[] encodedComment = encoder.GetBytes(this.comment);

            this.zipFileStream.Write(new byte[] { 80, 75, 5, 6, 0, 0, 0, 0 }, 0, 8);
            this.zipFileStream.Write(BitConverter.GetBytes((ushort)this.files.Count + this.existingFiles), 0, 2);
            this.zipFileStream.Write(BitConverter.GetBytes((ushort)this.files.Count + this.existingFiles), 0, 2);
            this.zipFileStream.Write(BitConverter.GetBytes(_size), 0, 4);
            this.zipFileStream.Write(BitConverter.GetBytes(_offset), 0, 4);
            this.zipFileStream.Write(BitConverter.GetBytes((ushort)encodedComment.Length), 0, 2);
            this.zipFileStream.Write(encodedComment, 0, encodedComment.Length);
        }
        // Copies all source file into storage file
        private void Store(ref ZipFileEntry _zfe, Stream _source)
        {
            byte[] buffer = new byte[16384];
            int bytesRead;
            uint totalRead = 0;
            Stream outStream;

            long posStart = this.zipFileStream.Position;
            long sourceStart = _source.Position;

            if (_zfe.Method == Compression.Store)
            {
                outStream = this.zipFileStream;
            }
            else
            {
                outStream = new DeflateStream(this.zipFileStream, CompressionMode.Compress, true);
            }

            _zfe.Crc32 = 0 ^ 0xffffffff;

            do
            {
                bytesRead = _source.Read(buffer, 0, buffer.Length);
                totalRead += (uint)bytesRead;
                if (bytesRead > 0)
                {
                    outStream.Write(buffer, 0, bytesRead);

                    for (uint i = 0; i < bytesRead; i++)
                    {
                        _zfe.Crc32 = _crcTable[(_zfe.Crc32 ^ buffer[i]) & 0xFF] ^ (_zfe.Crc32 >> 8);
                    }
                }
            } while (bytesRead == buffer.Length);
            outStream.Flush();

            if (_zfe.Method == Compression.Deflate)
            {
                outStream.Dispose();
            }

            _zfe.Crc32 ^= 0xffffffff;
            _zfe.FileSize = totalRead;
            _zfe.CompressedSize = (uint)(this.zipFileStream.Position - posStart);

            // Verify for real compression
            if (_zfe.Method == Compression.Deflate && !this.ForceDeflating && _source.CanSeek && _zfe.CompressedSize > _zfe.FileSize)
            {
                // Start operation again with Store algorithm
                _zfe.Method = Compression.Store;
                this.zipFileStream.Position = posStart;
                this.zipFileStream.SetLength(posStart);
                _source.Position = sourceStart;
                this.Store(ref _zfe, _source);
            }
        }
        /* DOS Date and time:
            MS-DOS date. The date is a packed value with the following format. Bits Description 
                0-4 Day of the month (1?1) 
                5-8 Month (1 = January, 2 = February, and so on) 
                9-15 Year offset from 1980 (add 1980 to get actual year) 
            MS-DOS time. The time is a packed value with the following format. Bits Description 
                0-4 Second divided by 2 
                5-10 Minute (0?9) 
                11-15 Hour (0?3 on a 24-hour clock) 
        */
        private uint DateTimeToDosTime(DateTime _dt)
        {
            return (uint)(
                (_dt.Second / 2) | (_dt.Minute << 5) | (_dt.Hour << 11) |
                (_dt.Day << 16) | (_dt.Month << 21) | ((_dt.Year - 1980) << 25));
        }
        private DateTime DosTimeToDateTime(uint _dt)
        {
            return new DateTime(
                (int)(_dt >> 25) + 1980,
                (int)(_dt >> 21) & 15,
                (int)(_dt >> 16) & 31,
                (int)(_dt >> 11) & 31,
                (int)(_dt >> 5) & 63,
                (int)(_dt & 31) * 2);
        }

        /* CRC32 algorithm
          The 'magic number' for the CRC is 0xdebb20e3.  
          The proper CRC pre and post conditioning
          is used, meaning that the CRC register is
          pre-conditioned with all ones (a starting value
          of 0xffffffff) and the value is post-conditioned by
          taking the one's complement of the CRC residual.
          If bit 3 of the general purpose flag is set, this
          field is set to zero in the local header and the correct
          value is put in the data descriptor and in the central
          directory.
        */
        private void UpdateCrcAndSizes(ref ZipFileEntry _zfe)
        {
            long lastPos = this.zipFileStream.Position;  // remember position

            this.zipFileStream.Position = _zfe.HeaderOffset + 8;
            this.zipFileStream.Write(BitConverter.GetBytes((ushort)_zfe.Method), 0, 2);  // zipping method

            this.zipFileStream.Position = _zfe.HeaderOffset + 14;
            this.zipFileStream.Write(BitConverter.GetBytes(_zfe.Crc32), 0, 4);  // Update CRC
            this.zipFileStream.Write(BitConverter.GetBytes(_zfe.CompressedSize), 0, 4);  // Compressed size
            this.zipFileStream.Write(BitConverter.GetBytes(_zfe.FileSize), 0, 4);  // Uncompressed size

            this.zipFileStream.Position = lastPos;  // restore position
        }
        // Replaces backslashes with slashes to store in zip header
        private string NormalizedFilename(string _filename)
        {
            string filename = _filename.Replace('\\', '/');

            int pos = filename.IndexOf(':');
            if (pos >= 0)
            {
                filename = filename.Remove(0, pos + 1);
            }

            return filename.Trim('/');
        }
        // Reads the end-of-central-directory record
        private bool ReadFileInfo()
        {
            if (this.zipFileStream.Length < 22)
            {
                return false;
            }

            try
            {
                this.zipFileStream.Seek(-17, SeekOrigin.End);
                BinaryReader br = new BinaryReader(this.zipFileStream);
                do
                {
                    this.zipFileStream.Seek(-5, SeekOrigin.Current);
                    uint sig = br.ReadUInt32();
                    if (sig == 0x06054b50)
                    {
                        this.zipFileStream.Seek(6, SeekOrigin.Current);

                        ushort entries = br.ReadUInt16();
                        int centralSize = br.ReadInt32();
                        uint centralDirOffset = br.ReadUInt32();
                        ushort commentSize = br.ReadUInt16();

                        // check if comment field is the very last data in file
                        if (this.zipFileStream.Position + commentSize != this.zipFileStream.Length)
                        {
                            return false;
                        }

                        // Copy entire central directory to a memory buffer
                        this.existingFiles = entries;
                        this.centralDirImage = new byte[centralSize];
                        this.zipFileStream.Seek(centralDirOffset, SeekOrigin.Begin);
                        this.zipFileStream.Read(this.centralDirImage, 0, centralSize);

                        // Leave the pointer at the begining of central dir, to append new files
                        this.zipFileStream.Seek(centralDirOffset, SeekOrigin.Begin);
                        return true;
                    }
                } while (this.zipFileStream.Position > 0);
            }
            catch { }

            return false;
        }
        #endregion

        #region IDisposable Members
        /// <summary>
        /// Closes the Zip file stream
        /// </summary>
        public void Dispose()
        {
            this.Close();
        }
        #endregion
    }
}
