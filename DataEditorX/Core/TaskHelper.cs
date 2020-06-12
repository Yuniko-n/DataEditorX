/*
 * 由SharpDevelop创建。
 * 用户： Acer
 * 日期: 2014-10-12
 * 时间: 19:43
 * 
 */
using DataEditorX.Common;
using DataEditorX.Config;
using DataEditorX.Core.Info;
using DataEditorX.Core.Mse;
using DataEditorX.Language;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Windows.Forms;

namespace DataEditorX.Core
{
    /// <summary>
    /// 任务
    /// </summary>
    public class TaskHelper
    {
        #region Member
        /// <summary>
        /// 当前任务
        /// </summary>
        private MyTask nowTask = MyTask.NONE;
        /// <summary>
        /// 上一次任务
        /// </summary>
        private MyTask lastTask = MyTask.NONE;
        /// <summary>
        /// 当前卡片列表
        /// </summary>
        private Card[] cardlist;
        /// <summary>
        /// 当前卡片列表
        /// </summary>
        public Card[] CardList
        {
            get { return this.cardlist; }
        }
        /// <summary>
        /// 任务参数
        /// </summary>
        private string[] mArgs;
        /// <summary>
        /// 图片设置
        /// </summary>
        private readonly ImageSet imgSet;
        /// <summary>
        /// MSE转换
        /// </summary>
        private readonly MseMaker mseHelper;
        /// <summary>
        /// 是否取消
        /// </summary>
        private bool isCancel = false;
        /// <summary>
        /// 是否在运行
        /// </summary>
        private bool isRun = false;
        /// <summary>
        /// 后台工作线程
        /// </summary>
        private readonly BackgroundWorker worker;

        public TaskHelper(string datapath, BackgroundWorker worker, MSEConfig mcfg)
        {
            this.Datapath = datapath;
            this.worker = worker;
            this.mseHelper = new MseMaker(mcfg);
            this.imgSet = new ImageSet();
        }
        public MseMaker MseHelper
        {
            get { return this.mseHelper; }
        }
        public bool IsRuning()
        {
            return this.isRun;
        }
        public bool IsCancel()
        {
            return this.isCancel;
        }
        public void Cancel()
        {
            this.isRun = false;
            this.isCancel = true;
        }
        public MyTask GetLastTask()
        {
            return this.lastTask;
        }

        public void TestPendulumText(string desc)
        {
            this.mseHelper.TestPendulum(desc);
        }
        #endregion

        #region Other
        //设置任务
        public void SetTask(MyTask myTask, Card[] cards, params string[] args)
        {
            this.nowTask = myTask;
            this.cardlist = cards;
            this.mArgs = args;
        }
        //转换图片
        //public void ToImg(string img, string saveimg1, string saveimg2)
        public void ToImg(string img, string saveimg1)
        {
            if (!File.Exists(img))
            {
                return;
            }

            Bitmap bmp = new Bitmap(img);
            MyBitmap.SaveAsJPEG(MyBitmap.Zoom(bmp, this.imgSet.W, this.imgSet.H),
                                saveimg1, this.imgSet.quilty);
            //MyBitmap.SaveAsJPEG(MyBitmap.Zoom(bmp, imgSet.w, imgSet.h),
            //					saveimg2, imgSet.quilty);
            bmp.Dispose();
        }
        #endregion

        #region 检查更新
        public static void CheckVersion(bool showNew)
        {
            string newver = CheckUpdate.GetNewVersion(MyConfig.ReadString(MyConfig.TAG_UPDATE_URL));
            if (newver == CheckUpdate.DEFAULT)
            {   //检查失败
                if (!showNew)
                {
                    return;
                }

                MyMsg.Error(LMSG.CheckUpdateFail);
                return;
            }

            if (CheckUpdate.CheckVersion(newver, Application.ProductVersion))
            {//有最新版本
                if (!MyMsg.Question(LMSG.HaveNewVersion))
                {
                    return;
                }
            }
            else
            {//现在就是最新版本
                if (!showNew)
                {
                    return;
                }

                if (!MyMsg.Question(LMSG.NowIsNewVersion))
                {
                    return;
                }
            }
            //下载文件
            if (CheckUpdate.DownLoad(
                MyPath.Combine(Application.StartupPath, newver + ".zip")))
            {
                MyMsg.Show(LMSG.DownloadSucceed);
            }
            else
            {
                MyMsg.Show(LMSG.DownloadFail);
            }
        }
        public void OnCheckUpdate(bool showNew)
        {
            CheckVersion(showNew);
        }
        #endregion

