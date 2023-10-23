﻿using System;
using System.Collections.Generic;

namespace BTL_WEB.Models
{
    public partial class TQuocGia
    {
        public TQuocGia()
        {
            TDanhMucSps = new HashSet<TDanhMucSp>();
        }

        public string MaNuoc { get; set; } = null!;
        public string? TenNuoc { get; set; }

        public virtual ICollection<TDanhMucSp> TDanhMucSps { get; set; }
    }
}
