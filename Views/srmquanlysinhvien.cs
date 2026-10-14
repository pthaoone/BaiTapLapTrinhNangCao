using QuanlySinhVienApp.Data.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace QuanlySinhVienApp
{
    public partial class srmquanlysinhvien : Form
    {
        // Danh sách lớp học và sinh viên
        private List<LopHoc> listLopHoc = new List<LopHoc>();
        private List<SinhVien> listSinhVien = new List<SinhVien>();

        // Cờ tránh vòng lặp sự kiện khi nạp dữ liệu lên form
        private bool _isBindingData = false;
        private bool _isStudentFound = false;

        // Alias txtMaSV theo yêu cầu đề bài
        public TextBox txtMaSV => txtmasinhvien;

        public srmquanlysinhvien()
        {
            InitializeComponent();
            SetupForm();
        }

        private void SetupForm()
        {
            // Thiết lập giá trị cho combobox trạng thái
            cbotrangthai.Items.Clear();
            cbotrangthai.Items.Add("Đang học");
            cbotrangthai.Items.Add("Bảo lưu");
            cbotrangthai.Items.Add("Đã tốt nghiệp");
            cbotrangthai.Items.Add("Đình chỉ");
            cbotrangthai.SelectedIndex = 0;

            // Đăng ký sự kiện
            this.Load += srmquanlysinhvien_Load;
            this.FormClosing += srmquanlysinhvien_FormClosing;

            txtmasinhvien.TextChanged += txtmasinhvien_TextChanged;
            txtmasinhvien.Leave += txtmasinhvien_Leave;

            buttonThem.Click += buttonThem_Click;
            buttonSua.Click += buttonSua_Click;
            buttonXoa.Click += buttonXoa_Click;
            buttonLamMoi.Click += buttonLamMoi_Click;

            buttonTimkiem.Click += buttonTimkiem_Click;
            buttonHienthi.Click += buttonHienthi_Click;

            dataGridView1.CellClick += dataGridView1_CellClick;
        }

        /// <summary>
        /// Khởi tạo dữ liệu mẫu ban đầu theo đúng giao diện
        /// </summary>
        private void KhoiTaoDuLieuMau()
        {
            // Khởi tạo các lớp học
            var lop1 = new LopHoc("CSE0001", "Kỹ thuật phần mềm 01");
            var lop2 = new LopHoc("CSE0002", "Trí tuệ nhân tạo 01");
            var lop3 = new LopHoc("CSE0003", "Khoa học dữ liệu 01");
            var lop4 = new LopHoc("CSE0004", "Hệ thống thông tin 01");

            listLopHoc.Clear();
            listLopHoc.Add(lop1);
            listLopHoc.Add(lop2);
            listLopHoc.Add(lop3);
            listLopHoc.Add(lop4);

            // Khởi tạo 4 sinh viên mẫu như trên hình
            listSinhVien.Clear();

            ThemSinhVienMau("SV000123", "Nguyễn Văn An", new DateTime(2006, 8, 15), "Nam", "an.nv@vju.ac.vn", "0912345678", 8.5, lop1, "Đang học");
            ThemSinhVienMau("SV000124", "Trần Minh Ánh", new DateTime(2006, 1, 22), "Nữ", "anh.tm@vju.ac.vn", "0987654321", 9.0, lop2, "Đang học");
            ThemSinhVienMau("SV000125", "Lê Hoàng Bình", new DateTime(2006, 5, 9), "Nam", "binh.lh@vju.ac.vn", "0355556677", 7.4, lop1, "Đang học");
            ThemSinhVienMau("SV000126", "Đỗ Thị Hồng", new DateTime(2006, 11, 30), "Nữ", "hong.dt@vju.ac.vn", "0777888999", 8.1, lop3, "Đang học");
        }

        private void ThemSinhVienMau(string maSV, string hoTen, DateTime ngaySinh, string gioiTinh, string email, string dienThoai, double diem, LopHoc lopHoc, string trangThai)
        {
            var sv = new SinhVien
            {
                MaSV = maSV,
                HoTen = hoTen,
                NgaySinh = ngaySinh,
                GioiTinh = gioiTinh,
                Email = email,
                DienThoai = dienThoai,
                Diem = diem,
                MaLop = lopHoc.MaLop,
                TenLop = lopHoc.TenLop,
                TrangThai = trangThai,
                LopHoc = lopHoc
            };

            // Quan hệ 1 - n: Lớp học có nhiều sinh viên
            lopHoc.DanhSachSinhVien.Add(sv);
            listSinhVien.Add(sv);
        }

        #region Yêu cầu 3: Khi FormLoad
        private void srmquanlysinhvien_Load(object? sender, EventArgs e)
        {
            // Nạp dữ liệu mẫu
            KhoiTaoDuLieuMau();

            // 3.a Thiết lập button enable phù hợp
            buttonThem.Enabled = true;
            buttonSua.Enabled = false;
            buttonXoa.Enabled = false;
            buttonLamMoi.Enabled = true;

            // 3.b Lấy về danh sách lớp học hiển thị combobox
            cbolophoc.DataSource = listLopHoc.ToList();
            cbolophoc.DisplayMember = "TenLop";
            cbolophoc.ValueMember = "MaLop";

            // Combobox lớp học tìm kiếm (thêm mục Tất cả lớp)
            cbolophoctimkiem.Items.Clear();
            cbolophoctimkiem.Items.Add("Tất cả lớp");
            foreach (var lop in listLopHoc)
            {
                cbolophoctimkiem.Items.Add(lop.TenLop);
            }
            cbolophoctimkiem.SelectedIndex = 0;

            // Cấu hình DataGridView
            CauHinhDataGridView();

            // 3.c Lấy về danh sách sinh viên hiển thị data gridview
            HienThiDanhSach(listSinhVien);

            // 3.a Con trỏ thiết lập mặc định ở txtMaSV
            this.ActiveControl = txtmasinhvien;
            txtmasinhvien.Focus();
        }
        #endregion

        /// <summary>
        /// Cấu hình các cột cho DataGridView hiển thị đẹp và chuẩn xác
        /// </summary>
        private void CauHinhDataGridView()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Clear();

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "MaSV",
                HeaderText = "Mã SV",
                Width = 100
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "HoTen",
                HeaderText = "Họ và tên",
                Width = 140
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "NgaySinhFormatted",
                HeaderText = "Ngày sinh",
                Width = 100
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "GioiTinh",
                HeaderText = "Giới tính",
                Width = 100
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Email",
                HeaderText = "Email",
                Width = 160
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "DienThoai",
                HeaderText = "Điện thoại",
                Width = 110
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "DiemFormatted",
                HeaderText = "Điểm",
                Width = 65
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TenLop",
                HeaderText = "Lớp",
                Width = 150
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TrangThai",
                HeaderText = "Trạng thái",
                Width = 100
            });
        }

        /// <summary>
        /// Hiển thị danh sách sinh viên lên DataGridView và cập nhật nhãn Tổng số
        /// </summary>
        private void HienThiDanhSach(List<SinhVien> danhSach)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = danhSach.ToList();
            Tongso.Text = $"Tổng số: {danhSach.Count} sinh viên";
        }

        #region Yêu cầu 4: Khi người dùng nhập mã sinh viên
        private void txtmasinhvien_TextChanged(object? sender, EventArgs e)
        {
            if (_isBindingData) return;

            string maSV = txtmasinhvien.Text.Trim();

            // Tìm kiếm sinh viên theo mã (không phân biệt chữ hoa/thường)
            var sv = listSinhVien.FirstOrDefault(s => string.Equals(s.MaSV.Trim(), maSV, StringComparison.OrdinalIgnoreCase));

            if (sv != null)
            {
                // Nếu mã sinh viên tồn tại: lấy thông tin sinh viên hiển thị tương ứng lên các điều khiển còn lại
                _isBindingData = true;
                _isStudentFound = true;

                txthoten.Text = sv.HoTen;
                dateTimePicker1.Value = sv.NgaySinh;
                if (sv.GioiTinh == "Nữ")
                {
                    Nu.Checked = true;
                }
                else
                {
                    Nam.Checked = true;
                }

                numberdiem.Value = (decimal)Math.Clamp(sv.Diem, 0.0, 10.0);
                txtemail.Text = sv.Email;
                txtsodienthoai.Text = sv.DienThoai;

                // Chọn lớp học tương ứng
                if (!string.IsNullOrEmpty(sv.MaLop))
                {
                    cbolophoc.SelectedValue = sv.MaLop;
                }

                // Chọn trạng thái tương ứng
                int idxTrangThai = cbotrangthai.FindStringExact(sv.TrangThai);
                if (idxTrangThai >= 0)
                {
                    cbotrangthai.SelectedIndex = idxTrangThai;
                }

                // Disable chức năng nhập, enable chức năng sửa, xóa
                buttonThem.Enabled = false;
                buttonSua.Enabled = true;
                buttonXoa.Enabled = true;

                _isBindingData = false;
            }
            else
            {
                // Chưa tồn tại
                if (_isStudentFound)
                {
                    // Nếu trước đó đang hiển thị sinh viên khác thì xóa giá trị các điều khiển textbox
                    _isBindingData = true;
                    XoaThongTinChiTiet();
                    _isBindingData = false;
                }

                _isStudentFound = false;

                // Enable chức năng nhập, disable chức năng sửa, xóa
                buttonThem.Enabled = true;
                buttonSua.Enabled = false;
                buttonXoa.Enabled = false;
            }
        }

        private void txtmasinhvien_Leave(object? sender, EventArgs e)
        {
            if (_isBindingData) return;

            string maSV = txtmasinhvien.Text.Trim();
            if (string.IsNullOrEmpty(maSV)) return;

            var sv = listSinhVien.FirstOrDefault(s => string.Equals(s.MaSV.Trim(), maSV, StringComparison.OrdinalIgnoreCase));
            if (sv == null && _isStudentFound)
            {
                _isBindingData = true;
                XoaThongTinChiTiet();
                _isStudentFound = false;
                buttonThem.Enabled = true;
                buttonSua.Enabled = false;
                buttonXoa.Enabled = false;
                _isBindingData = false;
            }
        }

        private void XoaThongTinChiTiet()
        {
            txthoten.Clear();
            txtemail.Clear();
            txtsodienthoai.Clear();
            dateTimePicker1.Value = new DateTime(2006, 1, 1);
            Nam.Checked = true;
            numberdiem.Value = 0;
            if (cbolophoc.Items.Count > 0) cbolophoc.SelectedIndex = 0;
            if (cbotrangthai.Items.Count > 0) cbotrangthai.SelectedIndex = 0;
        }
        #endregion

        #region Yêu cầu 5: Khi người dùng nhấn Button Làm mới
        private void buttonLamMoi_Click(object? sender, EventArgs e)
        {
            _isBindingData = true;

            // Xóa trống các thuộc tính trên form
            txtmasinhvien.Clear();
            XoaThongTinChiTiet();

            // Đặt lại ô tìm kiếm
            txttukhoa.Clear();
            txtdemtu.Text = "0.0";
            if (cbolophoctimkiem.Items.Count > 0) cbolophoctimkiem.SelectedIndex = 0;

            _isStudentFound = false;
            _isBindingData = false;

            // Hiển thị lại toàn bộ danh sách
            HienThiDanhSach(listSinhVien);

            // Enable button Nhập (Thêm), Disable button sửa xóa
            buttonThem.Enabled = true;
            buttonSua.Enabled = false;
            buttonXoa.Enabled = false;

            // Chuyển tiêu điểm về điều khiển txtMaSV
            this.ActiveControl = txtmasinhvien;
            txtmasinhvien.Focus();
        }
        #endregion

        #region Yêu cầu 6: Chức năng Xóa (Hành động nguy hiểm -> Xác thực)
        private void buttonXoa_Click(object? sender, EventArgs e)
        {
            string maSV = txtmasinhvien.Text.Trim();
            if (string.IsNullOrEmpty(maSV))
            {
                MessageBox.Show("Vui lòng chọn hoặc nhập mã sinh viên cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var sv = listSinhVien.FirstOrDefault(s => string.Equals(s.MaSV.Trim(), maSV, StringComparison.OrdinalIgnoreCase));
            if (sv == null)
            {
                MessageBox.Show($"Không tìm thấy sinh viên có mã '{maSV}'!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Yêu cầu 6: Xác thực trước khi thực hiện chức năng nguy hiểm
            var result = MessageBox.Show(
                $"Bạn có chắc chắn muốn XÓA sinh viên:\n- Họ tên: {sv.HoTen}\n- Mã SV: {sv.MaSV}\n- Lớp: {sv.TenLop}\n\nHành động này không thể hoàn tác!",
                "Xác nhận xóa dữ liệu nguy hiểm",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2
            );

            if (result == DialogResult.Yes)
            {
                // Xóa khỏi danh sách sinh viên của lớp (quan hệ 1 - n)
                sv.LopHoc?.DanhSachSinhVien.Remove(sv);

                // Xóa khỏi danh sách tổng
                listSinhVien.Remove(sv);

                MessageBox.Show("Đã xóa sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Cập nhật lại giao diện và làm mới form
                HienThiDanhSach(listSinhVien);
                buttonLamMoi_Click(sender, e);
            }
        }
        #endregion

        #region Yêu cầu 6: Chức năng Sửa (Hành động thay đổi dữ liệu -> Xác thực)
        private void buttonSua_Click(object? sender, EventArgs e)
        {
            string maSV = txtmasinhvien.Text.Trim();
            if (string.IsNullOrEmpty(maSV))
            {
                MessageBox.Show("Vui lòng nhập hoặc chọn mã sinh viên cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var sv = listSinhVien.FirstOrDefault(s => string.Equals(s.MaSV.Trim(), maSV, StringComparison.OrdinalIgnoreCase));
            if (sv == null)
            {
                MessageBox.Show($"Không tìm thấy sinh viên có mã '{maSV}'!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Tạo đối tượng tạm thời để validate
            var svCapNhat = new SinhVien
            {
                MaSV = maSV,
                HoTen = txthoten.Text.Trim(),
                NgaySinh = dateTimePicker1.Value,
                GioiTinh = Nu.Checked ? "Nữ" : "Nam",
                Email = txtemail.Text.Trim(),
                DienThoai = txtsodienthoai.Text.Trim(),
                Diem = (double)numberdiem.Value,
                TrangThai = cbotrangthai.SelectedItem?.ToString() ?? "Đang học"
            };

            if (cbolophoc.SelectedItem is LopHoc lopChon)
            {
                svCapNhat.MaLop = lopChon.MaLop;
                svCapNhat.TenLop = lopChon.TenLop;
                svCapNhat.LopHoc = lopChon;
            }

            // Kiểm tra tính hợp lệ bằng Data Annotations theo Yêu cầu 2
            if (!svCapNhat.KiemTraHopLe(out List<string> errors))
            {
                string thongBaoLoi = string.Join("\n• ", errors);
                MessageBox.Show("Dữ liệu nhập chưa hợp lệ:\n• " + thongBaoLoi, "Lỗi kiểm tra dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Yêu cầu 6: Xác thực trước khi cập nhật
            var result = MessageBox.Show(
                $"Bạn có chắc chắn muốn CẬP NHẬT thông tin cho sinh viên '{sv.MaSV}' ({sv.HoTen})?",
                "Xác nhận cập nhật thông tin",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                // Cập nhật thông tin sinh viên
                sv.HoTen = svCapNhat.HoTen;
                sv.NgaySinh = svCapNhat.NgaySinh;
                sv.GioiTinh = svCapNhat.GioiTinh;
                sv.Email = svCapNhat.Email;
                sv.DienThoai = svCapNhat.DienThoai;
                sv.Diem = svCapNhat.Diem;
                sv.TrangThai = svCapNhat.TrangThai;

                // Cập nhật lớp học (quan hệ 1 - n)
                if (sv.LopHoc != svCapNhat.LopHoc)
                {
                    sv.LopHoc?.DanhSachSinhVien.Remove(sv);
                    sv.LopHoc = svCapNhat.LopHoc;
                    sv.MaLop = svCapNhat.MaLop;
                    sv.TenLop = svCapNhat.TenLop;
                    sv.LopHoc?.DanhSachSinhVien.Add(sv);
                }

                MessageBox.Show("Cập nhật thông tin sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                HienThiDanhSach(listSinhVien);
            }
        }
        #endregion

        #region Chức năng Thêm mới sinh viên
        private void buttonThem_Click(object? sender, EventArgs e)
        {
            string maSV = txtmasinhvien.Text.Trim();
            if (string.IsNullOrEmpty(maSV))
            {
                MessageBox.Show("Vui lòng nhập mã sinh viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtmasinhvien.Focus();
                return;
            }

            // Kiểm tra trùng mã
            if (listSinhVien.Any(s => string.Equals(s.MaSV.Trim(), maSV, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show($"Mã sinh viên '{maSV}' đã tồn tại trong danh sách!", "Trùng mã sinh viên", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtmasinhvien.Focus();
                return;
            }

            var lopChon = cbolophoc.SelectedItem as LopHoc;
            if (lopChon == null)
            {
                MessageBox.Show("Vui lòng chọn lớp học cho sinh viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tạo đối tượng sinh viên mới
            var svMoi = new SinhVien
            {
                MaSV = maSV,
                HoTen = txthoten.Text.Trim(),
                NgaySinh = dateTimePicker1.Value,
                GioiTinh = Nu.Checked ? "Nữ" : "Nam",
                Email = txtemail.Text.Trim(),
                DienThoai = txtsodienthoai.Text.Trim(),
                Diem = (double)numberdiem.Value,
                MaLop = lopChon.MaLop,
                TenLop = lopChon.TenLop,
                TrangThai = cbotrangthai.SelectedItem?.ToString() ?? "Đang học",
                LopHoc = lopChon
            };

            // Kiểm tra hợp lệ bằng Data Annotations theo Yêu cầu 2
            if (!svMoi.KiemTraHopLe(out List<string> errors))
            {
                string thongBaoLoi = string.Join("\n• ", errors);
                MessageBox.Show("Dữ liệu nhập chưa hợp lệ:\n• " + thongBaoLoi, "Lỗi kiểm tra dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Thêm vào quan hệ 1 - n: Lớp học có nhiều sinh viên
            lopChon.DanhSachSinhVien.Add(svMoi);
            listSinhVien.Add(svMoi);

            MessageBox.Show("Thêm mới sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Cập nhật hiển thị
            HienThiDanhSach(listSinhVien);
            buttonLamMoi_Click(sender, e);
        }
        #endregion

        #region Chức năng Tìm kiếm & Lọc
        private void buttonTimkiem_Click(object? sender, EventArgs e)
        {
            string tuKhoa = txttukhoa.Text.Trim().ToLower();
            string lopDaChon = cbolophoctimkiem.SelectedItem?.ToString() ?? "Tất cả lớp";

            double diemTu = 0.0;
            double.TryParse(txtdemtu.Text.Trim(), NumberStyles.Any, CultureInfo.InvariantCulture, out diemTu);

            var ketQua = listSinhVien.Where(sv =>
            {
                // Lọc theo từ khóa (Mã SV, Họ tên, Email, SĐT)
                bool khopTuKhoa = string.IsNullOrEmpty(tuKhoa) ||
                                  sv.MaSV.ToLower().Contains(tuKhoa) ||
                                  sv.HoTen.ToLower().Contains(tuKhoa) ||
                                  sv.Email.ToLower().Contains(tuKhoa) ||
                                  sv.DienThoai.ToLower().Contains(tuKhoa);

                // Lọc theo lớp học
                bool khopLop = (lopDaChon == "Tất cả lớp") ||
                               sv.TenLop.Equals(lopDaChon, StringComparison.OrdinalIgnoreCase);

                // Lọc theo điểm từ
                bool khopDiem = sv.Diem >= diemTu;

                return khopTuKhoa && khopLop && khopDiem;
            }).ToList();

            HienThiDanhSach(ketQua);
        }

        private void buttonHienthi_Click(object? sender, EventArgs e)
        {
            txttukhoa.Clear();
            txtdemtu.Text = "0.0";
            if (cbolophoctimkiem.Items.Count > 0) cbolophoctimkiem.SelectedIndex = 0;
            HienThiDanhSach(listSinhVien);
        }
        #endregion

        #region Sự kiện chọn dòng trên DataGridView
        private void dataGridView1_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                var row = dataGridView1.Rows[e.RowIndex];
                if (row.DataBoundItem is SinhVien sv)
                {
                    // Điền mã sinh viên vào ô txtmasinhvien -> kích hoạt txtmasinhvien_TextChanged
                    txtmasinhvien.Text = sv.MaSV;
                }
            }
        }
        #endregion

        #region Xác thực thoát ứng dụng (Chức năng nguy hiểm)
        private void srmquanlysinhvien_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                var result = MessageBox.Show(
                    "Bạn có chắc chắn muốn thoát ứng dụng không?",
                    "Xác nhận thoát",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result != DialogResult.Yes)
                {
                    e.Cancel = true;
                }
            }
        }
        #endregion

        private void buttonThem_Click_1(object sender, EventArgs e)
        {
            
        }

        private void lblBatBuoc_Click(object sender, EventArgs e)
        {

        }

        private void lblHuongDan_Click(object sender, EventArgs e)
        {

        }

        private void lblFooterLeft_Click(object sender, EventArgs e)
        {

        }

        private void srmquanlysinhvien_Load_1(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        private class StudentView
        {
            public string StudentId { get; set; } = string.Empty;
            public string FullName { get; set; } = string.Empty;
            public string Email { get; set; } = string.Empty;
            public string DateOfBirth { get; set; } = string.Empty;
            public string Phone { get; set; } = string.Empty;
            public double Score { get; set; }
            public string Status { get; set; } = string.Empty;
            public string Classes { get; set; } = string.Empty;
        }
    }
}