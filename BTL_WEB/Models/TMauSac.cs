﻿using System;
using System.Collections.Generic;

namespace BTL_WEB.Models
{
    public partial class TMauSac
    {
        public TMauSac()
        {
            TDanhMucSps = new HashSet<TDanhMucSp>();
        }

        public string MaMauSac { get; set; } = null!;
        public string? TenMauSac { get; set; }

        public virtual ICollection<TDanhMucSp> TDanhMucSps { get; set; }
    }
}
