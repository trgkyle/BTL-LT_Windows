using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BUS
{
    public class TaiLieuBUS
    {
        TaiLieuDAL taiLieuDAL = new TaiLieuDAL();
        public Object getDataFromSource()
        {
            return taiLieuDAL.loadFromDB();
        }

        public Boolean addNewData(TaiLieuDTO newTaiLieu)
        {
            taiLieuDAL.AddNewToDB(newTaiLieu);
            return true;
        }

        public String searchTenTaiLieu(string maTaiLieu)
        {
            return taiLieuDAL.TimTenTaiLieuVoiMa(maTaiLieu);
        }
        public TaiLieuDTO searchTaiLieu(string maTaiLieu)
        {
            if(this.searchTenTaiLieu(maTaiLieu).Length > 0)
                return taiLieuDAL.TimTaiLieuVoiMa(maTaiLieu);
            else
            {
                return null;
            }
        }
    }
}
