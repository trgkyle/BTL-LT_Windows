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

        private string maTaiLieu;
        private short soLuongMuon;
        private DateTime ngayTra;

        public PhieuMuonDTO(string maPhieuMuon, string maDocGia, DateTime ngayMuon, string maNhanVien, string maTaiLieu, short soLuongMuon)
        {
            NgayTra = ngayTra;
            MaPhieuMuon = maPhieuMuon;
            MaDocGia = maDocGia;
            NgayMuon = ngayMuon;
            MaNhanVien = maNhanVien;
            MaTaiLieu = maTaiLieu;
            SoLuongMuon = soLuongMuon;
            //NgayTra = ngayTra;
        }

        public string MaPhieuMuon { get => maPhieuMuon; set => maPhieuMuon = value; }
        public string MaDocGia { get => maDocGia; set => maDocGia = value; }
        public DateTime NgayMuon { get => ngayMuon; set => ngayMuon = value; }
        public string MaNhanVien { get => maNhanVien; set => maNhanVien = value; }
        public string MaTaiLieu { get => maTaiLieu; set => maTaiLieu = value; }
        public short SoLuongMuon { get => soLuongMuon; set => soLuongMuon = value; }
        public DateTime NgayTra { get => ngayTra; set => ngayTra = value; }
    }
}
