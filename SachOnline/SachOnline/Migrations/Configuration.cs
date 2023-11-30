namespace SachOnline.Migrations
{
    using SachOnline.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;
    using System.Security.Cryptography;

    internal sealed class Configuration : DbMigrationsConfiguration<SachOnline.Models.Model1>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        

        protected override void Seed(SachOnline.Models.Model1 context)
        {
            var lstChuDe = new List<CHUDE>();
            lstChuDe.Add(new CHUDE { MaCD = 1, TenChuDe = "Văn Hoc" });
            lstChuDe.Add(new CHUDE { MaCD = 2, TenChuDe = "Công Nghệ Thông Tin" });
            lstChuDe.Add(new CHUDE { MaCD = 3, TenChuDe = "Kinh Tế" });
            lstChuDe.ForEach(c => context.CHUDE.AddOrUpdate(c));
            var lstNXB = new List<NHAXUATBAN>();
            lstNXB.Add(new NHAXUATBAN { MaNXB = 1, TenNXB = "Giáo Dục" });
            lstNXB.Add(new NHAXUATBAN { MaNXB = 2, TenNXB = "Khoa học tự nhiên" });
            lstNXB.ForEach(n => context.NHAXUATBAN.AddOrUpdate(n));

            var lstSach = new List<SACH>();
            lstSach.Add(new SACH
            {
                Masach = 1,
                Tensach = "Sach 1",
                Mota = "Mo ta sach",
                MaCD = 1,
                MaNXB = 1,
                Giaban = 100000,
                Anhbia = Utility.ConvertImageToBase64(Path.GetFullPath("../Images/aa.jpg")),
                Ngaycapnhat = new DateTime(2023, 1, 1),
                Soluongton = 10,
            });
            lstSach.Add(new SACH
            {
                Masach = 2,
                Tensach = "Sach 2",
                Mota = "Mo ta sach",
                MaCD = 1,
                MaNXB = 1,
                Giaban = 100000,
                Anhbia = Utility.ConvertImageToBase64(Path.GetFullPath("../Images/w.jpg")),
                Ngaycapnhat = new DateTime(2023, 1, 1),
                Soluongton = 10,
            });
            lstSach.Add(new SACH
            {
                Masach = 3,
                Tensach = "Sach 3",
                Mota = "Mo ta sach",
                MaCD = 1,
                MaNXB = 1,
                Giaban = 100000,
                Anhbia = Utility.ConvertImageToBase64(Path.GetFullPath("../Images/w.jpg")),
                Ngaycapnhat = new DateTime(2023, 1, 1),
                Soluongton = 10,
            });
            lstSach.Add(new SACH
            {
                Masach = 4,
                Tensach = "Sach 4",
                Mota = "Mo ta sach",
                MaCD = 1,
                MaNXB = 1,
                Giaban = 100000,
                Anhbia = Utility.ConvertImageToBase64(Path.GetFullPath("../Images/w.jpg")),
                Ngaycapnhat = new DateTime(2023, 1, 1),
                Soluongton = 10,
            });
            lstSach.Add(new SACH
            {
                Masach = 5,
                Tensach = "Sach 5",
                Mota = "Mo ta sach",
                MaCD = 1,
                MaNXB = 1,
                Giaban = 100000,
                Anhbia = Utility.ConvertImageToBase64(Path.GetFullPath("../Images/w.jpg")),
                Ngaycapnhat = new DateTime(2023, 1, 1),
                Soluongton = 10,
            });
            lstSach.Add(new SACH
            {
                Masach = 6,
                Tensach = "Sach 6",
                Mota = "Mo ta sach",
                MaCD = 1,
                MaNXB = 1,
                Giaban = 100000,
                Anhbia = Utility.ConvertImageToBase64(Path.GetFullPath("../Images/w.jpg")),
                Ngaycapnhat = new DateTime(2023, 1, 1),
                Soluongton = 10,
            });
            lstSach.Add(new SACH
            {
                Masach = 7,
                Tensach = "Sach 7",
                Mota = "Mo ta sach",
                MaCD = 1,
                MaNXB = 1,
                Giaban = 100000,
                Anhbia = Utility.ConvertImageToBase64(Path.GetFullPath("../Images/w.jpg")),
                Ngaycapnhat = new DateTime(2023, 1, 1),
                Soluongton = 10,
            });
            lstSach.Add(new SACH
            {
                Masach = 8,
                Tensach = "Sach 8",
                Mota = "Mo ta sach",
                MaCD = 1,
                MaNXB = 1,
                Giaban = 100000,
                Anhbia = Utility.ConvertImageToBase64(Path.GetFullPath("../Images/w.jpg")),
                Ngaycapnhat = new DateTime(2023, 1, 1),
                Soluongton = 10,
            });
            lstSach.Add(new SACH
            {
                Masach = 9,
                Tensach = "Sach 9",
                Mota = "Mo ta sach",
                MaCD = 1,
                MaNXB = 1,
                Giaban = 100000,
                Anhbia = Utility.ConvertImageToBase64(Path.GetFullPath("../Images/w.jpg")),
                Ngaycapnhat = new DateTime(2023, 1, 1),
                Soluongton = 10,
            });
            lstSach.Add(new SACH
            {
                Masach = 10,
                Tensach = "Sach 10",
                Mota = "Mo ta sach",
                MaCD = 1,
                MaNXB = 1,
                Giaban = 100000,
                Anhbia = Utility.ConvertImageToBase64(Path.GetFullPath("../Images/w.jpg")),
                Ngaycapnhat = new DateTime(2023, 1, 1),
                Soluongton = 10,
            });
            lstSach.Add(new SACH
            {
                Masach = 11,
                Tensach = "Sach 11",
                Mota = "Mo ta sach",
                MaCD = 1,
                MaNXB = 1,
                Giaban = 100000,
                Anhbia = Utility.ConvertImageToBase64(Path.GetFullPath("../Images/w.jpg")),
                Ngaycapnhat = new DateTime(2023, 1, 1),
                Soluongton = 10,
            });

            lstSach.ForEach(s => context.SACH.AddOrUpdate(s));

            var lstKHACHHANGs = new List<KHACHHANG>();
            lstKHACHHANGs.Add(new KHACHHANG
            {
                HoTen = "Tran Van An",
                DiachiKH = "Binh Duong",
                DienthoaiKH = "091000001",
                Email = "vanhuudhsp@gmail.com",
                MaKH = 1,
                Matkhau = "Fit@123456",
                Ngaysinh = new DateTime(1985, 1, 1),
                Taikhoan = "test",
                MatKhauNL = "Fit@123456",
            });
            lstKHACHHANGs.ForEach(s => context.KHACHHANG.AddOrUpdate(s));

            

            var lstUsers = new List<USER>();
            lstUsers.Add(new USER { UserName = "admin", Password = "123", Role = "admin", Email = "datnguyen13021302@gmail.com", Avatar = Utility.ConvertImageToBase64(Path.GetFullPath("../Images/mb.jpg")) });
            lstUsers.Add(new USER { UserName = "tandat", Password = "123", Role = "cashier" });
            lstUsers.ForEach(s => context.USERs.AddOrUpdate(s));

            base.Seed(context);

        }
    }
}
