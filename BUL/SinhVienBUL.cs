using QuanlySinhVienApp.Data.DAL;
using QuanlySinhVienApp.Data.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuanlySinhVienApp.BUL
{
    public class SinhVienBUL
    {
        private SinhVienDAL svd;

        public SinhVienBUL()
        {
            svd = new SinhVienDAL();
        }

        public List<SinhVien> GetAllSinhVien()
        {
            try
            {
                return svd.GetAllSinhVien();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi tầng Business khi lấy danh sách sinh viên: " + ex.Message, ex);
            }
        }

        public List<SinhVien> GetAllSinhVien1()
        {
            try
            {
                return svd.GetAllSinhVien1();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi tầng Business khi lấy danh sách sinh viên (Reader): " + ex.Message, ex);
            }
        }

        public List<SinhVien> GetSinhViensByMaLop(string maLop)
        {
            if (string.IsNullOrWhiteSpace(maLop))
            {
                throw new Exception("Mã lớp không được để trống!");
            }

            try
            {
                return svd.GetSinhViensByMaLop(maLop.Trim());
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi tầng Business khi lấy sinh viên theo mã lớp '{maLop}': " + ex.Message, ex);
            }
        }

        public SinhVien? GetSinhVienById(string maSV)
        {
            if (string.IsNullOrWhiteSpace(maSV)) return null;

            try
            {
                return svd.GetSinhVienById(maSV.Trim());
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi tầng Business khi tìm sinh viên có mã '{maSV}': " + ex.Message, ex);
            }
        }

        public void AddSinhVien(SinhVien sv)
        {
            if (sv == null)
            {
                throw new ArgumentNullException(nameof(sv), "Đối tượng sinh viên không được để trống!");
            }

            // Kiểm tra tính hợp lệ qua Data Annotations
            if (!sv.KiemTraHopLe(out List<string> errors))
            {
                throw new Exception("Dữ liệu sinh viên không hợp lệ:\n• " + string.Join("\n• ", errors));
            }

            // Kiểm tra trùng mã sinh viên
            var existing = svd.GetSinhVienById(sv.MaSV);
            if (existing != null)
            {
                throw new Exception($"Mã sinh viên '{sv.MaSV}' đã tồn tại trong cơ sở dữ liệu!");
            }

            // Kiểm tra đã chọn lớp chưa
            if (string.IsNullOrWhiteSpace(sv.MaLop))
            {
                throw new Exception("Vui lòng chọn lớp học cho sinh viên!");
            }

            try
            {
                svd.AddSinhVien(sv);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi tầng Business khi thêm sinh viên: " + ex.Message, ex);
            }
        }

        public void UpdateSinhVien(SinhVien sv)
        {
            if (sv == null)
            {
                throw new ArgumentNullException(nameof(sv), "Đối tượng sinh viên không được để trống!");
            }

            if (!sv.KiemTraHopLe(out List<string> errors))
            {
                throw new Exception("Dữ liệu cập nhật không hợp lệ:\n• " + string.Join("\n• ", errors));
            }

            var existing = svd.GetSinhVienById(sv.MaSV);
            if (existing == null)
            {
                throw new Exception($"Không tìm thấy sinh viên có mã '{sv.MaSV}' để cập nhật!");
            }

            if (string.IsNullOrWhiteSpace(sv.MaLop))
            {
                throw new Exception("Vui lòng chọn lớp học cho sinh viên!");
            }

            try
            {
                svd.UpdateSinhVien(sv);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi tầng Business khi cập nhật sinh viên: " + ex.Message, ex);
            }
        }

        public void DeleteSinhVien(string maSV)
        {
            if (string.IsNullOrWhiteSpace(maSV))
            {
                throw new Exception("Mã sinh viên cần xóa không được để trống!");
            }

            var existing = svd.GetSinhVienById(maSV.Trim());
            if (existing == null)
            {
                throw new Exception($"Không tìm thấy sinh viên có mã '{maSV}' để xóa!");
            }

            try
            {
                svd.DeleteSinhVien(maSV.Trim());
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi tầng Business khi xóa sinh viên: " + ex.Message, ex);
            }
        }
    }
}

namespace QuanLySinhVien.BUL
{
    public class SinhVienBUL : QuanlySinhVienApp.BUL.SinhVienBUL
    {
    }
}
