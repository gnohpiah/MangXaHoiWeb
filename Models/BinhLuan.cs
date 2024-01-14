using System;
using System.Collections.Generic;

namespace MangXaHoiWeb.Models;

public partial class BinhLuan
{
    public string MaBinhLuan { get; set; } = null!;

    public string? NoiDung { get; set; }

    public string MaNguoiDung { get; set; } = null!;

    public string MaBaiViet { get; set; } = null!;

    public virtual BaiViet MaBaiVietNavigation { get; set; } = null!;

    public virtual NguoiDung MaNguoiDungNavigation { get; set; } = null!;
}
