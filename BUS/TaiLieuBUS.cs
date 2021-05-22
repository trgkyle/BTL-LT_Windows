using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BUS
{
    public class TaiLieuBUS
    {
        TaiLieuDAL theLoaiDB = new TaiLieuDAL();
        public Object getDataFromSource()
        {
            return theLoaiDB.loadFromDB();
        }

        public Boolean addNewData(TaiLieuDTO newTaiLieu)
        {
            theLoaiDB.AddNewToDB(newTaiLieu);
            return true;
        }
    }
}
