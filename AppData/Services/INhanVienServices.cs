using AppData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Services
{
    public interface INhanVienServices
    {
        Task<IEnumerable<NhanVien>> GetAll();
        Task<bool> Create(NhanVien nv);
        Task<bool> Delete(Guid id);
        Task<bool> Update(NhanVien nv);
        Task<NhanVien> GetById(Guid id);
    }
}
