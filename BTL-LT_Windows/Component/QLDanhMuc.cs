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
    public partial class QLDanhMuc : Form
    {
        TaiLieuBUS taiLieuBUS = new TaiLieuBUS();
        TheLoaiBUS theLoaiBUS = new TheLoaiBUS();
        public QLDanhMuc()
        {
            InitializeComponent();
        }


        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        public void LoadInit()
        {
            dgvTLieu.DataSource = taiLieuBUS.getDataFromSource();
            dgvTLoai.DataSource = theLoaiBUS.getDataFromSource();
        }

        private void QLDanhMuc_Load(object sender, EventArgs e)
        {
            this.LoadInit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string maTaiLieu = txtMaTaiLieu.Text.ToString();
            string tenTaiLieu = txtTenTaiLieu.Text.ToString();
            string maTheLoai = txtTheLoai.Text.ToString();
            string soLuong = txtSoLuong.Text.ToString();
            string nhaXuatBan = txtNhaXuatBan.Text.ToString();
            string namXuatBan = txtNamXuatBan.Text.ToString();
            string tacGia = txtTacGia.Text.ToString();

            TaiLieuDTO newTaiLieu = new TaiLieuDTO(maTaiLieu, tenTaiLieu, maTheLoai, short.Parse(soLuong), nhaXuatBan, short.Parse(namXuatBan), tacGia);
            taiLieuBUS.addNewData(newTaiLieu);
            this.LoadInit();
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            string maTheLoai = txtMaTheLoai2.Text.ToString();
            string tenTheLoai = txtTenTheLoai2.Text.ToString();
            string ghiChu = txtGhiChu2.Text.ToString();

            TheLoaiDTO newTheLoai = new TheLoaiDTO(maTheLoai,tenTheLoai,ghiChu);
            theLoaiBUS.addNewData(newTheLoai);
            this.LoadInit();
        }
    }
}
