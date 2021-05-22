using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class PhieuMuonDAL
    {
        private string maPhieuMuon;
        private string maDocGia;
        private string ngayMuon;
        private string maNhanVien;

        public PhieuMuonDAL(string maPhieuMuon, string maDocGia, string ngayMuon, string maNhanVien)
        {
            this.maPhieuMuon = maPhieuMuon;
            this.maDocGia = maDocGia;
            this.ngayMuon = ngayMuon;
            this.maNhanVien = maNhanVien;
        }
    }
}
