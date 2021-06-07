using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_LT_Windows
{
    public partial class QLMuonTra : Form
    {
        Bitmap bm;

        PhieuMuonBUS phieuMuonBUS = new PhieuMuonBUS();
        NhanVienBUS nhanVienBUS = new NhanVienBUS();
        DocGiaBUS docGiaBUS = new DocGiaBUS();
        TaiLieuBUS taiLieuBUS = new TaiLieuBUS();
        List<PhieuTaiLieuDTO> danhSachPhieuTaiLieu = new List<PhieuTaiLieuDTO>();
        public QLMuonTra()
        {
            InitializeComponent();
        }

        public void LoadInit()
        {
            txtMaTaiLieu.Enabled = true;
            txtMaPhieuMuon.Enabled = true;

            // No load danh sách tài liệu mượn so it commented
            //dgvTaiLieuMuon.Rows.Clear();

            //foreach(PhieuTaiLieuDTO phieuTaiLieu in danhSachPhieuTaiLieu)
            //{
            //    dgvTaiLieuMuon.Rows.Add(phieuTaiLieu.taiLieu.MaTaiLieu, phieuTaiLieu.taiLieu.TenTaiLieu, phieuTaiLieu.soLuongMuon);
            //}
            dgvTaiLieuDangMuon.DataSource = phieuMuonBUS.getDataFromSource();

        }

        private void QLMuonTra_Load(object sender, EventArgs e)
        {
            LoadInit();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bm, e.PageBounds);
        }

        private void dgvTaiLieuDangMuon_RowEnter_1(object sender, DataGridViewCellEventArgs e)
        {
            txtMaTaiLieu.Enabled = false;
            txtMaPhieuMuon.Enabled = false;
            txtMaPhieuMuon.Text = dgvTaiLieuDangMuon.Rows[e.RowIndex].Cells[0].Value.ToString().Trim();
            txtMaDocGia.Text = dgvTaiLieuDangMuon.Rows[e.RowIndex].Cells[1].Value.ToString().Trim();
            txtNgayMuon.Text = dgvTaiLieuDangMuon.Rows[e.RowIndex].Cells[2].Value.ToString().Trim();
            txtMaNhanVien.Text = dgvTaiLieuDangMuon.Rows[e.RowIndex].Cells[3].Value.ToString().Trim();
            txtMaTaiLieu.Text = dgvTaiLieuDangMuon.Rows[e.RowIndex].Cells[4].Value.ToString().Trim();
            txtSoLuongMuon.Text = dgvTaiLieuDangMuon.Rows[e.RowIndex].Cells[5].Value.ToString().Trim();
            string ngayTra = dgvTaiLieuDangMuon.Rows[e.RowIndex].Cells[6].Value?.ToString().Trim();
            dgvTaiLieuMuon.Rows.Clear();
            danhSachPhieuTaiLieu.Clear();
            PhieuTaiLieuDTO newPhieuTaiLieu = new PhieuTaiLieuDTO();

            newPhieuTaiLieu.taiLieu.MaTaiLieu = txtMaTaiLieu.Text;
            newPhieuTaiLieu.taiLieu.TenTaiLieu = txtTenTaiLieu.Text;
            newPhieuTaiLieu.soLuongMuon = short.Parse(txtSoLuongMuon.Text);
            if(ngayTra != null) newPhieuTaiLieu.ngayTra = DateTime.Parse(ngayTra);
            danhSachPhieuTaiLieu.Add(newPhieuTaiLieu);
            foreach (PhieuTaiLieuDTO phieuTaiLieu in danhSachPhieuTaiLieu)
            {
                dgvTaiLieuMuon.Rows.Add(phieuTaiLieu.taiLieu.MaTaiLieu, phieuTaiLieu.taiLieu.TenTaiLieu, phieuTaiLieu.soLuongMuon);
                Console.WriteLine(phieuTaiLieu.ngayTra);
                if (phieuTaiLieu.ngayTra.ToString().Equals("1/1/0001 12:00:00 AM")) 
                {
                    btnTraSach.Enabled = true;
                }
                else
                {
                    btnTraSach.Enabled = false;
                }
            }
        }

        private void txtMaDocGia_TextChanged(object sender, EventArgs e)
        {
            txtTenDocGia.Text = docGiaBUS.searchTenDocGia(txtMaDocGia.Text.ToString().Trim());
        }

        private void txtMaNhanVien_TextChanged_1(object sender, EventArgs e)
        {
            txtTenNhanVien.Text = nhanVienBUS.searchTenNhanVien(txtMaNhanVien.Text.ToString().Trim());
        }

        private void txtMaTaiLieu_TextChanged_1(object sender, EventArgs e)
        {
            txtTenTaiLieu.Text = taiLieuBUS.searchTenTaiLieu(txtMaTaiLieu.Text.ToString().Trim());
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            TaiLieuDTO taiLieu = taiLieuBUS.searchTaiLieu(txtMaTaiLieu.Text.ToString().Trim());
            if (taiLieu == null) return;
            PhieuTaiLieuDTO newPhieuTaiLieu = new PhieuTaiLieuDTO();
            newPhieuTaiLieu.soLuongMuon = short.Parse(txtSoLuongMuon.Text);
            newPhieuTaiLieu.taiLieu.MaTaiLieu = txtMaTaiLieu.Text;
            newPhieuTaiLieu.taiLieu.TenTaiLieu = txtTenTaiLieu.Text;
            danhSachPhieuTaiLieu.Add(newPhieuTaiLieu);
            dgvTaiLieuMuon.Rows.Clear();
            foreach (PhieuTaiLieuDTO phieuTaiLieu in danhSachPhieuTaiLieu)
            {
                dgvTaiLieuMuon.Rows.Add(phieuTaiLieu.taiLieu.MaTaiLieu, phieuTaiLieu.taiLieu.TenTaiLieu, phieuTaiLieu.soLuongMuon);
            }
            //this.LoadInit();
        }

        private void btn_Click_1(object sender, EventArgs e)
        {
            // Lưu button
            try
            {
                string maPhieuMuon = txtMaPhieuMuon.Text.ToString().Trim();
                string maDocGia = txtMaDocGia.Text.ToString().Trim();
                DateTime ngayMuon = txtNgayMuon.Value;
                string maNhanVien = txtMaNhanVien.Text.ToString().Trim();

                PhieuMuonDTO newPhieuMuon = new PhieuMuonDTO(maPhieuMuon, maDocGia, maNhanVien, ngayMuon);
                newPhieuMuon.DanhSachPhieuTaiLieu = danhSachPhieuTaiLieu;
                phieuMuonBUS.addNewData(newPhieuMuon);
                this.LoadInit();
            }
            catch (Exception expect) {
                MessageBox.Show(expect.Message, "Có lỗi");
            }
            dgvTaiLieuMuon.Rows.Clear();
            danhSachPhieuTaiLieu.Clear();
            
        }

        private void btnNhapLai_Click(object sender, EventArgs e)
        {
            txtMaTaiLieu.Enabled = true;
            txtMaPhieuMuon.Enabled = true;
            txtMaPhieuMuon.Text = "";
            txtMaDocGia.Text = "";
            txtNgayMuon.Value = DateTime.Today;
            txtMaNhanVien.Text = "";
            txtMaTaiLieu.Text = "";
            txtSoLuongMuon.Text = "";

            dgvTaiLieuMuon.Rows.Clear();
            danhSachPhieuTaiLieu.Clear();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            Graphics myGraphics = this.CreateGraphics();
            Size s = this.Size;
            bm = new Bitmap(s.Width, s.Height, myGraphics);
            Graphics mg = Graphics.FromImage(bm);
            mg.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, this.Size);

            printDocument1.Print();
        }

        private void btnTraSach_Click(object sender, EventArgs e)
        {
            PhieuMuonDTO currentPhieuMuuon = phieuMuonBUS.getPhieuByMa(txtMaPhieuMuon.Text, txtMaTaiLieu.Text);
            for( int i = 0; i < currentPhieuMuuon.DanhSachPhieuTaiLieu.Count; i++)
            {
                currentPhieuMuuon.DanhSachPhieuTaiLieu[i].ngayTra = DateTime.Now;
            }
            phieuMuonBUS.traSach(currentPhieuMuuon);
            this.LoadInit();
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            this.LoadInit();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string maPhieuMuon = txtMaPhieuMuon.Text.ToString().Trim();
            dgvTaiLieuDangMuon.DataSource = phieuMuonBUS.getDataFromSource(maPhieuMuon);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try { 
                string maPhieuMuon = txtMaPhieuMuon.Text.ToString().Trim();
                string maDocGia = txtMaDocGia.Text.ToString().Trim();
                DateTime ngayMuon = txtNgayMuon.Value;
                string maNhanVien = txtMaNhanVien.Text.ToString().Trim();

                PhieuMuonDTO phieuMuon = new PhieuMuonDTO(maPhieuMuon, maDocGia, maNhanVien, ngayMuon);

                PhieuTaiLieuDTO newPhieuTaiLieu = new PhieuTaiLieuDTO();
                newPhieuTaiLieu.taiLieu.MaTaiLieu = txtMaTaiLieu.Text;
                newPhieuTaiLieu.taiLieu.TenTaiLieu = txtTenTaiLieu.Text;
                try
                {
                    newPhieuTaiLieu.soLuongMuon = short.Parse(txtSoLuongMuon.Text);
                }
                catch(Exception)
                {
                    MessageBox.Show("Vượt quá số lượng");
                    return;
                }
                danhSachPhieuTaiLieu.Clear();
                danhSachPhieuTaiLieu.Add(newPhieuTaiLieu);
                phieuMuon.DanhSachPhieuTaiLieu = danhSachPhieuTaiLieu;
                phieuMuonBUS.updateData(phieuMuon);
                this.LoadInit();
            }
            catch (Exception expect) {
                MessageBox.Show(expect.Message, "Có lỗi");
            }
            
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                var result = MessageBox.Show("Xác nhận xóa phiếu mượn", "Cảnh báo", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    string maPhieuMuon = txtMaPhieuMuon.Text.ToString().Trim();
                    string maTaiLieu = txtMaTaiLieu.Text.ToString().Trim();
                    PhieuMuonDTO currentPhieuMuuon = phieuMuonBUS.getPhieuByMa(maPhieuMuon, maTaiLieu);
                    Boolean isSuccess = phieuMuonBUS.deleteTaiLieuPhieuByMa(currentPhieuMuuon);
                    this.LoadInit();
                }

            }
            catch (Exception expect)
            {
                MessageBox.Show(expect.Message, "Có lỗi");
            }
            
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void dgvTaiLieuMuon_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            txtMaTaiLieu.Text = dgvTaiLieuMuon.Rows[e.RowIndex].Cells[0].Value.ToString().Trim();
            txtTenTaiLieu.Text = dgvTaiLieuMuon.Rows[e.RowIndex].Cells[1].Value.ToString().Trim();
            txtSoLuongMuon.Text = dgvTaiLieuMuon.Rows[e.RowIndex].Cells[2].Value.ToString().Trim();
            
            PhieuTaiLieuDTO newPhieuTaiLieu = new PhieuTaiLieuDTO();
        }
    }
}
