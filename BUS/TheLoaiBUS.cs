using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BUS
{
    public class TheLoaiBUS
    {
        TheLoaiDAL theLoaiDB = new TheLoaiDAL();
        public Object getDataFromSource()
        {
            return theLoaiDB.loadFromDB();
        }

        public Object getDataFromSource(String maTheLoai)
        {
            return theLoaiDB.loadFromDB(maTheLoai);
        }

        public Boolean addNewData(TheLoaiDTO newTaiLieu)
        {
            theLoaiDB.AddNewToDB(newTaiLieu);
            return true;
        }

        public Boolean updateData(TheLoaiDTO taiLieu)
        {
            theLoaiDB.UpdateToDB(taiLieu);
            return true;
        }

        public Boolean deleteData(String maTaiLieu)
        {
            theLoaiDB.DeleteToDB(maTaiLieu);
            return true;
        }
    }
}
