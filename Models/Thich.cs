using System;
using System.Collections.Generic;

namespace MangXaHoiWeb.Models;

public partial class Thich
{
    public string MaThich { get; set; } = null!;

    public string MaNguoiDung { get; set; } = null!;

    public string MaBaiViet { get; set; } = null!;

    public virtual BaiViet MaBaiVietNavigation { get; set; } = null!;

    public virtual NguoiDung MaNguoiDungNavigation { get; set; } = null!;
}
