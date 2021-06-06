using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BUS
{
    public class PhieuMuonBUS
    {
        PhieuMuonDAL phieuMuonDB = new PhieuMuonDAL();
        public Object getDataFromSource(String maPhieuMuon)
        {
            return phieuMuonDB.LoadFromDB(maPhieuMuon);
        }
        public Object getDataFromSource()
        {
            return phieuMuonDB.LoadFromDB();
        }

        public PhieuMuonDTO getPhieuByMa(string maPhieuMuon, string maSach)
        {
            return phieuMuonDB.getPhieuMuonByMa(maPhieuMuon, maSach);
        }

        public Boolean addNewData(PhieuMuonDTO newPhieuMuon)
        {
            phieuMuonDB.AddNewToDB(newPhieuMuon);
            return true;
        }

        public Boolean updateData(PhieuMuonDTO phieuMuon)
        {
            phieuMuonDB.UpdateToDB(phieuMuon);
            return true;
        }
        public Boolean traSach(PhieuMuonDTO phieuMuon)
        {
            phieuMuonDB.traSach(phieuMuon);
            return true;
        }

        public Object getThongKe(DateTime fromParams, DateTime to)
        {
            DateTime from = fromParams;
            if(from == null)
            {
                from = DateTime.MinValue;
            }
            return phieuMuonDB.LoadThongKe(from,to);
        }

        public Boolean deleteTaiLieuPhieuByMa(PhieuMuonDTO phieuMuon)
        {
            return phieuMuonDB.deletePhieuByMa(phieuMuon);
        }
    }
}
