using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace DataEditorX.Config
{
    public class YgoPath
    {
        public YgoPath(string gamepath)
        {
            SetPath(gamepath);
        }
        public void SetPath(string gamepath)
        {
            this.gamepath = gamepath;
            picpath = MyPath.Combine(gamepath, "pics");
            fieldpath = MyPath.Combine(picpath, "field");
            picpath2 = MyPath.Combine(picpath, "thumbnail");
            luapath = MyPath.Combine(gamepath, "script");
            ydkpath = MyPath.Combine(gamepath, "deck");
            replaypath = MyPath.Combine(gamepath, "replay");
		}
        /// <summary>游戏目录</summary>
        public string gamepath;
        /// <summary>大图目录</summary>
        public string picpath;
        /// <summary>小图目录</summary>
        public string picpath2;
        /// <summary>场地图目录</summary>
        public string fieldpath;
        /// <summary>脚本目录</summary>
        public string luapath;
        /// <summary>卡组目录</summary>
        public string ydkpath;
        /// <summary>录像目录</summary>
        public string replaypath;

		public string GetImage(long id)
        {
			return GetImage(id.ToString());
		}
		//public string GetImageThum(long id)
		//{
		//	return GetImageThum(id.ToString());
		//}
		public string GetImageField(long id)
        {
			return GetImageField(id.ToString());//场地图
        }
		public string GetScript(long id)
        {
			return GetScript(id.ToString());
		}
		public string GetYdk(string name)
		{
			return MyPath.Combine(ydkpath, name + ".ydk");
		}
		//字符串id
		public string GetImage(string id)
		{
			if (File.Exists(MyPath.Combine(picpath, id + ".png")) && MyConfig.readBoolean(MyConfig.TAG_READ_PNG)) {
				return MyPath.Combine(picpath, id + ".png");
			} else {
				return MyPath.Combine(picpath, id + ".jpg");
			}
		}
		//public string GetImageThum(string id)
		//{
		//	return MyPath.Combine(picpath2, id + ".jpg");
		//}
		public string GetImageField(string id)
		{
			if (File.Exists(MyPath.Combine(fieldpath, id + ".png")) && MyConfig.readBoolean(MyConfig.TAG_READ_PNG)) {
				return MyPath.Combine(fieldpath, id + ".png");//场地图
			} else {
				return MyPath.Combine(fieldpath, id + ".jpg");//场地图
			}
		}
		public string GetScript(string id)
		{
			if (Directory.Exists(luapath))
			{
				DirectoryInfo[] ScriptInfos = (new DirectoryInfo(luapath)).GetDirectories();
				for (int i = 0; i < ScriptInfos.Length; i++)
				{
					if (File.Exists(MyPath.Combine(ScriptInfos[i].FullName, "c" + id + ".lua")))
					{
						return MyPath.Combine(ScriptInfos[i].FullName, "c" + id + ".lua");
					}
				}
			}
			return MyPath.Combine(luapath, "c" + id + ".lua");
		}
		public string GetModuleScript(string modulescript)
		{
			return MyPath.Combine(luapath, modulescript + ".lua");
		}

		public string[] GetCardfiles(long id)
		{
			string[] files = new string[]{
				GetImage(id),//大图
				//GetImageThum(id),//小图
				GetImageField(id),//场地图
				GetScript(id)
		   };
			return files;
		}
		public string[] GetCardfiles(string id)
		{
			string[] files = new string[]{
				GetImage(id),//大图
				//GetImageThum(id),//小图
				GetImageField(id),//场地图
				GetScript(id)
		   };
			return files;
		}
	}
}
