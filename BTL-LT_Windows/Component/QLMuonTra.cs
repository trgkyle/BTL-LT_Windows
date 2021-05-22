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
    public partial class QLMuonTra : Form
    {
        PhieuMuonBUS phieuMuonBUS = new PhieuMuonBUS();
        NhanVienBUS nhanVienBUS = new NhanVienBUS();
        DocGiaBUS docGiaBUS = new DocGiaBUS();
        public QLMuonTra()
        {
            InitializeComponent();
        }

        public void LoadInit()
        {
            dgvTaiLieuMuon.DataSource = phieuMuonBUS.getDataFromSource();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
            this.LoadInit();

        }

        private void QLMuonTra_Load(object sender, EventArgs e)
        {

        }

        private void btn_Click(object sender, EventArgs e)
        {
            string maPhieuMuon = txtMaPhieuMuon.Text.ToString();
            string maDocGia = txtMaDocGia.Text.ToString();
            string tenDocGia = txtTenDocGia.Text.ToString();
            DateTime ngayMuon = txtNgayMuon.Value;
            string maNhanVien = txtMaNhanVien.Text.ToString();
            string tenNhanVien = txtTenNhanVien.Text.ToString();

            PhieuMuonDTO newPhieuMuon = new PhieuMuonDTO(maPhieuMuon, maDocGia, ngayMuon, maNhanVien, tenNhanVien,1);
            phieuMuonBUS.addNewData(newPhieuMuon);
            this.LoadInit();


        }

        private void txtMaDocGia_TextChanged(object sender, EventArgs e)
        {
            txtTenDocGia.Text = docGiaBUS.searchTenDocGia(txtMaDocGia.Text.ToString());
        }

        private void txtMaNhanVien_TextChanged(object sender, EventArgs e)
        {
            txtTenNhanVien.Text = nhanVienBUS.searchTenNhanVien(txtMaNhanVien.Text.ToString());

        }
    }
}
