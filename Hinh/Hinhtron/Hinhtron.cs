using System;

namespace ExampleCAdvance.Hinh
{
    public class HinhTron
    {
        // Thuộc tính bán kính
        private double r;

        public double R
        {
            get { return r; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Ban kinh R phai > 0");
                }
                r = value;
            }
        }

        public HinhTron() { }

        public HinhTron(double r)
        {
            R = r;
        }

        // Phương thức xử lý nhập dữ liệu trực tiếp từ bàn phím
        public void Nhap()
        {
            bool hopLe = false;
            do
            {
                try
                {
                    Console.Write("Nhap vao ban kinh r (> 0): ");
                    string input = Console.ReadLine();

                    // Kiểm tra ép kiểu số
                    if (!double.TryParse(input, out double val))
                    {
                        Console.WriteLine("Loi: Gia tri nhap phai la so. Vui long nhap lai!\n");
                        continue;
                    }

                    R = val;
                    hopLe = true; // Nhập thành công
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Loi: {ex.Message}. Vui long nhap lai!\n");
                }
            } while (!hopLe);
        }

        public double TinhDienTich()
        {
            return Math.PI * R * R;
        }

        public double TinhChuVi()
        {
            return 2 * Math.PI * R;
        }

        public string ThongTin()
        {
            return $"Hinh tron co ban kinh R = {R}, " +
                   $"dien tich = {TinhDienTich():F2}, " +
                   $"chu vi = {TinhChuVi():F2}";
        }

        public void HienThi()
        {
            Console.WriteLine(ThongTin());
        }
    }
}