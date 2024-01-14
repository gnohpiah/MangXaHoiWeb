using Microsoft.AspNetCore.Mvc;
using MangXaHoiWeb.Models;
using MangXaHoiWeb.ViewModels;
using MangXaHoiWeb.Repository;

namespace MangXaHoiWeb.ViewComponents
{
    public class BaiVietViewComponent : ViewComponent
    {
        private readonly IBaiVietRepository _baiViet;

        public BaiVietViewComponent(IBaiVietRepository baiViet)
        {
            _baiViet = baiViet;
        }

        public IViewComponentResult Invoke(string? maNguoiDung = null)
        {
            if (string.IsNullOrEmpty(maNguoiDung))
            {
                var baiViet = _baiViet.GetAllBaiViet().OrderBy(x => x.baiViet.ThoiGianDangBai).ToList();
                return View(baiViet);
            }
            else
            {
                var baiViet = _baiViet.GetBaiVietTheoNguoi(maNguoiDung).OrderBy(x => x.baiViet.ThoiGianDangBai).ToList();
                return View(baiViet);
            }
        }
    }
}

