using System;

namespace ExampleCAdvance.Hinh
{
    public class HinhChuNhat
    {
        private double dai;
        private double rong;

        public double Dai
        {
            get => dai;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Chieu dai phai > 0");
                }
                dai = value;
            }
        }

        public double Rong
        {
            get => rong;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Chieu rong phai > 0");
                }
                rong = value;
            }
        }

        public HinhChuNhat() { }
        public HinhChuNhat(double dai, double rong)
        {
            Dai = dai;
            Rong = rong;
        }

        private double NhapKichThuoc(string tenKichThuoc)
        {
            double giatri = 0;
            bool hopLe = false;

            while (!hopLe)
            {
                Console.Write($"Nhap {tenKichThuoc} (> 0): ");
                string input = Console.ReadLine();

                if (!double.TryParse(input, out giatri))
                {
                    Console.WriteLine($"Loi: {tenKichThuoc} phai la mot so. Vui long nhap lai!\n");
                }
                else if (giatri <= 0)
                {
                    Console.WriteLine($"Loi: {tenKichThuoc} phai > 0. Vui long nhap lai!\n");
                }
                else
                {
                    hopLe = true; // Cạnh hợp lệ
                }
            }

            return giatri;
        }

        public void Nhap()
        {
            Dai = NhapKichThuoc("chieu dai");
            Rong = NhapKichThuoc("chieu rong");
        }

        public double TinhDienTich() => Dai * Rong; 

        public double TinhChuVi() => 2 * (Dai + Rong);

        public string ThongTin()
        {
            return $"Hinh chu nhat co Dai = {Dai}, Rong = {Rong}, " +
                   $"Dien tich = {TinhDienTich():F2}, Chu vi = {TinhChuVi():F2}";
        }

        public void HienThi() => Console.WriteLine(ThongTin());
    }
}