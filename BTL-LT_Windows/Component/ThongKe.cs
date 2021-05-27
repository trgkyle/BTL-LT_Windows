using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_LT_Windows
{
    public partial class ThongKe : Form
    {
        public ThongKe()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            printDocument1.Print();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bm = new Bitmap(this.Size.Width, this.Size.Height);

            this.DrawToBitmap(bm, new Rectangle(0, 0, this.Size.Width, this.Size.Height));

            e.Graphics.DrawImage(bm, 0, 0);
        }

        private void ThongKe_Load(object sender, EventArgs e)
        {

        }
    }
}
