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

        public string TimTenDocGiaVoiMa(string maDocGia)
        {
            data = new dbDataContext();

            try
            { 
                var docGia = data.DocGias.Single(x => x.MaDocGia == maDocGia);
                return docGia.HoTen;
            }
            catch (Exception)
            {
                return "";
            }
        }
        public Boolean SaveToDB(DocGiaDTO newDocGia)
        {
            data = new dbDataContext();

            // check if doc gia exist
            DocGia docGiaORM = new DocGia();
            //docGiaORM.MaDocGia = newDocGia.;
            docGiaORM.HoTen = newDocGia.HoTen;
            docGiaORM.GioiTinh = newDocGia.GioiTinh;
            docGiaORM.NgaySinh = DateTime.Parse(newDocGia.NgaySinh);
            docGiaORM.MaDoiTuong = newDocGia.MaDoiTuong;
            docGiaORM.NgayCap = DateTime.Parse(newDocGia.NgayCap);
            docGiaORM.NgayHetHan = DateTime.Parse(newDocGia.NgayHetHan);
            var docGias = data.DocGias.Single(x => x.MaDocGia == docGiaORM.MaDocGia);
            if (docGias.MaDoiTuong.Length > 0)
            {
                // update 
                try { 
                    this.UpdateToDB(newDocGia);
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
                    this.AddNewToDB(newDocGia);
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
            data = new dbDataContext();

            DocGia docGiaORM = new DocGia();
            docGiaORM.MaDocGia = newDocGia.MaDocGia;
            docGiaORM.HoTen = newDocGia.HoTen;
            docGiaORM.GioiTinh = newDocGia.GioiTinh;
            docGiaORM.NgaySinh = DateTime.Parse(newDocGia.NgaySinh);
            docGiaORM.MaDoiTuong = newDocGia.MaDoiTuong;
            docGiaORM.NgayCap = DateTime.Parse(newDocGia.NgayCap);
            docGiaORM.NgayHetHan = DateTime.Parse(newDocGia.NgayHetHan);
            data.DocGias.InsertOnSubmit(docGiaORM);
            data.SubmitChanges();
            return true;
        }

        public Boolean UpdateToDB(DocGiaDTO docGia)
        {
            data = new dbDataContext();

            var line = data.DocGias.Single(x => x.MaDocGia == docGia.MaDocGia);

            line.MaDocGia = docGia.MaDocGia;
            line.HoTen = docGia.HoTen;
            line.GioiTinh = docGia.GioiTinh;
            line.NgaySinh = DateTime.Parse(docGia.NgaySinh);
            line.MaDoiTuong = docGia.MaDoiTuong;
            line.NgayCap = DateTime.Parse(docGia.NgayCap);
            line.NgayHetHan = DateTime.Parse(docGia.NgayHetHan);
            data.SubmitChanges();
            return true;
        }

    }
}
