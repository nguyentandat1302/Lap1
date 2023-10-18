using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SachOnline.Models
{
    public class GioHang
    {
        public int MaSach { get; set; }
        public string TenSach { get; set; }

        public string AnhBia { get; set; }

        public double GiaBan { get; set; }

        public int SoLuong { get; set; }

        public double ThanhTien
        {
            get
            {
                return SoLuong * GiaBan;
            }
        }
        Model1 db = new Model1();
        
        public GioHang(int ms)
        {
            var s = db.SACH.FirstOrDefault(k => k.Masach == MaSach);
            MaSach = s.Masach;
            TenSach = s.Tensach;
            AnhBia = s.Anhbia;
            GiaBan = Double.Parse(s.Giaban.ToString());
            SoLuong = 1;
        }

    }
}