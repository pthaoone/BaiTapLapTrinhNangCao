using BaiTap.Entity;
using System.Runtime.ConstrainedExecution;
using System.Linq;
using System.Text.RegularExpressions;
SubjectStudent subject = new SubjectStudent();
String Hoten = "Nguyen       Van       Thi       Anh";
Regex.Replace(Hoten,@"\s+", " ");
Hoten = Hoten.Trim();
Regex.Replace(Hoten,@"\s+", " ");
string pattern = @"^\p{Lu}\p{L}+(?: \p{Lu}\p{L}+$";
if (Regex.IsMatch(Hoten, pattern))
{
    Console.WriteLine("Họ tên hợp lệ");
}
else
{
    Console.WriteLine("Họ tên không hợp lệ");
}

