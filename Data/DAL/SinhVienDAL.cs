using MySql.Data.MySqlClient;
using QuanlySinhVienApp.Data.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Text;

namespace QuanlySinhVienApp.Data.DAL
{
    public class SinhVienDAL
    {
        private DataHelper dataHelper = new DataHelper();
        private List<SinhVien> sinhViens = new List<SinhVien>();

        public SinhVienDAL()
        {
        }

        public List<SinhVien> getAllSinhVien1() => GetAllSinhVien1();

        public List<SinhVien> GetAllSinhVien1()
        {
            List<SinhVien> lv = new List<SinhVien>();
            try
            {
                MySqlDataReader dr = dataHelper.ExcuteReader("Select * from SinhVien");
                while (dr.Read())
                {
                    SinhVien sv = new SinhVien();
                    sv.MaSV = dr["MaSV"]?.ToString() ?? "";
                    sv.HoTen = dr["HoTen"]?.ToString() ?? "";
                    sv.GioiTinh = dr["GioiTinh"]?.ToString() ?? "";

                    if (dr["NgaySinh"] != DBNull.Value && DateTime.TryParse(dr["NgaySinh"].ToString(), out DateTime dt))
                    {
                        sv.NgaySinh = dt;
                    }

                    try { sv.SoDienThoai = dr["SoDienThoai"]?.ToString() ?? ""; } catch { }
                    if (string.IsNullOrEmpty(sv.SoDienThoai))
                    {
                        try { sv.SoDienThoai = dr["DienThoai"]?.ToString() ?? ""; } catch { }
                    }

                    sv.MaLop = dr["MaLop"]?.ToString() ?? "";

                    try
                    {
                        if (dr["Diem"] != DBNull.Value && double.TryParse(dr["Diem"].ToString(), NumberStyles.Any, CultureInfo.InvariantCulture, out double diemVal))
                        {
                            sv.Diem = diemVal;
                        }
                    }
                    catch { }

                    try { sv.Email = dr["Email"]?.ToString() ?? ""; } catch { }

                    lv.Add(sv);
                }
                dr.Close();
                return lv;
            }
            catch (Exception exx)
            {
                throw new Exception("Lỗi khi đọc danh sách sinh viên qua Reader: " + exx.Message, exx);
            }
            finally
            {
                dataHelper.CloseConnection();
            }
        }

        public List<SinhVien> GetAllSinhVien()
        {
            List<SinhVien> list = new List<SinhVien>();
            try
            {
                DataTable dt = dataHelper.GetDataTable("Select * from SinhVien");
                foreach (DataRow dr in dt.Rows)
                {
                    SinhVien sv = MapDataRowToSinhVien(dr);
                    list.Add(sv);
                }
                return list;
            }
            catch (Exception exx)
            {
                throw new Exception("Lỗi khi lấy danh sách sinh viên: " + exx.Message, exx);
            }
        }

        public List<SinhVien> GetSinhVien() => GetAllSinhVien();

        public List<SinhVien> GetSinhViensByMaLop(string maLop)
        {
            List<SinhVien> lv = new List<SinhVien>();
            try
            {
                DataTable dt = dataHelper.GetDataTable($"Select * from SinhVien where MaLop='{maLop}'");
                foreach (DataRow r in dt.Rows)
                {
                    SinhVien sv = MapDataRowToSinhVien(r);
                    lv.Add(sv);
                }
                return lv;
            }
            catch (Exception exx)
            {
                throw new Exception($"Lỗi khi lấy danh sách sinh viên theo lớp '{maLop}': " + exx.Message, exx);
            }
        }

        public List<SinhVien> GetSinhVienByMaLop(string maLop) => GetSinhViensByMaLop(maLop);

        public SinhVien? GetSinhVienById(string maSV)
        {
            try
            {
                DataTable dt = dataHelper.GetDataTable($"Select * from SinhVien where MaSV='{maSV}'");
                if (dt.Rows.Count > 0)
                {
                    return MapDataRowToSinhVien(dt.Rows[0]);
                }
                return null;
            }
            catch (Exception exx)
            {
                throw new Exception($"Lỗi khi tìm sinh viên có mã '{maSV}': " + exx.Message, exx);
            }
        }