        #region 裁剪图片
        public void CutImages(string imgpath, bool isreplace)
        {
            int count = this.cardlist.Length;
            int i = 0;
            foreach (Card c in this.cardlist)
            {
                if (this.isCancel)
                {
                    break;
                }

                i++;
                this.worker.ReportProgress((i / count), string.Format("{0}/{1}", i, count));
                string jpg = MyPath.Combine(imgpath, c.id + ".jpg");
                string savejpg = MyPath.Combine(this.mseHelper.ImagePath, c.id + ".jpg");
                if (File.Exists(jpg) && (isreplace || !File.Exists(savejpg)))
                {
                    Bitmap bp = new Bitmap(jpg);
                    Bitmap bmp;
                    if (c.IsType(CardType.TYPE_XYZ))//超量
                    {
                        bmp = MyBitmap.Cut(bp, this.imgSet.xyzArea);
                    }
                    else if (c.IsType(CardType.TYPE_PENDULUM))//P怪兽
                    {
                        bmp = MyBitmap.Cut(bp, this.imgSet.pendulumArea);
                    }
                    else//一般
                    {
                        bmp = MyBitmap.Cut(bp, this.imgSet.normalArea);
                    }
                    bp.Dispose();
                    MyBitmap.SaveAsJPEG(bmp, savejpg, this.imgSet.quilty);
                    //bmp.Save(savejpg, ImageFormat.Png);
                }
            }
        }
        #endregion

        //removed thumbnail
        #region 转换图片
        public void ConvertImages(string imgpath, string gamepath, bool isreplace)
        {
            string picspath = MyPath.Combine(gamepath, "pics");
            //string thubpath = MyPath.Combine(picspath, "thumbnail");
            string[] files = Directory.GetFiles(imgpath);
            int i = 0;
            int count = files.Length;

            foreach (string f in files)
            {
                if (this.isCancel)
                {
                    break;
                }

                i++;
                this.worker.ReportProgress(i / count, string.Format("{0}/{1}", i, count));
                string ex = Path.GetExtension(f).ToLower();
                string name = Path.GetFileNameWithoutExtension(f);
                string jpg_b = MyPath.Combine(picspath, name + ".jpg");
                //string jpg_s = MyPath.Combine(thubpath, name + ".jpg");
                if (ex == ".jpg" || ex == ".png" || ex == ".bmp")
                {
                    if (File.Exists(f))
                    {
                        Bitmap bmp = new Bitmap(f);
                        //大图，如果替换，或者不存在
                        if (isreplace || !File.Exists(jpg_b))
                        {

                            MyBitmap.SaveAsJPEG(MyBitmap.Zoom(bmp, this.imgSet.W, this.imgSet.H),
                                                jpg_b, this.imgSet.quilty);
                        }
                        //小图，如果替换，或者不存在
                        //if (isreplace || !File.Exists(jpg_s))
                        //{
                        //	MyBitmap.SaveAsJPEG(MyBitmap.Zoom(bmp, imgSet.w, imgSet.h),
                        //						jpg_s, imgSet.quilty);

                        //}
                    }
                }
            }
        }
        #endregion

        #region MSE存档
        public string MSEImagePath
        {
            get { return this.mseHelper.ImagePath; }
        }

        public string Datapath { get; }

