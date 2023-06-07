using AppData.Context;
using AppData.Models;
using AppData.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NhanVienController : ControllerBase
    {
        INhanVienServices iServices;
        LabDbContext context = new();

        public NhanVienController()
        {
            NhanVienServices services = new(context);
            iServices = services;
        }

        [HttpGet("get-all-nhanvien")]
        public async Task<IEnumerable<NhanVien>> GetAll()
        {
            return await iServices.GetAll();
        }
        [HttpPost("create-nhanvien")]
        public async Task<IActionResult> CreateNhanVien([FromBody] NhanVien nv)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var response = await iServices.Create(nv);
            if (response == false)
            {
                return BadRequest();
            }
            else
            {
                return Ok();
            }
        }

        //[HttpGet("get-color-by-name")]
        //public IEnumerable<NhanVien> GetColorByName(string name)
        //{
        //    return iServices.GetAllItem().Where(x => x.Ten.Contains(name)).ToList();
        //}

        [HttpGet("get-nhanvien/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var nV = await iServices.GetById(id);
            if (nV == null)
            {
                return BadRequest("Can't find capbac");
            }
            return Ok(nV);
        }

        [HttpPut("edit-nhanvien")]
        public async Task<IActionResult> EditNhanVien([FromBody] NhanVien nv)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var response = await iServices.Update(nv);
            if (response == false)
            {
                return BadRequest();
            }
            else
            {
                return Ok();
            }
        }

        [HttpDelete("delete-nhanvien/{id}")]
        public async Task<IActionResult> DeleteNhanVien([FromRoute]Guid id)
        {
            var response = await iServices.Delete(id);
            if (response == false)
            {
                return BadRequest();
            }
            else
            {
                return Ok();
            }
        }

        [HttpGet("get-bmi-")]
        public IActionResult TestBMI(int height, float weight)
        {
            float BMI = weight / height * 2;
            return Ok(BMI);
        }
    }
}
