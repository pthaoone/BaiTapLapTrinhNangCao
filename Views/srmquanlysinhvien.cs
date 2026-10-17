using QuanlySinhVienApp.BUL;
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
        // Tầng Business nghiệp vụ
        private readonly SinhVienBUL sinhVienBUL = new SinhVienBUL();
        private readonly LopBus lopBus = new LopBus();

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

        #region Yêu cầu 3: Khi FormLoad
        private void srmquanlysinhvien_Load(object? sender, EventArgs e)
        {
            try
            {
                // 3.a Thiết lập button enable phù hợp
                buttonThem.Enabled = true;
                buttonSua.Enabled = false;
                buttonXoa.Enabled = false;
                buttonLamMoi.Enabled = true;

                // 3.b Lấy về danh sách lớp học từ CSDL qua tầng Business hiển thị combobox
                listLopHoc = lopBus.GetAllLopHoc();
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

                // 3.c Lấy về danh sách sinh viên từ CSDL qua tầng Business hiển thị lên DataGridView
                LoadDanhSachSinhVien();

                // 3.a Con trỏ thiết lập mặc định ở txtMaSV
                this.ActiveControl = txtmasinhvien;
                txtmasinhvien.Focus();
            }
            catch (Exception ex)
            {
                // Tầng View xử lý ngoại lệ
                MessageBox.Show("Lỗi khi tải dữ liệu từ CSDL:\n" + ex.Message, "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        /// <summary>
        /// Nạp danh sách sinh viên từ CSDL qua tầng Business và gán tên lớp
        /// </summary>
        private void LoadDanhSachSinhVien()
        {
            try
            {
                listSinhVien = sinhVienBUL.GetAllSinhVien();
                foreach (var sv in listSinhVien)
                {
                    if (string.IsNullOrEmpty(sv.TenLop))
                    {
                        var lop = listLopHoc.FirstOrDefault(l => string.Equals(l.MaLop, sv.MaLop, StringComparison.OrdinalIgnoreCase));
                        if (lop != null)
                        {
                            sv.TenLop = lop.TenLop;
                            sv.LopHoc = lop;
                        }
                    }
                }
                HienThiDanhSach(listSinhVien);
            }
            catch (Exception ex)
            {
                // Tầng View xử lý ngoại lệ
                MessageBox.Show("Lỗi tải danh sách sinh viên:\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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

            try
            {
                string maSV = txtmasinhvien.Text.Trim();

                if (string.IsNullOrEmpty(maSV))
                {
                    if (_isStudentFound)
                    {
                        _isBindingData = true;
                        XoaThongTinChiTiet();
                        _isStudentFound = false;
                        buttonThem.Enabled = true;
                        buttonSua.Enabled = false;
                        buttonXoa.Enabled = false;
                        _isBindingData = false;
                    }
                    return;
                }

                // Tìm kiếm sinh viên theo mã trong danh sách hoặc từ CSDL qua tầng Business
                var sv = listSinhVien.FirstOrDefault(s => string.Equals(s.MaSV.Trim(), maSV, StringComparison.OrdinalIgnoreCase));
                if (sv == null)
                {
                    sv = sinhVienBUL.GetSinhVienById(maSV);
                }

                if (sv != null)
                {
                    // Nếu mã sinh viên tồn tại: lấy thông tin sinh viên hiển thị tương ứng lên các điều khiển còn lại
                    _isBindingData = true;
                    _isStudentFound = true;

                    txthoten.Text = sv.HoTen;
                    if (sv.NgaySinh >= dateTimePicker1.MinDate && sv.NgaySinh <= dateTimePicker1.MaxDate)
                    {
                        dateTimePicker1.Value = sv.NgaySinh;
                    }
                    else
                    {
                        dateTimePicker1.Value = DateTime.Today;
                    }

                    if (sv.GioiTinh == "Nữ" || sv.GioiTinh == "Nu")
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
            catch (Exception ex)
            {
                // Tầng View xử lý ngoại lệ
                MessageBox.Show("Lỗi khi tìm kiếm thông tin sinh viên:\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            try
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

                // Tải lại toàn bộ danh sách từ CSDL
                LoadDanhSachSinhVien();

                // Enable button Nhập (Thêm), Disable button sửa xóa
                buttonThem.Enabled = true;
                buttonSua.Enabled = false;
                buttonXoa.Enabled = false;

                // Chuyển tiêu điểm về điều khiển txtMaSV
                this.ActiveControl = txtmasinhvien;
                txtmasinhvien.Focus();
            }
            catch (Exception ex)
            {
                // Tầng View xử lý ngoại lệ
                MessageBox.Show("Lỗi khi làm mới dữ liệu:\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Yêu cầu 6: Chức năng Xóa (Thao tác CSDL qua Business Layer -> Tầng View xử lý ngoại lệ)
        private void buttonXoa_Click(object? sender, EventArgs e)
        {
            try
            {
                string maSV = txtmasinhvien.Text.Trim();
                if (string.IsNullOrEmpty(maSV))
                {
                    MessageBox.Show("Vui lòng chọn hoặc nhập mã sinh viên cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Yêu cầu xác thực trước khi thực hiện hành động nguy hiểm
                var result = MessageBox.Show(
                    $"Bạn có chắc chắn muốn XÓA sinh viên có mã '{maSV}' khỏi cơ sở dữ liệu?\n\nHành động này không thể hoàn tác!",
                    "Xác nhận xóa dữ liệu nguy hiểm",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button2
                );

                if (result == DialogResult.Yes)
                {
                    // Gọi tầng Business để xóa (nếu có lỗi sẽ ném ngoại lệ về View)
                    sinhVienBUL.DeleteSinhVien(maSV);

                    MessageBox.Show("Đã xóa sinh viên khỏi cơ sở dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Tải lại danh sách từ CSDL và làm mới giao diện
                    LoadDanhSachSinhVien();
                    buttonLamMoi_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                // Tầng View xử lý ngoại lệ
                MessageBox.Show("Lỗi khi xóa sinh viên:\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Yêu cầu 6: Chức năng Sửa (Thao tác CSDL qua Business Layer -> Tầng View xử lý ngoại lệ)
        private void buttonSua_Click(object? sender, EventArgs e)
        {
            try
            {
                string maSV = txtmasinhvien.Text.Trim();
                if (string.IsNullOrEmpty(maSV))
                {
                    MessageBox.Show("Vui lòng nhập hoặc chọn mã sinh viên cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var lopChon = cbolophoc.SelectedItem as LopHoc;
                if (lopChon == null)
                {
                    MessageBox.Show("Vui lòng chọn lớp học cho sinh viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Tạo đối tượng cập nhật
                var svCapNhat = new SinhVien
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

                // Xác thực trước khi cập nhật
                var result = MessageBox.Show(
                    $"Bạn có chắc chắn muốn CẬP NHẬT thông tin cho sinh viên '{svCapNhat.MaSV}' ({svCapNhat.HoTen})?",
                    "Xác nhận cập nhật thông tin",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    // Gọi tầng Business để cập nhật (nếu có lỗi sẽ ném ngoại lệ về View)
                    sinhVienBUL.UpdateSinhVien(svCapNhat);

                    MessageBox.Show("Cập nhật thông tin sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Tải lại danh sách từ CSDL
                    LoadDanhSachSinhVien();
                }
            }
            catch (Exception ex)
            {
                // Tầng View xử lý ngoại lệ
                MessageBox.Show("Lỗi khi cập nhật sinh viên:\n" + ex.Message, "Lỗi cập nhật", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Chức năng Thêm mới sinh viên (Thao tác CSDL qua Business Layer -> Tầng View xử lý ngoại lệ)
        private void buttonThem_Click(object? sender, EventArgs e)
        {
            try
            {
                string maSV = txtmasinhvien.Text.Trim();
                if (string.IsNullOrEmpty(maSV))
                {
                    MessageBox.Show("Vui lòng nhập mã sinh viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                // Gọi tầng Business để thêm mới (nếu có lỗi validate hoặc CSDL sẽ ném ngoại lệ)
                sinhVienBUL.AddSinhVien(svMoi);

                MessageBox.Show("Thêm mới sinh viên vào cơ sở dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Cập nhật lại hiển thị từ CSDL
                LoadDanhSachSinhVien();
                buttonLamMoi_Click(sender, e);
            }
            catch (Exception ex)
            {
                // Tầng View xử lý ngoại lệ
                MessageBox.Show("Lỗi khi thêm mới sinh viên:\n" + ex.Message, "Lỗi thêm mới", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Chức năng Tìm kiếm & Lọc
        private void buttonTimkiem_Click(object? sender, EventArgs e)
        {
            try
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
                                   sv.TenLop.Equals(lopDaChon, StringComparison.OrdinalIgnoreCase) ||
                                   sv.MaLop.Equals(lopDaChon, StringComparison.OrdinalIgnoreCase);

                    // Lọc theo điểm từ
                    bool khopDiem = sv.Diem >= diemTu;

                    return khopTuKhoa && khopLop && khopDiem;
                }).ToList();

                HienThiDanhSach(ketQua);
            }
            catch (Exception ex)
            {
                // Tầng View xử lý ngoại lệ
                MessageBox.Show("Lỗi khi tìm kiếm:\n" + ex.Message, "Lỗi tìm kiếm", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonHienthi_Click(object? sender, EventArgs e)
        {
            try
            {
                txttukhoa.Clear();
                txtdemtu.Text = "0.0";
                if (cbolophoctimkiem.Items.Count > 0) cbolophoctimkiem.SelectedIndex = 0;
                LoadDanhSachSinhVien();
            }
            catch (Exception ex)
            {
                // Tầng View xử lý ngoại lệ
                MessageBox.Show("Lỗi khi tải lại danh sách:\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Sự kiện chọn dòng trên DataGridView
        private void dataGridView1_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                // Tầng View xử lý ngoại lệ
                MessageBox.Show("Lỗi khi chọn dòng dữ liệu:\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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