        public void SaveMSEs(string file, Card[] cards, bool isUpdate)
        {
            if (cards == null)
            {
                return;
            }

            string pack_db=MyPath.GetRealPath(MyConfig.ReadString("pack_db"));
            bool rarity=MyConfig.ReadBoolean("mse_auto_rarity", false);
#if DEBUG
            MessageBox.Show("db = " + pack_db + ",auto rarity=" + rarity);
#endif
            int c = cards.Length;
            //不分开，或者卡片数小于单个存档的最大值
            if (this.mseHelper.MaxNum == 0 || c < this.mseHelper.MaxNum)
            {
                this.SaveMSE(1, file, cards, pack_db, rarity, isUpdate);
            }
            else
            {
                int nums = c / this.mseHelper.MaxNum;
                if (nums * this.mseHelper.MaxNum < c)//计算需要分多少个存档
                {
                    nums++;
                }

                List<Card> clist = new List<Card>();
                for (int i = 0; i < nums; i++)//分别生成存档
                {
                    clist.Clear();
                    for (int j = 0; j < this.mseHelper.MaxNum; j++)
                    {
                        int index = i * this.mseHelper.MaxNum + j;
                        if (index < c)
                        {
                            clist.Add(cards[index]);
                        }
                    }
                    int t = file.LastIndexOf(".mse-set");
                    string fname = (t > 0) ? file.Substring(0, t) : file;
                    fname += string.Format("_{0}.mse-set", i + 1);
                    this.SaveMSE(i + 1, fname, clist.ToArray(), pack_db, rarity, isUpdate);
                }
            }
        }
        public void SaveMSE(int num, string file, Card[] cards, string pack_db, bool rarity, bool isUpdate)
        {
            string setFile = file + ".txt";
            Dictionary<Card, string> images = this.mseHelper.WriteSet(setFile, cards,pack_db,rarity);
            if (isUpdate)//仅更新文字
            {
                return;
            }

            int i = 0;
            int count = images.Count;
            using (ZipStorer zips = ZipStorer.Create(file, ""))
            {
                zips.EncodeUTF8 = true;//zip里面的文件名为utf8
                zips.AddFile(setFile, "set", "");
                foreach (Card c in images.Keys)
                {
                    string img=images[c];
                    if (this.isCancel)
                    {
                        break;
                    }

                    i++;
                    this.worker.ReportProgress(i / count, string.Format("{0}/{1}-{2}", i, count, num));
                    //TODO 先裁剪图片
                    zips.AddFile(this.mseHelper.GetImageCache(img, c), Path.GetFileName(img), "");
                }
            }
            File.Delete(setFile);
        }
        public Card[] ReadMSE(string mseset, bool repalceOld)
        {
            //解压所有文件
            using (ZipStorer zips = ZipStorer.Open(mseset, FileAccess.Read))
            {
                zips.EncodeUTF8 = true;
                List<ZipStorer.ZipFileEntry> files = zips.ReadCentralDir();
                int count = files.Count;
                int i = 0;
                foreach (ZipStorer.ZipFileEntry file in files)
                {
                    this.worker.ReportProgress(i / count, string.Format("{0}/{1}", i, count));
                    string savefilename = MyPath.Combine(this.mseHelper.ImagePath, file.FilenameInZip);
                    zips.ExtractFile(file, savefilename);
                }
            }
            string setfile = MyPath.Combine(this.mseHelper.ImagePath, "set");
            return this.mseHelper.ReadCards(setfile, repalceOld);
        }
        #endregion

        #region 导出数据
        public void ExportData(string path, string zipname, string _cdbfile, string modulescript)
        {
            int i = 0;
            Card[] cards = this.cardlist;
            if (cards == null || cards.Length == 0)
            {
                return;
            }

            int count = cards.Length;
            YgoPath ygopath = new YgoPath(path);
            string name = Path.GetFileNameWithoutExtension(zipname);
            //数据库
            string cdbfile = zipname + ".cdb";
            //说明
            string readme = MyPath.Combine(path, name + ".txt");
            //新卡ydk
            string deckydk = ygopath.GetYdk(name);
            //module scripts
            string extra_script = "";
            if (modulescript.Length > 0)
            {
                extra_script = ygopath.GetModuleScript(modulescript);
            }

            File.Delete(cdbfile);
            DataBase.Create(cdbfile);
            DataBase.CopyDB(cdbfile, false, this.cardlist);
            if (File.Exists(zipname))
            {
                File.Delete(zipname);
            }

            using (ZipStorer zips = ZipStorer.Create(zipname, ""))
            {
                zips.AddFile(cdbfile, Path.GetFileNameWithoutExtension(_cdbfile) + ".cdb", "");
                if (File.Exists(readme))
                {
                    zips.AddFile(readme, "readme_" + name + ".txt", "");
                }

                if (File.Exists(deckydk))
                {
                    zips.AddFile(deckydk, "deck/" + name + ".ydk", "");
                }

                if (modulescript.Length > 0 && File.Exists(extra_script))
                {
                    zips.AddFile(extra_script, extra_script.Replace(path, ""), "");
                }

                foreach (Card c in cards)
                {
                    i++;
                    this.worker.ReportProgress(i / count, string.Format("{0}/{1}", i, count));
                    string[] files = ygopath.GetCardfiles(c.id);
                    foreach (string file in files)
                    {
                        if (!string.Equals(file, extra_script) && File.Exists(file))
                        {
                            zips.AddFile(file, file.Replace(path, ""), "");
                        }
                    }
                }
            }
            File.Delete(cdbfile);
        }
        #endregion

