using System;
using System.Collections.Generic;

namespace QuanLySinhVienDF.Models
{
    public partial class Lop
    {
        public Lop()
        {
            SinhViens = new HashSet<SinhVien>();
        }

        public int LopId { get; set; }
        public string? TenLop { get; set; }
        public int? KhoaId { get; set; }

        public virtual Khoa? Khoa { get; set; }
        public virtual ICollection<SinhVien> SinhViens { get; set; }
    }
}
