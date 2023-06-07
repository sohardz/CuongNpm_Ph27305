using AppData.Configurations;
using AppData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Context
{
    public class LabDbContext : DbContext
    {
        public DbSet<NhanVien> NhanViens { get; set; }

        public LabDbContext()
        {
            
        }

        public LabDbContext(DbContextOptions options) : base(options)
        {
        }
        //"Server=;Database=CuongNpm_Ph27305;Integrated Security=True;"

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-P5GSVI1\\SQLEXPRESS;Database=CuongNpm_PH27305;Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new NhanVienConfiguration());
        }
    }
}
