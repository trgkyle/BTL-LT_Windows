using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class TaiLieuDAL
    {
        dbDataContext data = new dbDataContext();

        public Object loadFromDB()
        {
            return data.TaiLieus.Select(x => x).Select(x => new {x.MaTaiLieu, x.TenTaiLieu,x.MaTheLoai, x.SoLuong, x.NhaXuatBan,x.NamXuatBan,x.TacGia });
        }
        public Boolean SaveToDB(TaiLieuDTO newTaiLieu)
        {
            // check if doc gia exist
            TaiLieu taiLieuORM = new TaiLieu();
            taiLieuORM.MaTaiLieu = newTaiLieu.MaTaiLieu;
            taiLieuORM.TenTaiLieu = newTaiLieu.TenTaiLieu;
            taiLieuORM.MaTheLoai = newTaiLieu.MaTheLoai;
            taiLieuORM.SoLuong = newTaiLieu.SoLuong;
            taiLieuORM.NhaXuatBan = newTaiLieu.NhaXuatBan;
            taiLieuORM.NamXuatBan = newTaiLieu.NamXuatBan;
            taiLieuORM.TacGia = newTaiLieu.TacGia;
            var docGias = data.TaiLieus.Single(x => x.MaTaiLieu == taiLieuORM.MaTaiLieu);
            if (docGias.MaTaiLieu.Length > 0)
            {
                // update 
                try
                {
                    this.UpdateToDB(newTaiLieu);
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
                    this.AddNewToDB(newTaiLieu);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }

        }

        public Boolean AddNewToDB(TaiLieuDTO newTaiLieu)
        {
            TaiLieu taiLieuORM = new TaiLieu();
            taiLieuORM.MaTaiLieu = newTaiLieu.MaTaiLieu;
            taiLieuORM.TenTaiLieu = newTaiLieu.TenTaiLieu;
            taiLieuORM.MaTheLoai = newTaiLieu.MaTheLoai;
            taiLieuORM.SoLuong = newTaiLieu.SoLuong;
            taiLieuORM.NhaXuatBan = newTaiLieu.NhaXuatBan;
            taiLieuORM.NamXuatBan = newTaiLieu.NamXuatBan;
            taiLieuORM.TacGia = newTaiLieu.TacGia;
            data.TaiLieus.InsertOnSubmit(taiLieuORM);
            data.SubmitChanges();
            return true;
        }

        public Boolean UpdateToDB(TaiLieuDTO taiLieu)
        {
            var line = data.TaiLieus.Single(x => x.MaTaiLieu == taiLieu.MaTaiLieu);

            line.MaTaiLieu = taiLieu.MaTaiLieu;
            line.TenTaiLieu = taiLieu.TenTaiLieu;
            line.MaTheLoai = taiLieu.MaTheLoai;
            line.SoLuong = taiLieu.SoLuong;
            line.NhaXuatBan = taiLieu.NhaXuatBan;
            line.NamXuatBan = taiLieu.NamXuatBan;
            line.TacGia = taiLieu.TacGia;
            data.SubmitChanges();
            return true;
        }

    }
}