        public SinhVien? GetSinhVienByMaSV(string maSV) => GetSinhVienById(maSV);

        public void AddSinhVien(SinhVien sv)
        {
            try
            {
                string ngaySinh = sv.NgaySinh.ToString("yyyy-MM-dd");
                string diemStr = sv.Diem.ToString("0.0", CultureInfo.InvariantCulture);
                string sql = $"INSERT INTO SinhVien (MaSV, MaLop, HoTen, GioiTinh, NgaySinh, Diem, SoDienThoai, Email) " +
                             $"VALUES ('{sv.MaSV}', '{sv.MaLop}', '{sv.HoTen}', '{sv.GioiTinh}', '{ngaySinh}', " +
                             $"{diemStr}, '{sv.SoDienThoai}', '{sv.Email}')";
                dataHelper.ExecuteNonQuery(sql);
            }
            catch (Exception exx)
            {
                throw new Exception("Lỗi khi thêm sinh viên vào cơ sở dữ liệu: " + exx.Message, exx);
            }
        }

        public void UpdateSinhVien(SinhVien sv)
        {
            try
            {
                string ngaySinh = sv.NgaySinh.ToString("yyyy-MM-dd");
                string diemStr = sv.Diem.ToString("0.0", CultureInfo.InvariantCulture);
                string sql = $"UPDATE SinhVien SET HoTen='{sv.HoTen}', MaLop='{sv.MaLop}', " +
                             $"GioiTinh='{sv.GioiTinh}', NgaySinh='{ngaySinh}', " +
                             $"Diem={diemStr}, SoDienThoai='{sv.SoDienThoai}', " +
                             $"Email='{sv.Email}' " +
                             $"WHERE MaSV='{sv.MaSV}'";
                dataHelper.ExecuteNonQuery(sql);
            }
            catch (Exception exx)
            {
                throw new Exception("Lỗi khi cập nhật sinh viên: " + exx.Message, exx);
            }
        }

        public void DeleteSinhVien(string maSV)
        {
            try
            {
                string sql = $"DELETE FROM SinhVien WHERE MaSV='{maSV}'";
                dataHelper.ExecuteNonQuery(sql);
            }
            catch (Exception exx)
            {
                throw new Exception("Lỗi khi xóa sinh viên: " + exx.Message, exx);
            }
        }

        private SinhVien MapDataRowToSinhVien(DataRow dr)
        {
            SinhVien sv = new SinhVien();
            sv.MaSV = dr.Table.Columns.Contains("MaSV") ? dr["MaSV"]?.ToString() ?? "" : "";
            sv.HoTen = dr.Table.Columns.Contains("HoTen") ? dr["HoTen"]?.ToString() ?? "" : "";
            sv.GioiTinh = dr.Table.Columns.Contains("GioiTinh") ? dr["GioiTinh"]?.ToString() ?? "" : "";
            sv.MaLop = dr.Table.Columns.Contains("MaLop") ? dr["MaLop"]?.ToString() ?? "" : "";

            if (dr.Table.Columns.Contains("NgaySinh") && dr["NgaySinh"] != DBNull.Value)
            {
                if (DateTime.TryParse(dr["NgaySinh"].ToString(), out DateTime dt))
                    sv.NgaySinh = dt;
            }

            if (dr.Table.Columns.Contains("SoDienThoai"))
                sv.SoDienThoai = dr["SoDienThoai"]?.ToString() ?? "";
            else if (dr.Table.Columns.Contains("DienThoai"))
                sv.SoDienThoai = dr["DienThoai"]?.ToString() ?? "";

            if (dr.Table.Columns.Contains("Email"))
                sv.Email = dr["Email"]?.ToString() ?? "";

            if (dr.Table.Columns.Contains("Diem") && dr["Diem"] != DBNull.Value)
            {
                if (double.TryParse(dr["Diem"].ToString(), NumberStyles.Any, CultureInfo.InvariantCulture, out double diemVal))
                {
                    sv.Diem = diemVal;
                }
            }

            if (dr.Table.Columns.Contains("TrangThai") && dr["TrangThai"] != DBNull.Value)
            {
                string tt = dr["TrangThai"].ToString() ?? "";
                if (!string.IsNullOrEmpty(tt)) sv.TrangThai = tt;
            }

            return sv;
        }
    }
}
