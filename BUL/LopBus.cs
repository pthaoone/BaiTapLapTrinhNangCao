using QuanlySinhVienApp.Data.DAL;
using QuanlySinhVienApp.Data.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuanlySinhVienApp.BUL
{
    public class LopBus
    {
        private LopHocDAL lopDAL;

        public LopBus()
        {
            lopDAL = new LopHocDAL();
        }

        public List<LopHoc> GetAllLopHoc()
        {
            try
            {
                return lopDAL.GetAllLopHoc();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi tầng Business khi lấy danh sách lớp học: " + ex.Message, ex);
            }
        }

        public LopHoc? GetLopHocByMaLop(string maLop)
        {
            if (string.IsNullOrWhiteSpace(maLop))
            {
                throw new Exception("Mã lớp học không được để trống!");
            }

            try
            {
                return lopDAL.GetLopHocByMaLop(maLop.Trim());
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi tầng Business khi tìm lớp học '{maLop}': " + ex.Message, ex);
            }
        }

        public void AddLopHoc(LopHoc lop)
        {
            if (lop == null) throw new ArgumentNullException(nameof(lop), "Dữ liệu lớp học không được rỗng!");
            if (!lop.IsValid()) throw new Exception("Thông tin lớp học không hợp lệ!");

            var existing = lopDAL.GetLopHocByMaLop(lop.MaLop);
            if (existing != null)
            {
                throw new Exception($"Mã lớp học '{lop.MaLop}' đã tồn tại trong hệ thống!");
            }

            try
            {
                lopDAL.AddLopHoc(lop);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi tầng Business khi thêm lớp học: " + ex.Message, ex);
            }
        }

        public void UpdateLopHoc(LopHoc lop)
        {
            if (lop == null) throw new ArgumentNullException(nameof(lop), "Dữ liệu lớp học không được rỗng!");
            if (!lop.IsValid()) throw new Exception("Thông tin lớp học không hợp lệ!");

            var existing = lopDAL.GetLopHocByMaLop(lop.MaLop);
            if (existing == null)
            {
                throw new Exception($"Không tìm thấy lớp học có mã '{lop.MaLop}' để cập nhật!");
            }

            try
            {
                lopDAL.UpdateLopHoc(lop);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi tầng Business khi cập nhật lớp học: " + ex.Message, ex);
            }
        }

        public void DeleteLopHoc(string maLop)
        {
            if (string.IsNullOrWhiteSpace(maLop))
            {
                throw new Exception("Mã lớp học cần xóa không được để trống!");
            }

            var existing = lopDAL.GetLopHocByMaLop(maLop.Trim());
            if (existing == null)
            {
                throw new Exception($"Không tìm thấy lớp học có mã '{maLop}' để xóa!");
            }

            try
            {
                lopDAL.DeleteLopHoc(maLop.Trim());
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi tầng Business khi xóa lớp học: " + ex.Message, ex);
            }
        }
    }
}
