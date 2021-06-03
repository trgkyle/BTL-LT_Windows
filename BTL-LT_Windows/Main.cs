using BUS;
using DTO;
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
    public partial class Main : Form
    {
        TaiKhoanBUS taiKhoan = new TaiKhoanBUS();
        TaiKhoanDTO thongTinTaiKhoan;
        string tenTaiKhoan;
        string matKhau;
        public Main(string taiKhoan, string matKhau)
        {
            this.tenTaiKhoan = taiKhoan;
            this.matKhau = matKhau;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            QLDanhMuc newForm = new QLDanhMuc();
            newForm.ShowDialog();
            this.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            QLMuonTra newForm = new QLMuonTra();
            newForm.ShowDialog();
            this.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            ThongKe newForm = new ThongKe(thongTinTaiKhoan.HoTen);
            newForm.ShowDialog();
            this.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            HoSo newForm = new HoSo(tenTaiKhoan,matKhau);
            newForm.ShowDialog();
            this.Enabled = true;
        }

        private void Main_Load(object sender, EventArgs e)
        {
            thongTinTaiKhoan = taiKhoan.layThongTin(tenTaiKhoan, matKhau);
            txtTenTaiKhoan.Text = thongTinTaiKhoan.TaiKhoan;
            txtLoaiTaiKhoan.Text = thongTinTaiKhoan.Quyen;
            if (thongTinTaiKhoan.Quyen.Equals("ADMIN"))
            {
                Console.WriteLine(thongTinTaiKhoan.Quyen);
                btnDanhMuc.Enabled = false;
            }
        }
    }
}
