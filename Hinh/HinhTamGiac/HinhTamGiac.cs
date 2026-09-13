using System;

namespace ExampleCAdvance.Hinh
{
    public class HinhTamGiac
    {
        private double a, b, c;

        public double A { get => a; private set => a = value; }
        public double B { get => b; private set => b = value; }
        public double C { get => c; private set => c = value; }

        public HinhTamGiac() { }

        public HinhTamGiac(double a, double b, double c)
        {
            SetCanh(a, b, c);
        }

        public void SetCanh(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new ArgumentException("Cac canh cua tam giac phai > 0");
            }
            if (a + b <= c || a + c <= b || b + c <= a)
            {
                throw new ArgumentException("Ba canh khong tao thanh mot tam giac hop le (tong 2 canh phai > canh con lai)");
            }

            A = a;
            B = b;
            C = c;
        }

        private double NhapMotCanh(string tenCanh)
        {
            double canh = 0;
            bool hopLe = false;

            while (!hopLe)
            {
                Console.Write($"Nhap {tenCanh} (> 0): ");
                string input = Console.ReadLine();

                if (!double.TryParse(input, out canh))
                {
                    Console.WriteLine($"Loi: {tenCanh} phai la mot so. Vui long nhap lai!\n");
                }
                else if (canh <= 0)
                {
                    Console.WriteLine($"Loi: {tenCanh} phai > 0. Vui long nhap lai!\n");
                }
                else
                {
                    hopLe = true; // Cạnh hợp lệ
                }
            }

            return canh;
        }

        public void Nhap()
        {
            bool tamGiacHopLe = false;

            while (!tamGiacHopLe)
            {
                double cA = NhapMotCanh("canh a");
                double cB = NhapMotCanh("canh b");
                double cC = NhapMotCanh("canh c");

                try
                {
                    SetCanh(cA, cB, cC);
                    tamGiacHopLe = true; // Đúng điều kiện tam giác -> Thoát
                }
                catch (ArgumentException ex)
                {
                    // Lỗi 3 cạnh không thỏa mãn bất đẳng thức tam giác (ví dụ: 1, 2, 10)
                    Console.WriteLine($"\nLoi: {ex.Message}");
                    Console.WriteLine("Vui long nhap lai toan bo 3 canh!\n");
                }
            }
        }

        public double TinhChuVi() => A + B + C;

        public double TinhDienTich()
        {
            double p = TinhChuVi() / 2;
            return Math.Sqrt(p * (p - A) * (p - B) * (p - C));
        }

        public string ThongTin()
        {
            return $"Hinh tam giac co 3 canh ({A}, {B}, {C}), " +
                   $"Dien tich = {TinhDienTich():F2}, Chu vi = {TinhChuVi():F2}";
        }

        public void HienThi() => Console.WriteLine(ThongTin());
    }
}