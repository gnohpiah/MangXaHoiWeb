using MangXaHoiWeb.Repository;
using Microsoft.AspNetCore.Mvc;

namespace MangXaHoiWeb.ViewComponents
{
    public class BaiVietPublicViewComponent : ViewComponent
    {
        private readonly IBaiVietRepository _baiViet;

        public BaiVietPublicViewComponent(IBaiVietRepository baiViet)
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
