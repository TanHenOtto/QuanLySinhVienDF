using System;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using QuanLySinhVienDF.Models;
namespace QuanLySinhVienDF
{
    class Program
    {
        static void Main()
        {
             Console.OutputEncoding = Encoding.UTF8;
            // Khởi tạo context
            using (var context = new QuanLySinhVienDFContext())
            {
                // Truy vấn sinh viên thuộc khoa CNTT và có tuổi từ 18 đến 20
                var sinhViensCNTT = context.SinhViens
                                .Include(sv => sv.Lop) // Bao gồm thông tin về lớp của sinh viên
                                .ThenInclude(lop => lop.Khoa) // Bao gồm thông tin về khoa của lớp
                                .Where(sv => sv.Lop.Khoa.TenKhoa == "CNTT" && sv.Tuoi >= 18 && sv.Tuoi <= 20) // Lọc sinh viên thuộc khoa CNTT
                                .ToList();
                var sinhVienList = context.SinhViens
                                .Include(sv => sv.Lop) // Bao gồm thông tin về lớp của sinh viên
                                .ThenInclude(lop => lop.Khoa)
                                .ToList();
                Console.WriteLine("Danh sách sinh viên :");
                foreach (var sv in sinhVienList)
                {
                    Console.WriteLine($"Tên: {sv.TenSinhVien}, Tuổi: {sv.Tuoi}, LopID: {sv.LopId}, Khoa: {sv.Lop.Khoa.TenKhoa}");
                }
                // Hiển thị thông tin sinh viên
                Console.WriteLine("\nDanh sách sinh viên thuộc khoa CNTT và có tuổi từ 18 đến 20:");
                Console.WriteLine("Có "+ sinhViensCNTT.Count + " sinh viên\n");
                int i = 1;
                foreach (var sinhVien in sinhViensCNTT)
                {
                    if (sinhVien.Lop != null && sinhVien.Lop.Khoa != null)
                    {
                        Console.WriteLine($"{i++}: Tên: {sinhVien.TenSinhVien}, Tuổi: {sinhVien.Tuoi}, Lớp: {sinhVien.Lop.TenLop}, Khoa: {sinhVien.Lop.Khoa.TenKhoa}");
                    }
                }

            }
        }
    }
}
