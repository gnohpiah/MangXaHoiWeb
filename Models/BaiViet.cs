using System;
using System.Collections.Generic;

namespace MangXaHoiWeb.Models;

public partial class BaiViet
{
    public string MaBaiViet { get; set; } = null!;

    public string? NoiDung { get; set; }

    public DateTime? ThoiGianDangBai { get; set; }

    public string MaNguoiDung { get; set; } = null!;

    public string? Anh { get; set; }

    public virtual ICollection<BinhLuan> BinhLuans { get; set; } = new List<BinhLuan>();

    public virtual ICollection<ChiaSe> ChiaSes { get; set; } = new List<ChiaSe>();

    public virtual NguoiDung MaNguoiDungNavigation { get; set; } = null!;

    public virtual ICollection<Thich> Thiches { get; set; } = new List<Thich>();
}
