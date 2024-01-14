using MangXaHoiWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MangXaHoiWeb.Controllers
{
    public class AdminController : Controller
    {
        QlmangXhContext db = new QlmangXhContext();
        public IActionResult Index()
        {
            var lstNguoiDung = db.NguoiDungs.ToList();  
            return View(lstNguoiDung);
        }
        public IActionResult Delete(string maNguoiDung)
        {
            var nguoiDung = db.NguoiDungs.Find(maNguoiDung);

            if (nguoiDung != null)
            {
                var lstBaiViet = db.BaiViets.Where(x => x.MaNguoiDung == maNguoiDung).ToList();
                db.BaiViets.RemoveRange(lstBaiViet);
                db.NguoiDungs.Remove(nguoiDung);
                db.SaveChanges();
            }

            return RedirectToAction("Index", "Admin");
        }
    }
}
