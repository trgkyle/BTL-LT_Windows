using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class PhieuMuonDAL
    {
        dbDataContext data = new dbDataContext();

        public Object loadFromDB()
        {
            return data.PhieuMuonChiTiets.Join(data.TaiLieus, pmct => pmct.MaTaiLieu, tl => tl.MaTaiLieu, (pmct, tl) => new { pmct.MaTaiLieu, tl.TenTaiLieu, pmct.SoLuongMuon}).Select(x => x);
        }
        public Boolean SaveToDB(PhieuMuonDTO newPhieuMuon)
        {
            // check if doc gia exist
            PhieuMuon phieuMuonORM = new PhieuMuon();
            phieuMuonORM.MaPhieuMuon = newPhieuMuon.MaPhieuMuon;
            phieuMuonORM.MaDocGia = newPhieuMuon.MaDocGia;
            var docGias = data.PhieuMuons.Single(x => x.MaPhieuMuon == phieuMuonORM.MaPhieuMuon);
            if (docGias.MaPhieuMuon.Length > 0)
            {
                // update 
                try
                {
                    this.UpdateToDB(newPhieuMuon);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }

            }
            else
            {
                // create
                try
                {
                    this.AddNewToDB(newPhieuMuon);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }

        }

        public Boolean AddNewToDB(PhieuMuonDTO newPhieuMuon)
        {
            PhieuMuon phieuMuonORM = new PhieuMuon();
            phieuMuonORM.MaPhieuMuon = newPhieuMuon.MaPhieuMuon;
            phieuMuonORM.MaDocGia = newPhieuMuon.MaDocGia;
            phieuMuonORM.NgayMuon = newPhieuMuon.NgayMuon;
            phieuMuonORM.MaNhanVien = newPhieuMuon.MaNhanVien;

            PhieuMuonChiTiet phieuMuonChiTietORM = new PhieuMuonChiTiet();
            phieuMuonChiTietORM.MaPhieuMuon = newPhieuMuon.MaPhieuMuon;
            phieuMuonChiTietORM.MaTaiLieu = newPhieuMuon.MaTaiLieu;
            phieuMuonChiTietORM.SoLuongMuon = newPhieuMuon.SoLuongMuon;
            data.PhieuMuons.InsertOnSubmit(phieuMuonORM);
            data.PhieuMuonChiTiets.InsertOnSubmit(phieuMuonChiTietORM);
            data.SubmitChanges();
            
            
            return true;
        }

        public Boolean UpdateToDB(PhieuMuonDTO phieuMuon)
        {
            var line = data.PhieuMuons.Single(x => x.MaPhieuMuon == phieuMuon.MaPhieuMuon);
            line.MaPhieuMuon = phieuMuon.MaPhieuMuon;
            line.MaDocGia = phieuMuon.MaDocGia;
            line.NgayMuon = phieuMuon.NgayMuon;
            line.MaNhanVien = phieuMuon.MaNhanVien;
            data.SubmitChanges();
            return true;
        }
    }
}
