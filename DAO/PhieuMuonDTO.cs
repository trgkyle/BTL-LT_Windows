using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class PhieuMuonDTO
    {
        private string maPhieuMuon;
        private string maDocGia;
        private DateTime ngayMuon;
        private string maNhanVien;

        private PhieuTaiLieuDTO phieuTaiLieu;
        private DateTime ngayTra;

        List<PhieuTaiLieuDTO> danhSachPhieuTaiLieu = new List<PhieuTaiLieuDTO>();

        public PhieuMuonDTO(string maPhieuMuon, string maDocGia, string maNhanVien, DateTime ngayMuon)
        {
            NgayTra = ngayTra;
            MaPhieuMuon = maPhieuMuon;
            MaDocGia = maDocGia;
            NgayMuon = ngayMuon;
            MaNhanVien = maNhanVien;
            //NgayTra = ngayTra;
        }

        public string MaPhieuMuon { get => maPhieuMuon; set => maPhieuMuon = value; }
        public string MaDocGia { get => maDocGia; set => maDocGia = value; }
        public DateTime NgayMuon { get => ngayMuon; set => ngayMuon = value; }
        public string MaNhanVien { get => maNhanVien; set => maNhanVien = value; }
        public DateTime NgayTra { get => ngayTra; set => ngayTra = value; }
        public List<PhieuTaiLieuDTO> DanhSachPhieuTaiLieu { get => danhSachPhieuTaiLieu; set => danhSachPhieuTaiLieu = value; }
        internal PhieuTaiLieuDTO PhieuTaiLieu { get => phieuTaiLieu; set => phieuTaiLieu = value; }
    }
}
