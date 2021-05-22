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

        public Boolean addNewData(TheLoaiDTO newTaiLieu)
        {
            theLoaiDB.AddNewToDB(newTaiLieu);
            return true;
        }
    }
}
