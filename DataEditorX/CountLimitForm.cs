using System;
using System.Windows.Forms;

namespace DataEditorX
{
    public partial class CountLimitForm : Form
    {
        public EffectCountLimit CountLimit;
        public CountLimitForm(EffectCountLimit ecl)
        {
            this.InitializeComponent();
            CountLimit = ecl;
            this.checkIsOath.Checked = ecl.IsOath;
            this.checkIsInDuel.Checked = ecl.IsInDuel;
            this.checkIsHasCode.Checked = ecl.IsHasCode;
            this.checkIsSingle.Checked = ecl.IsSingle;
            this.numCount.Value = ecl.Count;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            CountLimit.IsOath = this.checkIsOath.Checked;
            CountLimit.IsInDuel = this.checkIsInDuel.Checked;
            CountLimit.IsHasCode = this.checkIsHasCode.Checked;
            CountLimit.IsSingle = this.checkIsSingle.Checked;
            CountLimit.Count = this.numCount.Value;
        }
    }
    public class EffectCountLimit
    {
        public bool IsOath = false;
        public bool IsInDuel = false;
        public bool IsHasCode = false;
        public bool IsSingle = false;
        public decimal Code = 1000;
        public decimal Offset = 0;
        public decimal Count = 1;
        public EffectCountLimit(decimal code)
        {
            Code = code;
            Offset = 0;
        }
        public EffectCountLimit(decimal code, decimal offset)
        {
            Code = code;
            Offset = offset;
        }
    }
}
