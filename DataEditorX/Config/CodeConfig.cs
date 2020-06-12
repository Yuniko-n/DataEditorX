using FastColoredTextBoxNS;
using System;
using System.Collections.Generic;
using System.IO;

namespace DataEditorX.Config
{
    /// <summary>
    /// CodeEditor的配置
    /// </summary>
    public class CodeConfig
    {

        #region 成员
        public CodeConfig()
        {
            this.tooltipDic = new SortedList<string, string>();
            this.longTooltipDic = new SortedList<string, string>();
            this.items = new List<AutocompleteItem>();
        }

        //函数提示
        readonly SortedList<string, string> tooltipDic;
        readonly SortedList<string, string> longTooltipDic;
        readonly List<AutocompleteItem> items;
        /// <summary>
        /// 输入提示
        /// </summary>
        public SortedList<string, string> TooltipDic
        {
            get { return this.tooltipDic; }
        }
        public SortedList<string, string> LongTooltipDic
        {
            get { return this.longTooltipDic; }
        }
        public AutocompleteItem[] Items
        {
            get { return this.items.ToArray(); }
        }
        #endregion

        #region 系列名/指示物
        /// <summary>
        /// 设置系列名
        /// </summary>
        /// <param name="dic"></param>
        public void SetNames(Dictionary<long, string> dic)
        {
            foreach (long k in dic.Keys)
            {
                string key = "0x" + k.ToString("x");
                if (!this.tooltipDic.ContainsKey(key))
                {
                    this.AddToolIipDic(key, dic[k]);
                }
            }
        }
        /// <summary>
        /// 读取指示物
        /// </summary>
        /// <param name="file"></param>
        public void AddStrings(string file)
        {
            if (File.Exists(file))
            {
                string[] lines = File.ReadAllLines(file);
                foreach (string line in lines)
                {
                    //特殊胜利和指示物
                    if (line.StartsWith("!victory")
                       || line.StartsWith("!counter"))
                    {
                        string[] ws = line.Split(' ');
                        if (ws.Length > 2)
                        {
                            this.AddToolIipDic(ws[1], ws[2]);
                        }
                    }
                }
            }
        }

        #endregion

        #region function
        public void AddFunction(string funtxt)
        {
            if (!File.Exists(funtxt))
            {
                return;
            }

            string[] lines = File.ReadAllLines(funtxt);
            bool isFind = false;
            string name = "";
            string desc = "";
            foreach (string line in lines)
            {
                if (string.IsNullOrEmpty(line)
                   || line.StartsWith("==")
                   || line.StartsWith("#"))
                {
                    continue;
                }

                if (line.StartsWith("●"))
                {
                    //add
                    this.AddToolIipDic(name, desc);
                    int w = line.IndexOf("(");
                    int t = line.IndexOf(" ");

                    if (t < w && t > 0)
                    {
                        //找到函数
                        name = line.Substring(t + 1, w - t - 1);
                        isFind = true;
                        desc = line;
                    }
                }
                else if (isFind)
                {
                    desc += Environment.NewLine + line;
                }
            }
            this.AddToolIipDic(name, desc);
        }
        #endregion

        #region 常量
        public void AddConstant(string conlua)
        {
            //conList.Add("con");
            if (!File.Exists(conlua))
            {
                return;
            }

            string[] lines = File.ReadAllLines(conlua);
            foreach (string line in lines)
            {
                if (line.StartsWith("--"))
                {
                    continue;
                }

                int t = line.IndexOf("=");
                _ = line.IndexOf("--");
                //常量 = 0x1 ---注释
                string k = (t > 0) ? line.Substring(0, t).TrimEnd(new char[] { ' ', '\t' })
                    : line;
                string desc = (t > 0) ? line.Substring(t + 1).Replace("--", "\n")
    : line;
                this.AddToolIipDic(k, desc);
            }
        }
        #endregion

        #region 处理
        public void InitAutoMenus()
        {
            this.items.Clear();
            foreach (string k in this.tooltipDic.Keys)
            {
                AutocompleteItem item = new AutocompleteItem(k)
                {
                    ToolTipTitle = k,
                    ToolTipText = this.tooltipDic[k]
                };
                this.items.Add(item);
            }
            foreach (string k in this.longTooltipDic.Keys)
            {
                if (this.tooltipDic.ContainsKey(k))
                {
                    continue;
                }

                AutocompleteItem item = new AutocompleteItem(k)
                {
                    ToolTipTitle = k,
                    ToolTipText = this.longTooltipDic[k]
                };
                this.items.Add(item);
            }
        }
        string GetShortName(string name)
        {
            int t = name.IndexOf(".");
            if (t > 0)
            {
                return name.Substring(t + 1);
            }
            else
            {
                return name;
            }
        }
        void AddToolIipDic(string key, string val)
        {
            string skey = this.GetShortName(key);
            if (this.tooltipDic.ContainsKey(skey))//存在
            {
                string nval = this.tooltipDic[skey];
                if (!nval.EndsWith(Environment.NewLine))
                {
                    nval += Environment.NewLine;
                }

                nval += Environment.NewLine + val;
                this.tooltipDic[skey] = nval;
            }
            else
            {
                this.tooltipDic.Add(skey, val);
            }
            //
            this.AddLongToolIipDic(key, val);
        }
        void AddLongToolIipDic(string key, string val)
        {
            if (this.longTooltipDic.ContainsKey(key))//存在
            {
                string nval = this.longTooltipDic[key];
                if (!nval.EndsWith(Environment.NewLine))
                {
                    nval += Environment.NewLine;
                }

                nval += Environment.NewLine + val;
                this.longTooltipDic[key] = nval;
            }
            else
            {
                this.longTooltipDic.Add(key, val);
            }
        }
        #endregion
    }
}
