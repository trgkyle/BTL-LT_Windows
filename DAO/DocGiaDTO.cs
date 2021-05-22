using System;
using System.Collections.Generic;
using System.Text;
namespace DTO
{
    public class DocGiaDTO
    {
        private string maDocGia;
        private string hoTen;
        private string gioiTinh;
        private string ngaySinh;
        private string maDoiTuong;
        private string tenDoiTuong;
        private string ngayCap;
        private string ngayHetHan;
        public string MaDocGia { get => maDocGia; set => maDocGia = value; }
        public string HoTen { get => hoTen; set => hoTen = value; }
        public string GioiTinh { get => gioiTinh; set => gioiTinh = value; }
        public string NgaySinh { get => ngaySinh; set => ngaySinh = value; }
        public string MaDoiTuong { get => maDoiTuong; set => maDoiTuong = value; }
        public string TenDoiTuong { get => tenDoiTuong; set => tenDoiTuong = value; }
        public string NgayCap { get => ngayCap; set => ngayCap = value; }
        public string NgayHetHan { get => ngayHetHan; set => ngayHetHan = value; }

        public DocGiaDTO(string maDocGia, string hoTen, string gioiTinh, string ngaySinh, string maDoiTuong, string tenDoiTuong, string ngayCap, string ngayHetHan)
        {
            this.MaDocGia = maDocGia;
            this.HoTen = hoTen;
            this.GioiTinh = gioiTinh;
            this.NgaySinh = ngaySinh;
            this.MaDoiTuong = maDoiTuong;
            this.TenDoiTuong = tenDoiTuong;
            this.NgayCap = ngayCap;
            this.NgayHetHan = ngayHetHan;
        }
    }
}
