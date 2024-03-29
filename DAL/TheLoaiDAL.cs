﻿using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class TheLoaiDAL
    {
        dbDataContext data = new dbDataContext();

        public Object loadFromDB()
        {
            data = new dbDataContext();

            return data.TheLoais.Select(x => x).Select(x => new { x.MaTheLoai, x.TenTheLoai, x.GhiChu });
        }

        public Object loadFromDB(String maTheLoai)
        {
            data = new dbDataContext();

            return data.TheLoais.Where(x => x.MaTheLoai == maTheLoai).Select(x => x).Select(x => new { x.MaTheLoai, x.TenTheLoai, x.GhiChu });
        }

        
        public Boolean SaveToDB(TheLoaiDTO newTheLoai)
        {
            data = new dbDataContext();

            // check if doc gia exist
            TaiLieu taiLieuORM = new TaiLieu();
            taiLieuORM.MaTaiLieu = newTheLoai.MaTheLoai;
            taiLieuORM.TenTaiLieu = newTheLoai.TenTheLoai;
            var docGias = data.TaiLieus.Single(x => x.MaTheLoai == taiLieuORM.MaTheLoai);
            if (docGias.MaTaiLieu.Length > 0)
            {
                // update 
                try
                {
                    this.UpdateToDB(newTheLoai);
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
                    this.AddNewToDB(newTheLoai);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }

        }

        public Boolean AddNewToDB(TheLoaiDTO newTheLoai)
        {
            data = new dbDataContext();

            TheLoai theLoaiORM = new TheLoai();
            theLoaiORM.MaTheLoai = newTheLoai.MaTheLoai;
            theLoaiORM.TenTheLoai = newTheLoai.TenTheLoai;
            theLoaiORM.GhiChu = newTheLoai.GhiChu;
            data.TheLoais.InsertOnSubmit(theLoaiORM);
            try { 
                data.SubmitChanges();
            }
            catch(Exception expect)
            {
                throw new Exception("Lỗi trùng mã thể loại");
            }
            return true;
        }

        public Boolean UpdateToDB(TheLoaiDTO theLoai)
        {
            data = new dbDataContext();

            var line = data.TheLoais.Single(x => x.MaTheLoai == theLoai.MaTheLoai);
            line.TenTheLoai = theLoai.TenTheLoai;
            line.GhiChu = theLoai.GhiChu;
            data.SubmitChanges();
            return true;
        }

        public Boolean DeleteToDB(String maTheLoai)
        {
            data = new dbDataContext();

            var line = data.TheLoais.Single(x => x.MaTheLoai == maTheLoai);
            data.TheLoais.DeleteOnSubmit(line);
            try
            {
                data.SubmitChanges();
            }
            catch (Exception expect)
            {
                throw new Exception("Lỗi không thể xóa, thể loại này đang được sử dụng");
            }
            return true;
        }
    }
}
