using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class PhieuTaiLieuDTO
    {
        public PhieuTaiLieuDTO()
        {
            taiLieu = new TaiLieuDTO();
        }
        public TaiLieuDTO taiLieu;
        public short soLuongMuon;
        public DateTime ngayTra;
    }
}
