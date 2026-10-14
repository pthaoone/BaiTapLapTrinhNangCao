using QuanlySinhVienApp.Data.Entity;
using System;
using System.Collections.Generic;
using System.Text;
namespace QuanlySinhVienApp.Data.DAL
{
    public class SinhVienDAL
    {
        List<SinhVien> sinhViens = new List<SinhVien>();

        public object HoTen { get; internal set; }

        public SinhVienDAL()
        {
            sinhViens.Add(new SinhVien
            {
                MaSV = "SV001",
                HoTen = "Nguyen Van A",
                NgaySinh = new DateTime(2000, 1, 1),
                GioiTinh = "Nam",
                MaLop = "Lop 1"
            });
            sinhViens.Add(new SinhVien
            {
                MaSV = "SV002",
                HoTen = "Tran Thi B",
                NgaySinh = new DateTime(2001, 2, 2),
                GioiTinh = "Nu",
                MaLop = "Lop 2"
            });
            sinhViens.Add(new SinhVien
            {
                MaSV = "SV003",
                HoTen = "Le Van C",
                NgaySinh = new DateTime(2002, 3, 3),
                GioiTinh = "Nam",
                MaLop = "Lop 1"
            });
        }
        public void AddSinhVien(SinhVien sv)
        {
            try
            {
                sinhViens.Add(sv);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm sinh viên: " + ex.Message);
            }
        }
        public bool UpdateSinhVien(SinhVien sv)
        {
            var svtoUpdate = sinhViens.Find(s => s.MaSV == sv.MaSV);
            if(svtoUpdate != null)
            { 
                svtoUpdate.HoTen = sv.HoTen;
                svtoUpdate.NgaySinh = sv.NgaySinh;
                svtoUpdate.GioiTinh = sv.GioiTinh;
                svtoUpdate.MaLop = sv.MaLop;
                return true;
            }
            return false;
            
        }
        public SinhVien GetSinhVienById(string maSV)
        {
            return sinhViens.Find(s => s.MaSV == maSV);
        }

        internal List<SinhVien> GetAllSinhVien()
        {
            return sinhViens;
        }

        internal bool IsInValid()
        {
            throw new NotImplementedException();
        }

        internal void AddSinhVien(SinhVienDAL sv)
        {
            throw new NotImplementedException();
        }
    }
}
