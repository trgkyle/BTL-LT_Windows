using BUS;
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
        PhieuMuonBUS phieuMuonBUS = new PhieuMuonBUS();
        private String nguoiLap;
        public ThongKe(String nguoiLap)
        {
            this.nguoiLap = nguoiLap;
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            dgvThongKe.DataSource = phieuMuonBUS.getThongKe(dateFrom.Value, dateTo.Value);
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
            dateFrom.Value = new DateTime(2021, 1, 1);
            txtNgayLap.Value = DateTime.Now;
            txtNguoiLap.Text = nguoiLap;
            txtThuVien.Text = "Thư viện Trường Đại học Công Nghiệp Hà Nội";
            //dgvThongKe.DataSource = phieuMuonBUS.getThongKe(dateFrom.Value, dateTo.Value);
        }
    }
}