		#region 繁简转换
		public void ReplaceWithCNsOrCNt(string configName, string cdbName)
		{
			Card[] cards = cardlist;
			int count = cards.Length;
			if (cards == null || cards.Length == 0)
				return;

			for (int i = 0; i < count; i++)
			{
				if (isCancel)
				{
					File.Delete(cdbName);
					return;
				}
				worker.ReportProgress(i / count, string.Format("{0}/{1}", i, count));
				if (cards[i].name != null)
				{
					cards[i].name = MseHelper.ReplaceWithCNsOrCNt(cards[i].name, configName);
				}
				if (cards[i].desc != null)
				{
					cards[i].desc = MseHelper.ReplaceWithCNsOrCNt(cards[i].desc, configName);
				}
			}
			DataBase.CopyDB(cdbName, false, cards);
			MyMsg.Show(LMSG.CopyCardsToDBIsOK);
		}
		#endregion

        #region 运行
        public void Run()
        {
            this.isCancel = false;
            this.isRun = true;
            bool replace;
            bool showNew;
            switch (this.nowTask)
            {
                case MyTask.ExportData:
                    if (this.mArgs != null && this.mArgs.Length >= 3)
                    {
                        this.ExportData(this.mArgs[0], this.mArgs[1], this.mArgs[2], this.mArgs[3]);
                    }
                    break;
				case MyTask.ReplaceWithCNsOrCNt:
					if (mArgs != null && mArgs.Length >= 1)
					{
						ReplaceWithCNsOrCNt(mArgs[0], mArgs[1]);
					}
					break;
                case MyTask.CheckUpdate:
                    showNew = false;
                    if (this.mArgs != null && this.mArgs.Length >= 1)
                    {
                        showNew = (this.mArgs[0] == bool.TrueString) ? true : false;
                    }
                    this.OnCheckUpdate(showNew);
                    break;
                case MyTask.CutImages:
                    if (this.mArgs != null && this.mArgs.Length >= 2)
                    {
                        replace = true;
                        if (this.mArgs.Length >= 2)
                        {
                            if (this.mArgs[1] == bool.FalseString)
                            {
                                replace = false;
                            }
                        }
                        this.CutImages(this.mArgs[0], replace);
                    }
                    break;
                case MyTask.SaveAsMSE:
                    if (this.mArgs != null && this.mArgs.Length >= 2)
                    {
                        replace = false;
                        if (this.mArgs.Length >= 2)
                        {
                            if (this.mArgs[1] == bool.TrueString)
                            {
                                replace = true;
                            }
                        }
                        this.SaveMSEs(this.mArgs[0], this.cardlist, replace);
                    }
                    break;
                case MyTask.ReadMSE:
                    if (this.mArgs != null && this.mArgs.Length >= 2)
                    {
                        replace = false;
                        if (this.mArgs.Length >= 2)
                        {
                            if (this.mArgs[1] == bool.TrueString)
                            {
                                replace = true;
                            }
                        }
                        this.cardlist = this.ReadMSE(this.mArgs[0], replace);
                    }
                    break;
                case MyTask.ConvertImages:
                    if (this.mArgs != null && this.mArgs.Length >= 2)
                    {
                        replace = true;
                        if (this.mArgs.Length >= 3)
                        {
                            if (this.mArgs[2] == bool.FalseString)
                            {
                                replace = false;
                            }
                        }
                        this.ConvertImages(this.mArgs[0], this.mArgs[1], replace);
                    }
                    break;
            }
            this.isRun = false;
            this.lastTask = this.nowTask;
            this.nowTask = MyTask.NONE;
            if (this.lastTask != MyTask.ReadMSE)
            {
                this.cardlist = null;
            }

            this.mArgs = null;
        }
        #endregion
    }

}
