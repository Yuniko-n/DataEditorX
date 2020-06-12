using System.Windows.Forms;

namespace DataEditorX
{
    public class DListBox : ListBox
    {
        public DListBox()
        {
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
         ControlStyles.AllPaintingInWmPaint,
         true);
            this.UpdateStyles();
        }
    }
}
