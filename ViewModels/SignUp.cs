namespace MangXaHoiWeb.ViewModels
{
    public class SignUp
    {
        public string MaNguoiDung { get; set; } = null!;

        public string? MatKhau { get; set; }

        public string? TenNguoiDung { get; set; }

        public string? GioiTinh { get; set; }

        public string? DiaChi { get; set; }

        public string? Email { get; set; }

        public int? SoDienThoai { get; set; }

        public string? CongViec { get; set; }

        public string? HocVan { get; set; }

        public IFormFile Avatar { get; set; }

        public string? Quote { get; set; }
    }
}
