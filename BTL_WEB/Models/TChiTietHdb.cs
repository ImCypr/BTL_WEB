﻿using System;
using System.Collections.Generic;

namespace BTL_WEB.Models
{
    public partial class TChiTietHdb
    {
        public string MaHoaDon { get; set; } = null!;
        public string MaSp { get; set; } = null!;
        public int? SoLuongBan { get; set; }
        public decimal? DonGiaBan { get; set; }
        public double? GiamGia { get; set; }
        public string? GhiChu { get; set; }

        public virtual THoaDonBan MaHoaDonNavigation { get; set; } = null!;
        public virtual TDanhMucSp MaSpNavigation { get; set; } = null!;
    }
}
