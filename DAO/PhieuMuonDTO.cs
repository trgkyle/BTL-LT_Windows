using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class PhieuMuonDTO
    {
        private string maPhieuMuon;
        private string maDocGia;
        private string ngayMuon;
        private string maNhanVien;

        public PhieuMuonDTO(string maPhieuMuon, string maDocGia, string ngayMuon, string maNhanVien)
        {
            this.maPhieuMuon = maPhieuMuon;
            this.maDocGia = maDocGia;
            this.ngayMuon = ngayMuon;
            this.maNhanVien = maNhanVien;
        }
    }
}
