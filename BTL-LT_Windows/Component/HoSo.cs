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
    public partial class HoSo : Form
    {
        TaiKhoanBUS taiKhoan = new TaiKhoanBUS();
        string tenTaiKhoan;
        string matKhau;
        public HoSo(string tenTaiKhoan, string matKhau)
        {
            this.tenTaiKhoan = tenTaiKhoan;
            this.matKhau = matKhau;
            InitializeComponent();
        }

        private void HoSo_Load(object sender, EventArgs e)
        {
            TaiKhoanDTO thongTinTaiKhoan = taiKhoan.layThongTin(tenTaiKhoan, matKhau);
            txtHoTen.Text = thongTinTaiKhoan.HoTen;
            txtTenTaiKhoan.Text = thongTinTaiKhoan.TaiKhoan;
            txtQuyen.Text = thongTinTaiKhoan.Quyen;
            txtHoTen.Enabled = false;
            txtTenTaiKhoan.Enabled = false;
            txtQuyen.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(txtNewPassword.Text == txtConfirmPassword.Text)
            {
                Boolean status = taiKhoan.doiMatKhau(tenTaiKhoan, txtOldPassword.Text, txtNewPassword.Text);
                if (status)
                {
                    txtOldPassword.Text = "";
                    txtNewPassword.Text = "";
                    txtConfirmPassword.Text = "";
                    MessageBox.Show("Thay đổi mật khẩu thành công", "Thành công");
                }
                else
                {
                    MessageBox.Show("Mật khẩu cũ không chính xác", "Lỗi thay đổi mật khẩu");
                }
            }else
            {
                MessageBox.Show("Mật khẩu mới xác thực không khớp", "Lỗi thay đổi mật khẩu");
            }
            
        }
    }
}
