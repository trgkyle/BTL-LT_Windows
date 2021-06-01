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
    public partial class Login : Form
    {
        TaiKhoanBUS taiKhoan = new TaiKhoanBUS();
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string tenTaiKhoan = txtTaiKhoan.Text;
            string matKhau = txtMatKhau.Text;
            if (taiKhoan.Login(tenTaiKhoan, matKhau) == false)
            {
                MessageBox.Show("Sai tài khoản mật khẩu","Lỗi");
                return;
            }
            this.Enabled = false;

            Main newForm = new Main(tenTaiKhoan, matKhau);
            //QLThuVien newForm = new QLThuVien();
            this.Hide();
            newForm.ShowDialog();
            this.Close();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
