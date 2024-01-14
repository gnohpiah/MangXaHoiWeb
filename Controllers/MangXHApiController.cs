using MangXaHoiWeb.Models;
using MangXaHoiWeb.Models.ApiModels;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MangXaHoiWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MangXHApiController : ControllerBase
    {
        QlmangXhContext db = new QlmangXhContext();
        public IEnumerable<BaiVietAPI> GetAllBaiViet()
        {
            var baiViet = (from p in db.BaiViets
                             select new BaiVietAPI
                             {
                                 MaBaiViet = p.MaBaiViet,
                                 NoiDung = p.NoiDung,
                                 ThoiGianDangBai = p.ThoiGianDangBai,
                                 MaNguoiDung = p.MaNguoiDung,
                                 Anh = p.Anh

                             }).ToList();
            return baiViet;
        }
        [HttpGet("{maNguoiDung}")]
        public IEnumerable<BaiVietAPI>GetBaiVietTheoNguoiDung(string maNguoiDung)
        {
            var baiViet = (from p in db.BaiViets
                           where p.MaNguoiDung == maNguoiDung  
                           select new BaiVietAPI
                           {
                               MaBaiViet = p.MaBaiViet,
                               NoiDung = p.NoiDung,
                               ThoiGianDangBai = p.ThoiGianDangBai,
                               MaNguoiDung = p.MaNguoiDung,
                               Anh = p.Anh

                           }).ToList();
            return baiViet;
        }
    }
}
