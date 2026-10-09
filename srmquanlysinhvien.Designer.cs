namespace QuanlySinhVienApp
{
    partial class srmquanlysinhvien
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            lblTitle = new Label();
            lblSubtitle = new Label();
            groupBox1 = new GroupBox();
            lblThongTinSV = new Label();
            buttonLamMoi = new Button();
            buttonXoa = new Button();
            buttonSua = new Button();
            buttonThem = new Button();
            cbotrangthai = new ComboBox();
            trangthai = new Label();
            txtsodienthoai = new TextBox();
            sodienthoai = new Label();
            txtemail = new TextBox();
            email = new Label();
            numberdiem = new NumericUpDown();
            diem = new Label();
            Nu = new RadioButton();
            Nam = new RadioButton();
            gioitinh = new Label();
            dateTimePicker1 = new DateTimePicker();
            ngaysinh = new Label();
            cbolophoc = new ComboBox();
            lophoc = new Label();
            txthoten = new TextBox();
            hoten = new Label();
            txtmasinhvien = new TextBox();
            masinhvien = new Label();
            groupBox2 = new GroupBox();
            buttonHienthi = new Button();
            buttonTimkiem = new Button();
            txtdemtu = new TextBox();
            demtu = new Label();
            cbolophoctimkiem = new ComboBox();
            lophoctimkiem = new Label();
            txttukhoa = new TextBox();
            tukhoa = new Label();
            groupBox3 = new GroupBox();
            lblBatBuoc = new Label();
            lblHuongDan = new Label();
            Tongso = new Label();
            lblDanhSach = new Label();
            dataGridView1 = new DataGridView();
            lblFooterRight = new Label();
            lblFooterLeft = new Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numberdiem).BeginInit();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(16, 50, 100);
            lblTitle.Location = new Point(20, 12);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(275, 37);
            lblTitle.TabIndex = 90;
            lblTitle.Text = "QUẢN LÝ SINH VIÊN";
            // 
            // lblSubtitle
            // 
            lblSubtitle.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 9F);
            lblSubtitle.ForeColor = Color.FromArgb(100, 116, 139);
            lblSubtitle.Location = new Point(605, 26);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(405, 20);
            lblSubtitle.TabIndex = 91;
            lblSubtitle.Text = "Bài tập Windows Forms • Quan hệ SchoolClass 1 - n Student";
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.BackColor = Color.White;
            groupBox1.Controls.Add(lblThongTinSV);
            groupBox1.Controls.Add(buttonLamMoi);
            groupBox1.Controls.Add(buttonXoa);
            groupBox1.Controls.Add(buttonSua);
            groupBox1.Controls.Add(buttonThem);
            groupBox1.Controls.Add(cbotrangthai);
            groupBox1.Controls.Add(trangthai);
            groupBox1.Controls.Add(txtsodienthoai);
            groupBox1.Controls.Add(sodienthoai);
            groupBox1.Controls.Add(txtemail);
            groupBox1.Controls.Add(email);
            groupBox1.Controls.Add(numberdiem);
            groupBox1.Controls.Add(diem);
            groupBox1.Controls.Add(Nu);
            groupBox1.Controls.Add(Nam);
            groupBox1.Controls.Add(gioitinh);
            groupBox1.Controls.Add(dateTimePicker1);
            groupBox1.Controls.Add(ngaysinh);
            groupBox1.Controls.Add(cbolophoc);
            groupBox1.Controls.Add(lophoc);
            groupBox1.Controls.Add(txthoten);
            groupBox1.Controls.Add(hoten);
            groupBox1.Controls.Add(txtmasinhvien);
            groupBox1.Controls.Add(masinhvien);
            groupBox1.Location = new Point(20, 52);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(990, 186);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            // 
            // lblThongTinSV
            // 
            lblThongTinSV.AutoSize = true;
            lblThongTinSV.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblThongTinSV.ForeColor = Color.FromArgb(30, 41, 59);
            lblThongTinSV.Location = new Point(16, 8);
            lblThongTinSV.Name = "lblThongTinSV";
            lblThongTinSV.Size = new Size(176, 25);
            lblThongTinSV.TabIndex = 81;
            lblThongTinSV.Text = "Thông tin sinh viên";
            // 
            // buttonLamMoi
            // 
            buttonLamMoi.BackColor = Color.FromArgb(71, 85, 105);
            buttonLamMoi.Cursor = Cursors.Hand;
            buttonLamMoi.FlatAppearance.BorderSize = 0;
            buttonLamMoi.FlatStyle = FlatStyle.Flat;
            buttonLamMoi.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonLamMoi.ForeColor = Color.White;
            buttonLamMoi.Location = new Point(875, 145);
            buttonLamMoi.Name = "buttonLamMoi";
            buttonLamMoi.Size = new Size(95, 32);
            buttonLamMoi.TabIndex = 13;
            buttonLamMoi.Text = "Làm mới";
            buttonLamMoi.UseVisualStyleBackColor = false;
            // 
            // buttonXoa
            // 
            buttonXoa.BackColor = Color.FromArgb(220, 53, 69);
            buttonXoa.Cursor = Cursors.Hand;
            buttonXoa.FlatAppearance.BorderSize = 0;
            buttonXoa.FlatStyle = FlatStyle.Flat;
            buttonXoa.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonXoa.ForeColor = Color.White;
            buttonXoa.Location = new Point(785, 145);
            buttonXoa.Name = "buttonXoa";
            buttonXoa.Size = new Size(82, 32);
            buttonXoa.TabIndex = 12;
            buttonXoa.Text = "Xóa";
            buttonXoa.UseVisualStyleBackColor = false;
            // 
            // buttonSua
            // 
            buttonSua.BackColor = Color.FromArgb(13, 110, 253);
            buttonSua.Cursor = Cursors.Hand;
            buttonSua.FlatAppearance.BorderSize = 0;
            buttonSua.FlatStyle = FlatStyle.Flat;
            buttonSua.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonSua.ForeColor = Color.White;
            buttonSua.Location = new Point(695, 145);
            buttonSua.Name = "buttonSua";
            buttonSua.Size = new Size(82, 32);
            buttonSua.TabIndex = 11;
            buttonSua.Text = "Sửa";
            buttonSua.UseVisualStyleBackColor = false;
            // 
            // buttonThem
            // 
            buttonThem.BackColor = Color.FromArgb(25, 135, 84);
            buttonThem.Cursor = Cursors.Hand;
            buttonThem.FlatAppearance.BorderSize = 0;
            buttonThem.FlatStyle = FlatStyle.Flat;
            buttonThem.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonThem.ForeColor = Color.White;
            buttonThem.Location = new Point(605, 145);
            buttonThem.Name = "buttonThem";
            buttonThem.Size = new Size(82, 32);
            buttonThem.TabIndex = 10;
            buttonThem.Text = "Thêm";
            buttonThem.UseVisualStyleBackColor = false;
            buttonThem.Click += buttonThem_Click_1;
            // 
            // cbotrangthai
            // 
            cbotrangthai.DropDownStyle = ComboBoxStyle.DropDownList;
            cbotrangthai.FormattingEnabled = true;
            cbotrangthai.Location = new Point(715, 110);
            cbotrangthai.Name = "cbotrangthai";
            cbotrangthai.Size = new Size(255, 28);
            cbotrangthai.TabIndex = 9;
            // 
            // trangthai
            // 
            trangthai.AutoSize = true;
            trangthai.Location = new Point(635, 113);
            trangthai.Name = "trangthai";
            trangthai.Size = new Size(75, 20);
            trangthai.TabIndex = 82;
            trangthai.Text = "Trạng thái";
            // 
            // txtsodienthoai
            // 
            txtsodienthoai.Location = new Point(415, 110);
            txtsodienthoai.Name = "txtsodienthoai";
            txtsodienthoai.Size = new Size(200, 27);
            txtsodienthoai.TabIndex = 8;
            // 
            // sodienthoai
            // 
            sodienthoai.AutoSize = true;
            sodienthoai.Location = new Point(325, 113);
            sodienthoai.Name = "sodienthoai";
            sodienthoai.Size = new Size(88, 20);
            sodienthoai.TabIndex = 83;
            sodienthoai.Text = "Điện thoại *";
            // 
            // txtemail
            // 
            txtemail.Location = new Point(120, 110);
            txtemail.Name = "txtemail";
            txtemail.Size = new Size(190, 27);
            txtemail.TabIndex = 7;
            // 
            // email
            // 
            email.AutoSize = true;
            email.Location = new Point(16, 113);
            email.Name = "email";
            email.Size = new Size(56, 20);
            email.TabIndex = 84;
            email.Text = "Email *";
            // 
            // numberdiem
            // 
            numberdiem.DecimalPlaces = 1;
            numberdiem.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            numberdiem.Location = new Point(715, 73);
            numberdiem.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            numberdiem.Name = "numberdiem";
            numberdiem.Size = new Size(255, 27);
            numberdiem.TabIndex = 6;
            // 
            // diem
            // 
            diem.AutoSize = true;
            diem.Location = new Point(635, 76);
            diem.Name = "diem";
            diem.Size = new Size(55, 20);
            diem.TabIndex = 85;
            diem.Text = "Điểm *";
            // 
            // Nu
            // 
            Nu.AutoSize = true;
            Nu.Location = new Point(495, 74);
            Nu.Name = "Nu";
            Nu.Size = new Size(50, 24);
            Nu.TabIndex = 5;
            Nu.Text = "Nữ";
            Nu.UseVisualStyleBackColor = true;
            // 
            // Nam
            // 
            Nam.AutoSize = true;
            Nam.Checked = true;
            Nam.Location = new Point(418, 74);
            Nam.Name = "Nam";
            Nam.Size = new Size(62, 24);
            Nam.TabIndex = 4;
            Nam.TabStop = true;
            Nam.Text = "Nam";
            Nam.UseVisualStyleBackColor = true;
            // 
            // gioitinh
            // 
            gioitinh.AutoSize = true;
            gioitinh.Location = new Point(325, 76);
            gioitinh.Name = "gioitinh";
            gioitinh.Size = new Size(65, 20);
            gioitinh.TabIndex = 86;
            gioitinh.Text = "Giới tính";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.Location = new Point(120, 73);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(190, 27);
            dateTimePicker1.TabIndex = 3;
            // 
            // ngaysinh
            // 
            ngaysinh.AutoSize = true;
            ngaysinh.Location = new Point(16, 76);
            ngaysinh.Name = "ngaysinh";
            ngaysinh.Size = new Size(74, 20);
            ngaysinh.TabIndex = 87;
            ngaysinh.Text = "Ngày sinh";
            // 
            // cbolophoc
            // 
            cbolophoc.DropDownStyle = ComboBoxStyle.DropDownList;
            cbolophoc.FormattingEnabled = true;
            cbolophoc.Location = new Point(715, 36);
            cbolophoc.Name = "cbolophoc";
            cbolophoc.Size = new Size(255, 28);
            cbolophoc.TabIndex = 2;
            // 
            // lophoc
            // 
            lophoc.AutoSize = true;
            lophoc.Location = new Point(635, 39);
            lophoc.Name = "lophoc";
            lophoc.Size = new Size(72, 20);
            lophoc.TabIndex = 88;
            lophoc.Text = "Lớp học *";
            // 
            // txthoten
            // 
            txthoten.Location = new Point(415, 36);
            txthoten.Name = "txthoten";
            txthoten.Size = new Size(200, 27);
            txthoten.TabIndex = 1;
            // 
            // hoten
            // 
            hoten.AutoSize = true;
            hoten.Location = new Point(325, 39);
            hoten.Name = "hoten";
            hoten.Size = new Size(83, 20);
            hoten.TabIndex = 89;
            hoten.Text = "Họ và tên *";
            // 
            // txtmasinhvien
            // 
            txtmasinhvien.Location = new Point(120, 36);
            txtmasinhvien.Name = "txtmasinhvien";
            txtmasinhvien.Size = new Size(190, 27);
            txtmasinhvien.TabIndex = 0;
            // 
            // masinhvien
            // 
            masinhvien.AutoSize = true;
            masinhvien.Location = new Point(16, 39);
            masinhvien.Name = "masinhvien";
            masinhvien.Size = new Size(101, 20);
            masinhvien.TabIndex = 90;
            masinhvien.Text = "Mã sinh viên *";
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox2.BackColor = Color.White;
            groupBox2.Controls.Add(buttonHienthi);
            groupBox2.Controls.Add(buttonTimkiem);
            groupBox2.Controls.Add(txtdemtu);
            groupBox2.Controls.Add(demtu);
            groupBox2.Controls.Add(cbolophoctimkiem);
            groupBox2.Controls.Add(lophoctimkiem);
            groupBox2.Controls.Add(txttukhoa);
            groupBox2.Controls.Add(tukhoa);
            groupBox2.Location = new Point(20, 244);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(990, 52);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            // 
            // buttonHienthi
            // 
            buttonHienthi.BackColor = Color.White;
            buttonHienthi.Cursor = Cursors.Hand;
            buttonHienthi.FlatAppearance.BorderColor = Color.FromArgb(206, 212, 218);
            buttonHienthi.FlatStyle = FlatStyle.Flat;
            buttonHienthi.ForeColor = Color.FromArgb(30, 41, 59);
            buttonHienthi.Location = new Point(860, 14);
            buttonHienthi.Name = "buttonHienthi";
            buttonHienthi.Size = new Size(124, 30);
            buttonHienthi.TabIndex = 18;
            buttonHienthi.Text = "Hiển thị tất cả";
            buttonHienthi.UseVisualStyleBackColor = false;
            // 
            // buttonTimkiem
            // 
            buttonTimkiem.BackColor = Color.FromArgb(13, 110, 253);
            buttonTimkiem.Cursor = Cursors.Hand;
            buttonTimkiem.FlatAppearance.BorderSize = 0;
            buttonTimkiem.FlatStyle = FlatStyle.Flat;
            buttonTimkiem.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonTimkiem.ForeColor = Color.White;
            buttonTimkiem.Location = new Point(760, 14);
            buttonTimkiem.Name = "buttonTimkiem";
            buttonTimkiem.Size = new Size(92, 30);
            buttonTimkiem.TabIndex = 17;
            buttonTimkiem.Text = "Tìm kiếm";
            buttonTimkiem.UseVisualStyleBackColor = false;
            // 
            // txtdemtu
            // 
            txtdemtu.Location = new Point(675, 15);
            txtdemtu.Name = "txtdemtu";
            txtdemtu.Size = new Size(70, 27);
            txtdemtu.TabIndex = 16;
            txtdemtu.Text = "0.0";
            // 
            // demtu
            // 
            demtu.AutoSize = true;
            demtu.Location = new Point(610, 18);
            demtu.Name = "demtu";
            demtu.Size = new Size(63, 20);
            demtu.TabIndex = 23;
            demtu.Text = "Điểm từ";
            // 
            // cbolophoctimkiem
            // 
            cbolophoctimkiem.DropDownStyle = ComboBoxStyle.DropDownList;
            cbolophoctimkiem.FormattingEnabled = true;
            cbolophoctimkiem.Location = new Point(405, 15);
            cbolophoctimkiem.Name = "cbolophoctimkiem";
            cbolophoctimkiem.Size = new Size(190, 28);
            cbolophoctimkiem.TabIndex = 15;
            // 
            // lophoctimkiem
            // 
            lophoctimkiem.AutoSize = true;
            lophoctimkiem.Location = new Point(365, 18);
            lophoctimkiem.Name = "lophoctimkiem";
            lophoctimkiem.Size = new Size(34, 20);
            lophoctimkiem.TabIndex = 22;
            lophoctimkiem.Text = "Lớp";
            // 
            // txttukhoa
            // 
            txttukhoa.Location = new Point(80, 15);
            txttukhoa.Name = "txttukhoa";
            txttukhoa.PlaceholderText = "Mã, họ tên, email hoặc điện thoại";
            txttukhoa.Size = new Size(270, 27);
            txttukhoa.TabIndex = 14;
            // 
            // tukhoa
            // 
            tukhoa.AutoSize = true;
            tukhoa.Location = new Point(16, 18);
            tukhoa.Name = "tukhoa";
            tukhoa.Size = new Size(62, 20);
            tukhoa.TabIndex = 4;
            tukhoa.Text = "Từ khóa";
            // 
            // groupBox3
            // 
            groupBox3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox3.BackColor = Color.White;
            groupBox3.Controls.Add(lblBatBuoc);
            groupBox3.Controls.Add(lblHuongDan);
            groupBox3.Controls.Add(Tongso);
            groupBox3.Controls.Add(lblDanhSach);
            groupBox3.Controls.Add(dataGridView1);
            groupBox3.Location = new Point(20, 302);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(990, 244);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            // 
            // lblBatBuoc
            // 
            lblBatBuoc.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblBatBuoc.AutoSize = true;
            lblBatBuoc.ForeColor = Color.FromArgb(100, 116, 139);
            lblBatBuoc.Location = new Point(767, 216);
            lblBatBuoc.Name = "lblBatBuoc";
            lblBatBuoc.Size = new Size(223, 20);
            lblBatBuoc.TabIndex = 25;
            lblBatBuoc.Text = "Các trường có dấu * là bắt buộc.";
            lblBatBuoc.Click += lblBatBuoc_Click;
            // 
            // lblHuongDan
            // 
            lblHuongDan.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblHuongDan.AutoSize = true;
            lblHuongDan.ForeColor = Color.FromArgb(100, 116, 139);
            lblHuongDan.Location = new Point(0, 221);
            lblHuongDan.Name = "lblHuongDan";
            lblHuongDan.Size = new Size(388, 20);
            lblHuongDan.TabIndex = 24;
            lblHuongDan.Text = "Chọn một dòng để xem, sửa hoặc xóa thông tin sinh viên.";
            lblHuongDan.Click += lblHuongDan_Click;
            // 
            // Tongso
            // 
            Tongso.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            Tongso.AutoSize = true;
            Tongso.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            Tongso.ForeColor = Color.FromArgb(30, 41, 59);
            Tongso.Location = new Point(831, 15);
            Tongso.Name = "Tongso";
            Tongso.Size = new Size(148, 20);
            Tongso.TabIndex = 23;
            Tongso.Text = "Tổng số: 4 sinh viên";
            // 
            // lblDanhSach
            // 
            lblDanhSach.AutoSize = true;
            lblDanhSach.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblDanhSach.ForeColor = Color.FromArgb(30, 41, 59);
            lblDanhSach.Location = new Point(16, 12);
            lblDanhSach.Name = "lblDanhSach";
            lblDanhSach.Size = new Size(181, 25);
            lblDanhSach.TabIndex = 22;
            lblDanhSach.Text = "Danh sách sinh viên";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(224, 242, 254);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(3, 105, 161);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(224, 242, 254);
            dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(3, 105, 161);
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersHeight = 36;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(30, 41, 59);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(186, 230, 253);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(15, 23, 42);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.GridColor = Color.FromArgb(241, 245, 249);
            dataGridView1.Location = new Point(16, 42);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 51;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(248, 250, 252);
            dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle3;
            dataGridView1.RowTemplate.Height = 32;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(960, 164);
            dataGridView1.TabIndex = 19;
            // 
            // lblFooterRight
            // 
            lblFooterRight.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblFooterRight.AutoSize = true;
            lblFooterRight.ForeColor = Color.FromArgb(100, 116, 139);
            lblFooterRight.Location = new Point(706, 554);
            lblFooterRight.Name = "lblFooterRight";
            lblFooterRight.Size = new Size(297, 20);
            lblFooterRight.TabIndex = 93;
            lblFooterRight.Text = "Thêm • Sửa • Xóa • Tìm kiếm • Lọc theo lớp";
            // 
            // lblFooterLeft
            // 
            lblFooterLeft.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblFooterLeft.AutoSize = true;
            lblFooterLeft.ForeColor = Color.FromArgb(100, 116, 139);
            lblFooterLeft.Location = new Point(20, 554);
            lblFooterLeft.Name = "lblFooterLeft";
            lblFooterLeft.Size = new Size(406, 20);
            lblFooterLeft.TabIndex = 92;
            lblFooterLeft.Text = "Bài tập: xây dựng Windows Forms quản lý sinh viên theo lớp";
            lblFooterLeft.Click += lblFooterLeft_Click;
            // 
            // srmquanlysinhvien
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(1030, 584);
            Controls.Add(lblFooterRight);
            Controls.Add(lblFooterLeft);
            Controls.Add(lblSubtitle);
            Controls.Add(lblTitle);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            MinimumSize = new Size(980, 600);
            Name = "srmquanlysinhvien";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Ứng dụng quản lý sinh viên";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numberdiem).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblThongTinSV;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox txtmasinhvien;
        private System.Windows.Forms.Label masinhvien;
        private System.Windows.Forms.RadioButton Nam;
        private System.Windows.Forms.RadioButton Nu;
        private System.Windows.Forms.NumericUpDown numberdiem;
        private System.Windows.Forms.Label ngaysinh;
        private System.Windows.Forms.TextBox txtemail;
        private System.Windows.Forms.Label email;
        private System.Windows.Forms.Label diem;
        private System.Windows.Forms.Label gioitinh;
        private System.Windows.Forms.Label lophoc;
        private System.Windows.Forms.TextBox txtsodienthoai;
        private System.Windows.Forms.Label sodienthoai;
        private System.Windows.Forms.ComboBox cbolophoc;
        private System.Windows.Forms.ComboBox cbotrangthai;
        private System.Windows.Forms.TextBox txthoten;
        private System.Windows.Forms.Label hoten;
        private System.Windows.Forms.Label trangthai;
        private System.Windows.Forms.Button buttonThem;
        private System.Windows.Forms.Button buttonLamMoi;
        private System.Windows.Forms.Button buttonXoa;
        private System.Windows.Forms.Button buttonSua;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lophoctimkiem;
        private System.Windows.Forms.TextBox txttukhoa;
        private System.Windows.Forms.ComboBox cbolophoctimkiem;
        private System.Windows.Forms.Label tukhoa;
        private System.Windows.Forms.TextBox txtdemtu;
        private System.Windows.Forms.Label demtu;
        private System.Windows.Forms.Button buttonHienthi;
        private System.Windows.Forms.Button buttonTimkiem;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label Tongso;
        private System.Windows.Forms.Label lblDanhSach;
        private System.Windows.Forms.Label lblHuongDan;
        private Label lblBatBuoc;
        private Label lblFooterRight;
        private Label lblFooterLeft;
    }
}