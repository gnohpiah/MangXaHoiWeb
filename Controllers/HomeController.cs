using MangXaHoiWeb.Models;
using MangXaHoiWeb.Models.Authentication;
using MangXaHoiWeb.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace MangXaHoiWeb.Controllers
{
    public class HomeController : Controller
    {
        QlmangXhContext db = new QlmangXhContext();

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        /*[Authentication]*/
        public IActionResult IndexHome(string maNguoiDung)
        {
            NguoiDung nguoiDung = db.NguoiDungs.Find(maNguoiDung);
            return View(nguoiDung);
        }

        public IActionResult Test(string maNguoiDung)
        {
            NguoiDung nguoiDung = db.NguoiDungs.Find(maNguoiDung);
            return View(nguoiDung);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}