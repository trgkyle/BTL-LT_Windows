using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class TaiLieuDTO
    {
        private string maTaiLieu;
        private string tenTaiLieu;
        private string maTheLoai;
        private int soLuong;
        private string nhaXuatBan;
        private int namXuatBan;
        private string tacGia;

        public TaiLieuDTO(string maTaiLieu, string tenTaiLieu, string maTheLoai, int soLuong, string nhaXuatBan, int namXuatBan, string tacGia)
        {
            this.MaTaiLieu = maTaiLieu;
            this.TenTaiLieu = tenTaiLieu;
            this.maTheLoai = maTheLoai;
            this.SoLuong = soLuong;
            this.NhaXuatBan = nhaXuatBan;
            this.NamXuatBan = namXuatBan;
            this.TacGia = tacGia;
        }

        public string MaTaiLieu { get => maTaiLieu; set => maTaiLieu = value; }
        public string TenTaiLieu { get => tenTaiLieu; set => tenTaiLieu = value; }
        public string MaTheLoai { get => maTheLoai; set => maTheLoai = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public string NhaXuatBan { get => nhaXuatBan; set => nhaXuatBan = value; }
        public int NamXuatBan { get => namXuatBan; set => namXuatBan = value; }
        public string TacGia { get => tacGia; set => tacGia = value; }
    }
}
