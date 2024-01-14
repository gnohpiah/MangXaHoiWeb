using System;
using System.Collections.Generic;

namespace MangXaHoiWeb.Models;

public partial class ChiaSe
{
    public string MaChiaSe { get; set; } = null!;

    public string? CheDoChiaSe { get; set; }

    public DateTime? NgayChiaSe { get; set; }

    public string MaNguoiDung { get; set; } = null!;

    public string MaBaiViet { get; set; } = null!;

    public virtual BaiViet MaBaiVietNavigation { get; set; } = null!;

    public virtual NguoiDung MaNguoiDungNavigation { get; set; } = null!;
}
