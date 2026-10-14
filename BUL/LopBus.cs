using QuanlySinhVienApp.Data.Entity;
using QuanlySinhVienApp.Data.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuanlySinhVienApp.BUL
{
    public class LopBus
    {
        private LopDAL lopDAL;
        public LopBus()
        {
            lopDAL = new LopDAL();
        }
        public List<LopHoc> GetAllLopHoc()
        {
            return lopDAL.GetAllLopHoc();
        }
    }
}
