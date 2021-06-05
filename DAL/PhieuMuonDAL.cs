using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class PhieuMuonDAL
    {
        dbDataContext data = new dbDataContext();

        public Object LoadFromDB()
        {
            var danhSachTaiLieuMuon = data.PhieuMuonChiTiets.Join(data.PhieuMuons, pmct => pmct.MaPhieuMuon, pm => pm.MaPhieuMuon, (pmct, pm) => new { pmct.MaPhieuMuon, pm.MaDocGia, pm.NgayMuon, pm.MaNhanVien, pmct.MaTaiLieu, pmct.SoLuongMuon, pmct.NgayTra }).Select(x => x);
            return danhSachTaiLieuMuon;
        }
        public Object LoadFromDB(String maPhieuMuon)
        {
            var danhSachTaiLieuMuon = data.PhieuMuonChiTiets.Where(x => x.MaPhieuMuon == maPhieuMuon).Join(data.PhieuMuons, pmct => pmct.MaPhieuMuon, pm => pm.MaPhieuMuon, (pmct, pm) => new { pmct.MaPhieuMuon, pm.MaDocGia, pm.NgayMuon, pm.MaNhanVien, pmct.MaTaiLieu, pmct.SoLuongMuon, pmct.NgayTra }).Select(x => x);
            return danhSachTaiLieuMuon;
        }
        public Object LoadThongKe(DateTime from, DateTime to)
        {
            //var danhSachTaiLieuMuon = data.PhieuMuonChiTiets.Where(x => x.NgayTra >= from && x.NgayTra <= to).Join(data.PhieuMuons, pmct => pmct.MaPhieuMuon, pm => pm.MaPhieuMuon, (pmct, pm) => new { pmct.MaPhieuMuon, pm.MaDocGia, pm.NgayMuon, pm.MaNhanVien, pmct.MaTaiLieu, pmct.SoLuongMuon }).Select(x => x);
            var ThongKe = data.PhieuMuonChiTiets
                .Join(data.PhieuMuons, pmct => pmct.MaPhieuMuon, pm => pm.MaPhieuMuon, (pmct, pm) => new { pmct.MaTaiLieu, pmct.SoLuongMuon, pm.NgayMuon })
                .Where(x => x.NgayMuon >= from && x.NgayMuon <= to)
                .Join(data.TaiLieus, pmct => pmct.MaTaiLieu, tl => tl.MaTaiLieu, (pmct, tl) => new { pmct.SoLuongMuon, tl.MaTheLoai })
                .GroupBy(x => x.MaTheLoai)
                .Select(x => new { MaTheLoai = x.Key, SoLuongMuon = x.Sum(item => item.SoLuongMuon)})
                .Join(data.TheLoais, tlieu => tlieu.MaTheLoai, tloai => tloai.MaTheLoai, (tlieu, tloai) => new { tlieu.SoLuongMuon, tlieu.MaTheLoai, tloai.TenTheLoai });

            return ThongKe;
        }
        public Boolean SaveToDB(PhieuMuonDTO newPhieuMuon)
        {
            // check if doc gia exist
            PhieuMuon phieuMuonORM = new PhieuMuon();
            phieuMuonORM.MaPhieuMuon = newPhieuMuon.MaPhieuMuon;
            phieuMuonORM.MaDocGia = newPhieuMuon.MaDocGia;
            var docGias = data.PhieuMuons.Single(x => x.MaPhieuMuon == phieuMuonORM.MaPhieuMuon);
            if (docGias.MaPhieuMuon.Length > 0)
            {
                // update 
                try
                {
                    this.UpdateToDB(newPhieuMuon);
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
                    this.AddNewToDB(newPhieuMuon);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }

        }

        public Boolean AddNewToDB(PhieuMuonDTO newPhieuMuon)
        {
            PhieuMuon phieuMuonORM = new PhieuMuon();
            phieuMuonORM.MaPhieuMuon = newPhieuMuon.MaPhieuMuon;
            phieuMuonORM.MaDocGia = newPhieuMuon.MaDocGia;
            phieuMuonORM.NgayMuon = newPhieuMuon.NgayMuon;
            phieuMuonORM.MaNhanVien = newPhieuMuon.MaNhanVien;
            
            foreach(PhieuTaiLieuDTO phieuTaiLieu in newPhieuMuon.DanhSachPhieuTaiLieu)
            {
                PhieuMuonChiTiet phieuMuonChiTietORM = new PhieuMuonChiTiet();
                phieuMuonChiTietORM.MaPhieuMuon = newPhieuMuon.MaPhieuMuon;
                phieuMuonChiTietORM.MaTaiLieu = phieuTaiLieu.taiLieu.MaTaiLieu;
                

                var line = data.TaiLieus.Single(x => x.MaTaiLieu == phieuTaiLieu.taiLieu.MaTaiLieu);
                if (phieuTaiLieu.soLuongMuon <= line.SoLuong)
                {
                    phieuMuonChiTietORM.SoLuongMuon = phieuTaiLieu.soLuongMuon;
                    line.SoLuong -= phieuTaiLieu.soLuongMuon;
                }
                else
                {
                    throw new Exception("Không đủ số lượng của tài liệu");
                }

                data.PhieuMuonChiTiets.InsertOnSubmit(phieuMuonChiTietORM);

            }

            data.PhieuMuons.InsertOnSubmit(phieuMuonORM);
            data.SubmitChanges();
            
            
            return true;
        }

        public Boolean traSach(PhieuMuonDTO phieuMuon)
        {
            var line = data.PhieuMuons.Single(x => x.MaPhieuMuon == phieuMuon.MaPhieuMuon);

            foreach (PhieuTaiLieuDTO phieuTaiLieu in phieuMuon.DanhSachPhieuTaiLieu)
            {
                var phieuMuonChiTietORM = data.PhieuMuonChiTiets.Single(x => x.MaPhieuMuon == line.MaPhieuMuon && x.MaTaiLieu == phieuTaiLieu.taiLieu.MaTaiLieu);
                var taiLieu = data.TaiLieus.Single(x => x.MaTaiLieu == phieuTaiLieu.taiLieu.MaTaiLieu);
                taiLieu.SoLuong += phieuMuonChiTietORM.SoLuongMuon;
                data.PhieuMuonChiTiets.DeleteOnSubmit(phieuMuonChiTietORM);
            }

            data.SubmitChanges();
            return true;
        }

        public Boolean UpdateToDB(PhieuMuonDTO phieuMuon)
        {
            var line = data.PhieuMuons.Single(x => x.MaPhieuMuon == phieuMuon.MaPhieuMuon);
            line.NgayMuon = phieuMuon.NgayMuon;
            line.MaNhanVien = phieuMuon.MaNhanVien;

            foreach (PhieuTaiLieuDTO phieuTaiLieu in phieuMuon.DanhSachPhieuTaiLieu)
            {
                var phieuMuonChiTietORM = data.PhieuMuonChiTiets.Single(x => x.MaPhieuMuon == line.MaPhieuMuon && x.MaTaiLieu == phieuTaiLieu.taiLieu.MaTaiLieu);
                // Trường hợp đã trả sách
                if (phieuTaiLieu.ngayTra != null && !phieuTaiLieu.ngayTra.ToString().Equals("1/1/0001 12:00:00 AM"))
                {
                    phieuMuonChiTietORM.NgayTra = phieuTaiLieu.ngayTra;
                    phieuMuonChiTietORM.SoLuongMuon = phieuTaiLieu.soLuongMuon;

                }
                else
                {
                    Console.WriteLine("Trường hợp chưa trả sách");
                    // Trường hợp chưa trả sách
                    var currentTaiLieuTrongThuVien = data.TaiLieus.Single(x => x.MaTaiLieu == phieuTaiLieu.taiLieu.MaTaiLieu);
                    short soLuongDangMuon = short.Parse(phieuMuonChiTietORM.SoLuongMuon.ToString());
                    // Tính số lượng cần mượn thêm sau đó trừ đi
                    short soLuongSachCanMuonThem = (short)(short.Parse(phieuTaiLieu.soLuongMuon.ToString()) - soLuongDangMuon);
                    if (soLuongSachCanMuonThem <= currentTaiLieuTrongThuVien.SoLuong)
                    {
                        phieuMuonChiTietORM.SoLuongMuon = phieuTaiLieu.soLuongMuon;
                        currentTaiLieuTrongThuVien.SoLuong -= soLuongSachCanMuonThem;
                    }
                    else
                    {
                        throw new Exception("Không đủ số lượng của tài liệu");
                    }
                }

            }

            data.SubmitChanges();
            return true;
        }

        public PhieuMuonDTO getPhieuMuonByMa(string maPhieuMuon,string maTaiLieu)
        {
            
            var line = data.PhieuMuons.Single(x => x.MaPhieuMuon == maPhieuMuon);

            PhieuMuonDTO newPhieuMuon = new PhieuMuonDTO(line.MaPhieuMuon,line.MaDocGia,line.MaNhanVien, DateTime.Parse(line.NgayMuon.ToString()));
            var taiLieu = data.PhieuMuonChiTiets.Where(x => x.MaPhieuMuon == maPhieuMuon).Select(x => x);

            if (maTaiLieu != null)
            {
                taiLieu = data.PhieuMuonChiTiets.Where(x => x.MaPhieuMuon == maPhieuMuon && x.MaTaiLieu == maTaiLieu).Select(x => x);
            }

            foreach (var phieuTaiLieu in taiLieu)
            {
                PhieuTaiLieuDTO newPhieuTaiLieu = new PhieuTaiLieuDTO();
                newPhieuTaiLieu.soLuongMuon = short.Parse(phieuTaiLieu.SoLuongMuon.ToString());
                newPhieuTaiLieu.taiLieu.MaTaiLieu = phieuTaiLieu.MaTaiLieu;
                if(phieuTaiLieu.NgayTra != null)
                {
                    newPhieuTaiLieu.ngayTra = DateTime.Parse(phieuTaiLieu.NgayTra.ToString());
                }
                newPhieuMuon.DanhSachPhieuTaiLieu.Add(newPhieuTaiLieu);
            }

            return newPhieuMuon;
        }
        public Boolean deletePhieuByMa(PhieuMuonDTO phieuMuon)
        {
            var line = data.PhieuMuons.Single(x => x.MaPhieuMuon == phieuMuon.MaPhieuMuon);
            line.MaDocGia = phieuMuon.MaDocGia;
            line.NgayMuon = phieuMuon.NgayMuon;
            line.MaNhanVien = phieuMuon.MaNhanVien;

            var taiLieu = data.PhieuMuonChiTiets.Where(x => x.MaPhieuMuon == line.MaPhieuMuon).Select(x => x);
            if(taiLieu.ToArray().Length == phieuMuon.DanhSachPhieuTaiLieu.Count)
            {
                Console.WriteLine("Delete phieu muon");
                data.PhieuMuons.DeleteOnSubmit(line);
            }

            foreach (PhieuTaiLieuDTO phieuTaiLieu in phieuMuon.DanhSachPhieuTaiLieu)
            {
                var phieuMuonChiTietORM = data.PhieuMuonChiTiets.Single(x => x.MaPhieuMuon == line.MaPhieuMuon && x.MaTaiLieu == phieuTaiLieu.taiLieu.MaTaiLieu);
                data.PhieuMuonChiTiets.DeleteOnSubmit(phieuMuonChiTietORM);
                var taiLieuDb = data.TaiLieus.Single(x => x.MaTaiLieu == phieuTaiLieu.taiLieu.MaTaiLieu);
                if (phieuMuonChiTietORM.NgayTra == null)
                {
                    taiLieuDb.SoLuong += phieuMuonChiTietORM.SoLuongMuon;
                }

            }

            data.SubmitChanges();
            return true;
        }
    }
}
