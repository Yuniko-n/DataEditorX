using System.Windows.Forms;

namespace DataEditorX
{
    public class DFlowLayoutPanel : FlowLayoutPanel
    {
        public DFlowLayoutPanel()
        {
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.AllPaintingInWmPaint,
                     true);
            this.UpdateStyles();
        }
    }
}
