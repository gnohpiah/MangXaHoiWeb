using System;
using System.Collections.Generic;

namespace MangXaHoiWeb.Models;

public partial class NguoiDung
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

    public string? AnhDaiDien { get; set; }

    public string? Quote { get; set; }

    public virtual ICollection<BaiViet> BaiViets { get; set; } = new List<BaiViet>();

    public virtual ICollection<BinhLuan> BinhLuans { get; set; } = new List<BinhLuan>();

    public virtual ICollection<ChiaSe> ChiaSes { get; set; } = new List<ChiaSe>();

    public virtual ICollection<Thich> Thiches { get; set; } = new List<Thich>();
}
