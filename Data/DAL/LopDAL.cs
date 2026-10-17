using MySql.Data.MySqlClient;
using QuanlySinhVienApp.Data.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace QuanlySinhVienApp.Data.DAL
{
    public class LopHocDAL
    {
        private DataHelper dataHelper = new DataHelper();

        public LopHocDAL()
        {
        }

        public List<LopHoc> GetAllLopHoc()
        {
            List<LopHoc> list = new List<LopHoc>();
            try
            {
                DataTable dt = dataHelper.GetDataTable("Select * from LopHoc");
                foreach (DataRow dr in dt.Rows)
                {
                    LopHoc lop = new LopHoc();
                    lop.MaLop = dr["MaLop"]?.ToString() ?? "";
                    lop.TenLop = dr["TenLop"]?.ToString() ?? "";
                    list.Add(lop);
                }
                return list;
            }
            catch (Exception exx)
            {
                throw new Exception("Lỗi khi lấy danh sách lớp học từ cơ sở dữ liệu: " + exx.Message, exx);
            }
        }

        public LopHoc? GetLopHocByMaLop(string maLop)
        {
            try
            {
                DataTable dt = dataHelper.GetDataTable($"Select * from LopHoc where MaLop='{maLop}'");
                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    return new LopHoc
                    {
                        MaLop = dr["MaLop"]?.ToString() ?? "",
                        TenLop = dr["TenLop"]?.ToString() ?? ""
                    };
                }
                return null;
            }
            catch (Exception exx)
            {
                throw new Exception($"Lỗi khi tìm lớp học có mã '{maLop}': " + exx.Message, exx);
            }
        }

        public LopHoc? GetLopHocById(string maLop) => GetLopHocByMaLop(maLop);

        public void AddLopHoc(LopHoc lop)
        {
            try
            {
                string sql = $"INSERT INTO LopHoc (MaLop, TenLop) VALUES ('{lop.MaLop}', '{lop.TenLop}')";
                dataHelper.ExecuteNonQuery(sql);
            }
            catch (Exception exx)
            {
                throw new Exception($"Lỗi khi thêm lớp học '{lop.MaLop}': " + exx.Message, exx);
            }
        }

        public void UpdateLopHoc(LopHoc lop)
        {
            try
            {
                string sql = $"UPDATE LopHoc SET TenLop='{lop.TenLop}' WHERE MaLop='{lop.MaLop}'";
                dataHelper.ExecuteNonQuery(sql);
            }
            catch (Exception exx)
            {
                throw new Exception($"Lỗi khi cập nhật lớp học '{lop.MaLop}': " + exx.Message, exx);
            }
        }

        public void DeleteLopHoc(string maLop)
        {
            try
            {
                string sql = $"DELETE FROM LopHoc WHERE MaLop='{maLop}'";
                dataHelper.ExecuteNonQuery(sql);
            }
            catch (Exception exx)
            {
                throw new Exception($"Lỗi khi xóa lớp học '{maLop}': " + exx.Message, exx);
            }
        }
    }

    public class LopDAL : LopHocDAL
    {
    }
}
