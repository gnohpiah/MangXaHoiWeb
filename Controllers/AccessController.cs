using MangXaHoiWeb.Models;
using MangXaHoiWeb.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using NuGet.Protocol;
using System;

namespace MangXaHoiWeb.Controllers
{
    public class AccessController : Controller
    {
        IWebHostEnvironment hostEnvironment;
        QlmangXhContext db;
        public AccessController(QlmangXhContext db,IWebHostEnvironment hostEnvironment)
        {
            this.db = db;
            this.hostEnvironment = hostEnvironment;
        }
        [HttpGet]
        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("TenNguoiDung") == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("IndexHome", "Home");
            }
        }
        /*[HttpPost]
        public IActionResult Login(NguoiDung nguoidung)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("MaNguoiDung")))
            {
                var user = db.NguoiDungs.FirstOrDefault(x => x.MaNguoiDung.Equals(nguoidung.MaNguoiDung) && x.MatKhau.Equals(nguoidung.MatKhau));

                if (user != null)
                {
                    HttpContext.Session.SetString("MaNguoiDung", user.MaNguoiDung.ToString());

                    if (user.MaNguoiDung == "admin")
                    {
                        return RedirectToAction("Index", "Admin");
                    }

                    return RedirectToAction("IndexHome", "Home", new { maNguoiDung = user.MaNguoiDung.Trim() });
                }
            }

            // Authentication failed
            return View();
        }*/

        [HttpPost]
        public IActionResult Login(NguoiDung nguoidung)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("MaNguoiDung")))
            {
                // Assuming that NguoiDung is the name of your table/entity
                var query = $"SELECT * FROM NguoiDung WHERE MaNguoiDung = '{nguoidung.MaNguoiDung}' AND MatKhau = '{nguoidung.MatKhau}'";
                var user = db.NguoiDungs.FromSqlRaw(query).FirstOrDefault();

                if (user != null)
                {
                    HttpContext.Session.SetString("MaNguoiDung", user.MaNguoiDung.ToString());

                    if (user.MaNguoiDung == "admin")
                    {
                        return RedirectToAction("Index", "Admin");
                    }

                    return RedirectToAction("IndexHome", "Home", new { maNguoiDung = user.MaNguoiDung.Trim() });
                }
            }

            // Authentication failed
            return View();
        }


        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Signup(SignUp signUp)
        {
            string filename = "";
            if (signUp.Avatar != null)
            {
                string uploadfolder = Path.Combine(hostEnvironment.WebRootPath, "images/profile");
                filename = signUp.MaNguoiDung + "_" + signUp.Avatar.FileName;
                string filepath = Path.Combine(uploadfolder, filename);
                signUp.Avatar.CopyTo(new FileStream(filepath, FileMode.Create));
            }
            NguoiDung n = new NguoiDung
            {
                MaNguoiDung = signUp.MaNguoiDung,
                MatKhau =   signUp.MatKhau,
                TenNguoiDung = signUp.TenNguoiDung,
                GioiTinh = signUp.GioiTinh,
                DiaChi = signUp.DiaChi,
                Email = signUp.Email,
                SoDienThoai = signUp.SoDienThoai,
                CongViec = signUp.CongViec,
                HocVan = signUp.HocVan,
                AnhDaiDien = filename,
                Quote = signUp.Quote,
            };
            db.NguoiDungs.Add(n);
            db.SaveChanges();
            ViewBag.success = "Record Added";
            return RedirectToAction("Login", "Access");
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            HttpContext.Session.Remove("MaNguoiDung");
            return RedirectToAction("Login", "Access");
        }
    }
}
