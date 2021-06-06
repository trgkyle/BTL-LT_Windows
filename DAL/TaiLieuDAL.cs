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

        public string TimTenTaiLieuVoiMa(string maTaiLieu)
        {
            data = new dbDataContext();

            try
            {
                var taiLieu = data.TaiLieus.Single(x => x.MaTaiLieu == maTaiLieu);
                return taiLieu.TenTaiLieu;
            }
            catch (Exception)
            {
                return "";
            }
        }
        public TaiLieuDTO TimTaiLieuVoiMa(string maTaiLieu)
        {
            data = new dbDataContext();

            try
            {
                var taiLieu = data.TaiLieus.Single(x => x.MaTaiLieu == maTaiLieu);
                TaiLieuDTO newTaiLieu = new TaiLieuDTO(taiLieu.MaTaiLieu, taiLieu.TenTaiLieu, taiLieu.MaTheLoai, short.Parse(taiLieu.SoLuong.ToString()), taiLieu.NhaXuatBan, short.Parse(taiLieu.NamXuatBan.ToString()),taiLieu.TacGia);

                return newTaiLieu;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public Object loadFromDB()
        {
            data = new dbDataContext();

            return data.TaiLieus
                .Select(x => new {x.MaTaiLieu, x.TenTaiLieu,x.MaTheLoai, x.SoLuong, x.NhaXuatBan,x.NamXuatBan,x.TacGia });
        }
        public Object loadFromDB(String maTaiLieu)
        {
            data = new dbDataContext();

            return data.TaiLieus
                .Where(x => x.MaTaiLieu == maTaiLieu)
                .Select(x => new { x.MaTaiLieu, x.TenTaiLieu, x.MaTheLoai, x.SoLuong, x.NhaXuatBan, x.NamXuatBan, x.TacGia });
        }

        public Boolean SaveToDB(TaiLieuDTO newTaiLieu)
        {
            data = new dbDataContext();

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
            data = new dbDataContext();

            TaiLieu taiLieuORM = new TaiLieu();
            taiLieuORM.MaTaiLieu = newTaiLieu.MaTaiLieu;
            taiLieuORM.TenTaiLieu = newTaiLieu.TenTaiLieu;
            taiLieuORM.MaTheLoai = newTaiLieu.MaTheLoai;
            taiLieuORM.SoLuong = newTaiLieu.SoLuong;
            taiLieuORM.NhaXuatBan = newTaiLieu.NhaXuatBan;
            taiLieuORM.NamXuatBan = newTaiLieu.NamXuatBan;
            taiLieuORM.TacGia = newTaiLieu.TacGia;
            data.TaiLieus.InsertOnSubmit(taiLieuORM);
            try { 
                data.SubmitChanges();
            }
            catch(Exception expect)
            {
                throw new Exception("Lỗi trùng mã tài liệu");
            }
            return true;
        }

        public Boolean UpdateToDB(TaiLieuDTO taiLieu)
        {
            data = new dbDataContext();

            var line = data.TaiLieus.Single(x => x.MaTaiLieu == taiLieu.MaTaiLieu);

            line.TenTaiLieu = taiLieu.TenTaiLieu;
            line.MaTheLoai = taiLieu.MaTheLoai;
            line.SoLuong = taiLieu.SoLuong;
            line.NhaXuatBan = taiLieu.NhaXuatBan;
            line.NamXuatBan = taiLieu.NamXuatBan;
            line.TacGia = taiLieu.TacGia;
            data.SubmitChanges();
            return true;
        }

        public Boolean DeleteToDB(String maTaiLieu)
        {
            data = new dbDataContext();

            var line = data.TaiLieus.Single(x => x.MaTaiLieu == maTaiLieu);
            try { 
                data.TaiLieus.DeleteOnSubmit(line);
                data.SubmitChanges();
            }
            catch(Exception expect)
            {
                throw new Exception("Lỗi không thể xóa, tài liệu này đang được sử dụng");
            }
            return true;
        }

    }
}
