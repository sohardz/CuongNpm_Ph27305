using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Models
{
    public class NhanVien
    {
        public Guid? Id { get; set; }
        [MaxLength(30)]
        public string Ten { get; set; }
        [Range(18, 50)]
        public int Tuoi { get; set; }

        public int Role { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Range(5000000, 30000000)]
        public int Luong { get; set; }

        public bool TrangThai { get; set; }
    }
}
