using QuanlySinhVienApp.Data.DAL;
using QuanlySinhVienApp.Data.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLySinhVien.BUL
{
    public class SinhVienBUL
    {
        SinhVienDAL svd;
        public SinhVienBUL()
        {
            svd = new SinhVienDAL();
        }
        public List<SinhVien> GetAllSinhVien()
        {
            return svd.GetAllSinhVien();
        }
        public void AddSinhVien(SinhVien sv)
        {
            if (sv.IsInValid().Count > 0)
            {
                throw new Exception("Sinh viên không hợp lệ");
            }
            var s = svd.GetSinhVienById(sv.MaSV);
            if (s != null)
            {
                throw new Exception("Mã sinh viên đã tồn tại");
            }
            //Thêm sinh viên vào cơ sở dữ liệu
            svd.AddSinhVien(sv);
        }
    }
}
