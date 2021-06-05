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

        public TaiLieuDAL TaiLieuDAL { get => taiLieuDAL; set => taiLieuDAL = value; }

        public Object getDataFromSource()
        {
            return TaiLieuDAL.loadFromDB();
        }

        public Object getDataFromSource(String maTaiLieu)
        {
            return TaiLieuDAL.loadFromDB(maTaiLieu);
        }

        public Boolean addNewData(TaiLieuDTO newTaiLieu)
        {
            TaiLieuDAL.AddNewToDB(newTaiLieu);
            return true;
        }

        public Boolean updateData(TaiLieuDTO taiLieu)
        {
            TaiLieuDAL.UpdateToDB(taiLieu);
            return true;
        }

        public Boolean deleteData(String maTaiLieu)
        {
            TaiLieuDAL.DeleteToDB(maTaiLieu);
            return true;
        }

        public String searchTenTaiLieu(string maTaiLieu)
        {
            return TaiLieuDAL.TimTenTaiLieuVoiMa(maTaiLieu);
        }
        public TaiLieuDTO searchTaiLieu(string maTaiLieu)
        {
            if(this.searchTenTaiLieu(maTaiLieu).Length > 0)
                return TaiLieuDAL.TimTaiLieuVoiMa(maTaiLieu);
            else
            {
                return null;
            }
        }
    }
}
