using QuanlySinhVienApp.Data.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuanlySinhVienApp.Data.DAL
{
    public class LopDAL
    {
        private List<LopHoc> lopHocs = new List<LopHoc>();
        public LopDAL()
        {
            lopHocs.Add(new LopHoc
            {
                MaLop = "Lop 1",
                TenLop = "Lớp 1"
            });
            lopHocs.Add(new LopHoc
            {
                MaLop = "Lop 2",
                TenLop = "Lớp 2"
            });
        }
        public List<LopHoc> GetAllLopHoc()
        {
            return lopHocs.ToList();
        }
    }
}
