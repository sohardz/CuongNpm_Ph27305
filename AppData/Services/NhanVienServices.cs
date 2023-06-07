using AppData.Context;
using AppData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Services
{
    public class NhanVienServices : INhanVienServices
    {
        LabDbContext _context;

        public NhanVienServices(LabDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Create(NhanVien nv)
        {
            try
            {
                nv.Id = Guid.NewGuid();
                await _context.AddAsync(nv);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> Delete(Guid id)
        {
            try
            {
                var x = await _context.NhanViens.FindAsync(id);
                _context.Remove(x);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IEnumerable<NhanVien>> GetAll()
        {
            return await _context.NhanViens.ToListAsync();
        }

        public async Task<NhanVien> GetById(Guid id)
        {
            return await _context.NhanViens.FindAsync(id);
        }

        public async Task<bool> Update(NhanVien nv)
        {
            try
            {
                var x = await _context.NhanViens.FindAsync(nv.Id);                
                x.Ten = nv.Ten;
                x.Role = nv.Role;
                x.TrangThai = nv.TrangThai;
                x.Email = nv.Email;
                x.Tuoi = nv.Tuoi;
                x.Luong = nv.Luong;
                _context.Update(x);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
