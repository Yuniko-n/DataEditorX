using System;
using System.Collections.Generic;
using System.IO;
using WeifenLuo.WinFormsUI.Docking;

namespace DataEditorX
{
    public partial class EffectCreatorForm : DockContent
    {
        public EffectCreatorForm()
        {
            this.InitializeComponent();
        }

        class EffectCreatorItem
        {
            public string Key;
            public string Value;
            public string Hint;

            public EffectCreatorItem(string key, string value)
            {
                this.Key = key ?? throw new ArgumentNullException(nameof(key));
                this.Value = value;
            }

            public EffectCreatorItem(string key, string value, string hint) : this(key, value)
            {
                this.Hint = hint;
            }

            public override string ToString()
            {
                return Value;
            }
        }
        Dictionary<string, List<EffectCreatorItem>> itemDic = new Dictionary<string, List<EffectCreatorItem>>();
        private void EffectCreatorForm_Load(object sender, EventArgs e)
        {
            string config = $"data{Path.DirectorySeparatorChar}effect_creator_settings.txt";
            if (!File.Exists(config))
            {
                return;
            }
            char[] sepChars = new char[]{' ','\t','　'};
            FileStream fs = new FileStream(config,FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            string nowType = "";
            for (string line = sr.ReadLine(); line != null; line = sr.ReadLine())
            {
                line = line.Trim();
                if (line.StartsWith("!"))
                {
                    nowType = line.Substring(1);
                    if (!itemDic.ContainsKey(nowType))
                    {
                        itemDic.Add(nowType, new List<EffectCreatorItem>());
                    }
                    continue;
                }
                if (line.StartsWith("#"))
                {
                    continue;
                }
                string[] split = line.Split(sepChars,StringSplitOptions.RemoveEmptyEntries);
                if (split.Length == 2)
                {
                    itemDic[nowType].Add(new EffectCreatorItem(split[0], split[1]));
                }
                if (split.Length == 3)
                {
                    itemDic[nowType].Add(new EffectCreatorItem(split[0], split[1], split[2]));
                }
            }
            foreach (var item in itemDic["EFFECT_CODES"])
            {
                listEffectCode.Items.Add(item);
            }
            foreach (var item in itemDic["EVENT_CODES"])
            {
                listEffectCode.Items.Add(item);
            }
        }
    }
}
