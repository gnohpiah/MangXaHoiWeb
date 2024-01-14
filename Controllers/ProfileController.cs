using MangXaHoiWeb.Models;
using MangXaHoiWeb.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using MangXaHoiWeb.Models.Authentication;

namespace MangXaHoiWeb.Controllers
{
    public class ProfileController : Controller
    {
		IWebHostEnvironment hostEnvironment;
        QlmangXhContext db;
		public ProfileController(QlmangXhContext db, IWebHostEnvironment hostEnvironment)
		{
			this.db = db;
			this.hostEnvironment = hostEnvironment;
		}
        [Authentication]
		public IActionResult IndexProfile(string maNguoiDung)
        {

            NguoiDung nguoiDung = db.NguoiDungs.Find(maNguoiDung);
            return View(nguoiDung);
        }
        // GET: BaiViet/CreateBaiViet
        [Authentication]
        public IActionResult CreateBaiViet(string maNguoiDung)
        {
            ViewBag.MaNguoiDung = maNguoiDung;
            return View();
        }
        [Authentication]
        // POST: BaiViet/CreateBaiViet
        [HttpPost]
        public IActionResult CreateBaiViet(BaiVietUpload baiVietUpload)
        {
            string filename = "";
            string random = Guid.NewGuid().ToString();

            if (baiVietUpload.Photo != null)
            {
                string uploadfolder = Path.Combine(hostEnvironment.WebRootPath, "images/post");
                filename = random + "_" + baiVietUpload.Photo.FileName;
                string filepath = Path.Combine(uploadfolder, filename);
                baiVietUpload.Photo.CopyTo(new FileStream(filepath, FileMode.Create));
            }
            BaiViet b = new BaiViet
            {
                MaBaiViet = random,
                NoiDung = baiVietUpload.NoiDung,
                ThoiGianDangBai = DateTime.Now,
                Anh = filename,
                MaNguoiDung = baiVietUpload.MaNguoiDung
            };

            db.BaiViets.Add(b);
            db.SaveChanges();
            ViewBag.success = "Record Added";
            return RedirectToAction("IndexProfile", "Profile", new { maNguoiDung = baiVietUpload.MaNguoiDung });
        }
        [Authentication]
        public IActionResult EditBaiViet(string maBaiViet)
        {
            BaiViet baiViet = db.BaiViets.Find(maBaiViet);

            if (baiViet == null)
            {
                // Handle the case where the BaiViet is not found
                return NotFound();
            }

            ViewBag.MaBaiViet = baiViet.MaBaiViet;
            ViewBag.MaNguoiDung = baiViet.MaNguoiDung;
            ViewBag.Anh = baiViet.Anh;

            BaiVietUpload b = new BaiVietUpload
            {
                MaNguoiDung = baiViet.MaNguoiDung,
                NoiDung = baiViet.NoiDung,
                ThoiGianDangBai = baiViet.ThoiGianDangBai,
                MaBaiViet = baiViet.MaBaiViet,
                AnhToUpdate = baiViet.Anh
            };

            return View(b);
        }

        [Authentication]
        [HttpPost]
        public IActionResult EditBaiViet(BaiVietUpload baiVietUpload)
        {
            // Ensure that MaBaiViet is not null
            if (string.IsNullOrEmpty(baiVietUpload.MaBaiViet))
            {
                return BadRequest("Invalid MaBaiViet");
            }

            BaiViet baiViet = db.BaiViets.Find(baiVietUpload.MaBaiViet);

            if (baiViet == null)
            {
                // Handle the case where the BaiViet is not found
                return NotFound();
            }

            
            string random = Guid.NewGuid().ToString();

            if (baiVietUpload.Photo != null)
            {
                string filename = "";
                string uploadfolder = Path.Combine(hostEnvironment.WebRootPath, "images/post");
                filename = random + "_" + baiVietUpload.Photo.FileName;
                string filepath = Path.Combine(uploadfolder, filename);
                baiVietUpload.Photo.CopyTo(new FileStream(filepath, FileMode.Create));
                baiViet.Anh = filename;
            }
            else
            {
                baiViet.Anh = baiVietUpload.AnhToUpdate;
            }

            baiViet.NoiDung = baiVietUpload.NoiDung;
            
            baiViet.MaNguoiDung = baiVietUpload.MaNguoiDung;

            try
            {
                db.SaveChanges();
                ViewBag.success = "Record Updated";
                return RedirectToAction("IndexProfile", "Profile", new { maNguoiDung = baiVietUpload.MaNguoiDung });
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                ViewBag.error = "An error occurred while updating the record.";
                return View(baiVietUpload);
            }
        }

        [Authentication]
        public IActionResult DeleteBaiViet(string maBaiViet)
        {
            var baiViet = db.BaiViets.Find(maBaiViet);
            ViewBag.MaNguoiDung = baiViet.MaNguoiDung;
            if (baiViet != null)
            {
                db.Remove(baiViet);
                db.SaveChanges();
            }
            return RedirectToAction("IndexProfile", "Profile", new { maNguoiDung = ViewBag.MaNguoiDung });
        }

    }
}
