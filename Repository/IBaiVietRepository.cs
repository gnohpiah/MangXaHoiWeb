using MangXaHoiWeb.ViewModels;
using MangXaHoiWeb.Models;
namespace MangXaHoiWeb.Repository
{
    public interface IBaiVietRepository
    {
        BaiVietNguoiDung Add(BaiVietNguoiDung baiVietNguoiDung);
        BaiVietNguoiDung Update(BaiVietNguoiDung baiVietNguoiDung);
        BaiVietNguoiDung Delete(string maBaiViet);
        List<BaiVietNguoiDung> GetAllBaiViet();
        List<BaiVietNguoiDung> GetBaiVietTheoNguoi(string maNguoiDung);
    }
}
