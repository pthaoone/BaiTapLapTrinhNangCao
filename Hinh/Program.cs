using System;
using ExampleCAdvance.Hinh;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        // Hình Tron
        Console.WriteLine("HINH TRON");
        HinhTron ht = new HinhTron();
        ht.Nhap();
        ht.HienThi();

        Console.WriteLine(); // Dong trong ngan cach (space)

        // Hình Tam Giác
        Console.WriteLine("HINH TAM GIAC");
        HinhTamGiac htg = new HinhTamGiac();
        htg.Nhap();
        htg.HienThi();
    
        Console.WriteLine();

        // Hình Chu Nhat
        Console.WriteLine("HINH CHU NHAT");
        HinhChuNhat hcn = new HinhChuNhat();
        hcn.Nhap();
        hcn.HienThi();
    }
}