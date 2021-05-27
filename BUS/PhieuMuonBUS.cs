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
        public Object getDataFromSource()
        {
            return phieuMuonDB.LoadFromDB();
        }

        public Boolean addNewData(PhieuMuonDTO newPhieuMuon)
        {
            phieuMuonDB.AddNewToDB(newPhieuMuon);
            return true;
        }
    }
}
