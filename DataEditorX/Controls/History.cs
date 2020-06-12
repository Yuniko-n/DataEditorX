using DataEditorX.Config;
using DataEditorX.Core;
using DataEditorX.Language;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace DataEditorX.Controls
{

    public class History
    {
        readonly IMainForm mainForm;
        string historyFile;
        readonly List<string> cdbhistory;
        readonly List<string> luahistory;
        public string[] GetcdbHistory()
        {
            return this.cdbhistory.ToArray();
        }
        public string[] GetluaHistory()
        {
            return this.luahistory.ToArray();
        }
        public History(IMainForm mainForm)
        {
            this.mainForm = mainForm;
            this.cdbhistory = new List<string>();
            this.luahistory = new List<string>();
        }
        //读取历史记录
        public void ReadHistory(string historyFile)
        {
            this.historyFile = historyFile;
            if (!File.Exists(historyFile))
            {
                return;
            }

            string[] lines = File.ReadAllLines(historyFile);
            this.AddHistorys(lines);
        }
        //添加历史记录
        void AddHistorys(string[] lines)
        {
            this.luahistory.Clear();
            this.cdbhistory.Clear();
            foreach (string line in lines)
            {
                if (string.IsNullOrEmpty(line) || line.StartsWith("#"))
                {
                    continue;
                }

                if (File.Exists(line))
                {
                    if (YGOUtil.IsScript(line))
                    {
                        if (this.luahistory.Count < MyConfig.MAX_HISTORY
                            && this.luahistory.IndexOf(line) < 0)
                        {
                            this.luahistory.Add(line);
                        }
                    }
                    else
                    {
                        if (this.cdbhistory.Count < MyConfig.MAX_HISTORY
                            && this.cdbhistory.IndexOf(line) < 0)
                        {
                            this.cdbhistory.Add(line);
                        }
                    }
                }
            }
        }
        public void AddHistory(string file)
        {
            List<string> tmplist = new List<string>
            {
                //添加到开始
                file
            };
            //添加旧记录
            tmplist.AddRange(this.cdbhistory.ToArray());
            tmplist.AddRange(this.luahistory.ToArray());
            //
            this.AddHistorys(tmplist.ToArray());
            this.SaveHistory();
            this.MenuHistory();
        }
        //保存历史
        void SaveHistory()
        {
            string texts = "# database history";
            foreach (string str in this.cdbhistory)
            {
                if (File.Exists(str))
                {
                    texts += Environment.NewLine + str;
                }
            }
            texts += Environment.NewLine + "# script history";
            foreach (string str in this.luahistory)
            {
                if (File.Exists(str))
                {
                    texts += Environment.NewLine + str;
                }
            }
            if (File.Exists(this.historyFile))
            {
                File.Delete(this.historyFile);
            }

            File.WriteAllText(this.historyFile, texts);
        }
        //添加历史记录菜单
        public void MenuHistory()
        {
            //cdb历史
            this.mainForm.CdbMenuClear();
            foreach (string str in this.cdbhistory)
            {
                ToolStripMenuItem tsmi = new ToolStripMenuItem(str);
                tsmi.Click += this.MenuHistoryItem_Click;
                this.mainForm.AddCdbMenu(tsmi);
            }
            this.mainForm.AddCdbMenu(new ToolStripSeparator());
            ToolStripMenuItem tsmiclear = new ToolStripMenuItem(LanguageHelper.GetMsg(LMSG.ClearHistory));
            tsmiclear.Click += this.MenuHistoryClear_Click;
            this.mainForm.AddCdbMenu(tsmiclear);
            //lua历史
            this.mainForm.LuaMenuClear();
            foreach (string str in this.luahistory)
            {
                ToolStripMenuItem tsmi = new ToolStripMenuItem(str);
                tsmi.Click += this.MenuHistoryItem_Click;
                this.mainForm.AddLuaMenu(tsmi);
            }
            this.mainForm.AddLuaMenu(new ToolStripSeparator());
            ToolStripMenuItem tsmiclear2 = new ToolStripMenuItem(LanguageHelper.GetMsg(LMSG.ClearHistory));
            tsmiclear2.Click += this.MenuHistoryClear2_Click;
            this.mainForm.AddLuaMenu(tsmiclear2);
        }

        void MenuHistoryClear2_Click(object sender, EventArgs e)
        {
            this.luahistory.Clear();
            this.MenuHistory();
            this.SaveHistory();
        }
        void MenuHistoryClear_Click(object sender, EventArgs e)
        {
            this.cdbhistory.Clear();
            this.MenuHistory();
            this.SaveHistory();
        }
        void MenuHistoryItem_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem tsmi)
            {
                string file = tsmi.Text;
                if (File.Exists(file))
                {
                    this.mainForm.Open(file);
                }
            }
        }
    }
}
