namespace MangXaHoiWeb.Models.ApiModels
{
    public class BaiVietAPI
    {
        public string MaBaiViet { get; set; } = null!;

        public string? NoiDung { get; set; }

        public DateTime? ThoiGianDangBai { get; set; }

        public string MaNguoiDung { get; set; } = null!;

        public string? Anh { get; set; }
    }
}
