using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace DAL
{
    public class DocGiaDAL
    {
        dbDataContext data = new dbDataContext();

        public Boolean SaveToDB(DocGiaDTO newDocGia)
        {
            // check if doc gia exist
            DocGia docGiaORM = new DocGia();
            //docGiaORM.MaDocGia = newDocGia.;
            docGiaORM.HoTen = newDocGia.HoTen;
            docGiaORM.GioiTinh = newDocGia.GioiTinh;
            docGiaORM.NgaySinh = newDocGia.NgaySinh;
            docGiaORM.MaDoiTuong = newDocGia.MaDoiTuong;
            docGiaORM.NgayCap = newDocGia.NgayCap;
            docGiaORM.NgayHetHan = newDocGia.NgayHetHan;
            var docGias = data.DocGias.Single(x => x.MaDocGia == docGiaORM.MaDocGia);
            if (docGias.MaDoiTuong.Length > 0)
            {
                // update 
                try { 
                    this.updateToDB(newDocGia);
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
                    this.addNewToDB(newDocGia);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            
        }

        public Boolean AddNewToDB(DocGiaDTO newDocGia)
        {
            DocGia docGiaORM = new DocGia();
            docGiaORM.MaDocGia = newDocGia.MaDocGia;
            docGiaORM.HoTen = newDocGia.HoTen;
            docGiaORM.GioiTinh = newDocGia.GioiTinh;
            docGiaORM.NgaySinh = newDocGia.NgaySinh;
            docGiaORM.MaDoiTuong = newDocGia.MaDoiTuong;
            docGiaORM.NgayCap = newDocGia.NgayCap;
            docGiaORM.NgayHetHan = newDocGia.NgayHetHan;
            data.DocGias.InsertOnSubmit(docGiaORM);
            data.SubmitChanges();
            return true;
        }

        public Boolean UpdateToDB(DocGiaDTO docGia)
        {
            var line = data.DocGias.Single(x => x.MaDocGia == docGia.MaDocGia);

            line.MaDocGia = docGia.MaDocGia;
            line.HoTen = docGia.HoTen;
            line.GioiTinh = docGia.GioiTinh;
            line.NgaySinh = docGia.NgaySinh;
            line.MaDoiTuong = docGia.MaDoiTuong;
            line.NgayCap = docGia.NgayCap;
            line.NgayHetHan = docGia.NgayHetHan;
            data.SubmitChanges();
            return true;
        }

    }
}
