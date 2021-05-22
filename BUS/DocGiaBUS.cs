using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BUS
{
    public class DocGiaBUS
    {
        DocGiaDAL docGiaDB = new DocGiaDAL();

        public String searchTenDocGia(string maDocGia)
        {
            return docGiaDB.TimTenDocGiaVoiMa(maDocGia);
        }
    }
}
