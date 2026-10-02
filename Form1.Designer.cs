namespace QuanlySinhVienApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            SoA = new Label();
            txtsoa = new TextBox();
            txtsob = new TextBox();
            SoB = new Label();
            buttonCong = new Button();
            buttonNhan = new Button();
            buttonTru = new Button();
            buttonChia = new Button();
            txtketqua = new TextBox();
            Ketqua = new Label();
            SuspendLayout();
            // 
            // SoA
            // 
            SoA.AutoSize = true;
            SoA.Font = new Font("Segoe UI", 18F);
            SoA.Location = new Point(37, 44);
            SoA.Name = "SoA";
            SoA.Size = new Size(82, 41);
            SoA.TabIndex = 0;
            SoA.Text = "Số a:";
            // 
            // txtsoa
            // 
            txtsoa.Location = new Point(166, 56);
            txtsoa.Name = "txtsoa";
            txtsoa.Size = new Size(269, 27);
            txtsoa.TabIndex = 1;
            txtsoa.TextChanged += txtsoa_TextChanged;
            // 
            // txtsob
            // 
            txtsob.Location = new Point(166, 143);
            txtsob.Name = "txtsob";
            txtsob.Size = new Size(269, 27);
            txtsob.TabIndex = 3;
            txtsob.TextChanged += textBox1_TextChanged;
            // 
            // SoB
            // 
            SoB.AutoSize = true;
            SoB.Font = new Font("Segoe UI", 18F);
            SoB.Location = new Point(37, 129);
            SoB.Name = "SoB";
            SoB.Size = new Size(85, 41);
            SoB.TabIndex = 2;
            SoB.Text = "Số b:";
            // 
            // buttonCong
            // 
            buttonCong.Location = new Point(476, 56);
            buttonCong.Name = "buttonCong";
            buttonCong.Size = new Size(94, 29);
            buttonCong.TabIndex = 4;
            buttonCong.Text = "Cộng";
            buttonCong.UseVisualStyleBackColor = true;
            buttonCong.Click += button1_Click;
            // 
            // buttonNhan
            // 
            buttonNhan.Location = new Point(631, 56);
            buttonNhan.Name = "buttonNhan";
            buttonNhan.Size = new Size(94, 29);
            buttonNhan.TabIndex = 5;
            buttonNhan.Text = "Nhân";
            buttonNhan.UseVisualStyleBackColor = true;
            buttonNhan.Click += buttonNhan_Click;
            // 
            // buttonTru
            // 
            buttonTru.Location = new Point(476, 129);
            buttonTru.Name = "buttonTru";
            buttonTru.Size = new Size(94, 29);
            buttonTru.TabIndex = 6;
            buttonTru.Text = "Trừ";
            buttonTru.UseVisualStyleBackColor = true;
            buttonTru.Click += buttonTru_Click;
            // 
            // buttonChia
            // 
            buttonChia.Location = new Point(631, 129);
            buttonChia.Name = "buttonChia";
            buttonChia.Size = new Size(94, 29);
            buttonChia.TabIndex = 7;
            buttonChia.Text = "Chia";
            buttonChia.UseVisualStyleBackColor = true;
            buttonChia.Click += buttonChia_Click;
            // 
            // txtketqua
            // 
            txtketqua.Location = new Point(166, 252);
            txtketqua.Name = "txtketqua";
            txtketqua.ReadOnly = true;
            txtketqua.Size = new Size(269, 27);
            txtketqua.TabIndex = 9;
            // 
            // Ketqua
            // 
            Ketqua.AutoSize = true;
            Ketqua.Font = new Font("Segoe UI", 18F);
            Ketqua.Location = new Point(23, 238);
            Ketqua.Name = "Ketqua";
            Ketqua.Size = new Size(126, 41);
            Ketqua.TabIndex = 8;
            Ketqua.Text = "Kết quả:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(959, 385);
            Controls.Add(txtketqua);
            Controls.Add(Ketqua);
            Controls.Add(buttonChia);
            Controls.Add(buttonTru);
            Controls.Add(buttonNhan);
            Controls.Add(buttonCong);
            Controls.Add(txtsob);
            Controls.Add(SoB);
            Controls.Add(txtsoa);
            Controls.Add(SoA);
            Name = "Form1";
            Text = "Caculater App";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label SoA;
        private TextBox txtsoa;
        private TextBox txtsob;
        private Label SoB;
        private Button buttonCong;
        private Button buttonNhan;
        private Button buttonTru;
        private Button buttonChia;
        private TextBox txtketqua;
        private Label Ketqua;
    }
}
