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
            cbxTheLoai.DataSource = theLoaiBUS.getDataFromSource();
            cbxTheLoai.DisplayMember = "TenTheLoai";
            cbxTheLoai.ValueMember = "MaTheLoai";
        }

        private void QLDanhMuc_Load(object sender, EventArgs e)
        {
            this.LoadInit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string maTaiLieu = txtMaTaiLieu.Text.ToString();
            string tenTaiLieu = txtTenTaiLieu.Text.ToString();
            string maTheLoai = cbxTheLoai.SelectedValue.ToString();
            string soLuong = txtSoLuong.Text.ToString();
            string nhaXuatBan = txtNhaXuatBan.Text.ToString();
            string namXuatBan = txtNamXuatBan.Text.ToString();
            string tacGia = txtTacGia.Text.ToString();

            TaiLieuDTO newTaiLieu = new TaiLieuDTO(maTaiLieu, tenTaiLieu, maTheLoai, short.Parse(soLuong), nhaXuatBan, short.Parse(namXuatBan), tacGia);
            try { 
                taiLieuBUS.addNewData(newTaiLieu);
            }
            catch(Exception expect)
            {
                MessageBox.Show(expect.Message);
            }
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
            try
            {
                theLoaiBUS.addNewData(newTheLoai);
            }
            catch (Exception expect)
            {
                MessageBox.Show(expect.Message);
            }
            this.LoadInit();
        }

        private void dgvTLieu_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            txtMaTaiLieu.Enabled = false;
            txtMaTaiLieu.Text = dgvTLieu.Rows[e.RowIndex].Cells[0].Value.ToString().Trim();
            txtTenTaiLieu.Text = dgvTLieu.Rows[e.RowIndex].Cells[1].Value.ToString().Trim();
            cbxTheLoai.SelectedValue = dgvTLieu.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtSoLuong.Text = dgvTLieu.Rows[e.RowIndex].Cells[3].Value.ToString().Trim();
            txtNhaXuatBan.Text = dgvTLieu.Rows[e.RowIndex].Cells[4].Value.ToString().Trim();
            txtNamXuatBan.Text = dgvTLieu.Rows[e.RowIndex].Cells[5].Value.ToString().Trim();
            txtTacGia.Text = dgvTLieu.Rows[e.RowIndex].Cells[6].Value.ToString().Trim();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtMaTaiLieu.Enabled = true;
            txtMaTaiLieu.Text = "";
            txtTenTaiLieu.Text = "";
            
            txtSoLuong.Text = "";
            txtNhaXuatBan.Text = "";
            txtNamXuatBan.Text = "";
            txtTacGia.Text = "";
        }

        private void dgvTLoai_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            txtMaTheLoai2.Enabled = false;
            txtMaTheLoai2.Text = dgvTLoai.Rows[e.RowIndex].Cells[0].Value.ToString().Trim();
            txtTenTheLoai2.Text = dgvTLoai.Rows[e.RowIndex].Cells[1].Value.ToString().Trim();
            txtGhiChu2.Text = dgvTLoai.Rows[e.RowIndex].Cells[2].Value.ToString().Trim();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            txtMaTheLoai2.Enabled = true;
            txtMaTheLoai2.Text = "";
            txtTenTheLoai2.Text = "";
            txtGhiChu2.Text = "";
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            this.LoadInit();
        }

        private void btnXem2_Click(object sender, EventArgs e)
        {
            this.LoadInit();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try {
                var result = MessageBox.Show("Xác nhận xóa tài liệu", "Cảnh báo", MessageBoxButtons.YesNo);
                if(result == DialogResult.Yes)
                {
                    string maTaiLieu = txtMaTaiLieu.Text.ToString();
                    taiLieuBUS.deleteData(maTaiLieu);
                    this.LoadInit();
                }
                
            }
            catch(Exception expect)
            {
                MessageBox.Show(expect.Message, "Có lỗi");
            }
        }

        private void btnXoa2_Click(object sender, EventArgs e)
        {
            
            try
            {
                var result = MessageBox.Show("Xác nhận xóa thể loại", "Cảnh báo", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    string maTheLoai = txtMaTheLoai2.Text.ToString();
                    theLoaiBUS.deleteData(maTheLoai);
                    this.LoadInit();
                }

            }
            catch (Exception expect)
            {
                MessageBox.Show(expect.Message, "Có lỗi");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string maTaiLieu = txtMaTaiLieu.Text.ToString();
            string tenTaiLieu = txtTenTaiLieu.Text.ToString();
            string maTheLoai = cbxTheLoai.SelectedValue.ToString();
            string soLuong = txtSoLuong.Text.ToString();
            string nhaXuatBan = txtNhaXuatBan.Text.ToString();
            string namXuatBan = txtNamXuatBan.Text.ToString();
            string tacGia = txtTacGia.Text.ToString();

            TaiLieuDTO taiLieu = new TaiLieuDTO(maTaiLieu, tenTaiLieu, maTheLoai, short.Parse(soLuong), nhaXuatBan, short.Parse(namXuatBan), tacGia);
            taiLieuBUS.updateData(taiLieu);
            this.LoadInit();
        }

        private void btnSua2_Click(object sender, EventArgs e)
        {
            string maTheLoai = txtMaTheLoai2.Text.ToString();
            string tenTheLoai = txtTenTheLoai2.Text.ToString();
            string ghiChu = txtGhiChu2.Text.ToString();

            TheLoaiDTO theLoai = new TheLoaiDTO(maTheLoai, tenTheLoai, ghiChu);
            theLoaiBUS.updateData(theLoai);
            this.LoadInit();
        }

        private void btmTim2_Click(object sender, EventArgs e)
        {
            string maTheLoai = txtMaTheLoai2.Text.ToString();
            dgvTLoai.DataSource = theLoaiBUS.getDataFromSource(maTheLoai);
        }

        private void btmTim_Click(object sender, EventArgs e)
        {
            string maTaiLieu = txtMaTaiLieu.Text.ToString();
            dgvTLieu.DataSource = taiLieuBUS.getDataFromSource(maTaiLieu);
        }
    }
}
