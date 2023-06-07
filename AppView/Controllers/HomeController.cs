using AppData.Models;
using AppView.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;

namespace AppView.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> ShowAllNhanVien()
        {
            var httpClient = new HttpClient();
            string apiURL = "https://localhost:7155/api/NhanVien/get-all-nhanvien";

            var response = await httpClient.GetAsync(apiURL);
            string apiData = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<NhanVien>>(apiData);
            return View(result);
        }

        public async Task<IActionResult> CreateNhanVien()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateNhanVien(NhanVien nv)
        {
            if (!ModelState.IsValid)
                return View(ModelState);

            var httpClient = new HttpClient();

            string apiURL = "https://localhost:7155/api/NhanVien/create-nhanvien";

            var json = JsonConvert.SerializeObject(nv);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync(apiURL, content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAllNhanVien");
            }
            ModelState.AddModelError("", "Sai roi");

            return View(nv);
        }

        [HttpGet]
        public async Task<IActionResult> EditNhanVien(Guid id)
        {
            var httpClient = new HttpClient();
            string apiURL = $"https://localhost:7155/api/NhanVien/get-nhanvien/{id}";

            var response = await httpClient.GetAsync(apiURL);

            string apiData = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<NhanVien>(apiData);
            return View(result);
        }

        public async Task<IActionResult> EditNhanVien(NhanVien nv)
        {
            if (!ModelState.IsValid) return View(ModelState);

            var httpClient = new HttpClient();
            string apiURL = $"https://localhost:7155/api/NhanVien/edit-nhanvien/";

            var json = JsonConvert.SerializeObject(nv);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await httpClient.PutAsync(apiURL, content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAllNhanVien");
            }
            ModelState.AddModelError("", "sai roi be oi");

            return View(nv);
        }

        public async Task<IActionResult> DeleteNhanVien(Guid id)
        {
            var httpClient = new HttpClient();
            string apiURL = $"https://localhost:7155/api/NhanVien/delete-nhanvien/{id}";

            var response = await httpClient.DeleteAsync(apiURL);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAllNhanVien");
            }
            ModelState.AddModelError("", "sai tiep roi be oi");
            return BadRequest();
        }
    }
}