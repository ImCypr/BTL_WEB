using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BTL_WEB.Models
{
    public partial class TDanhMucSp
    {
        public TDanhMucSp()
        {
            TChiTietHdbs = new HashSet<TChiTietHdb>();
        }
        [Required(ErrorMessage = "Mã sản phẩm là bắt buộc")]
        public string MaSp { get; set; } = null!;
        public string? TenSp { get; set; }
        public string? MaLoai { get; set; }
        public string? MaChatLieu { get; set; }
        public string? MaHangSx { get; set; }
        public string? MaNuocSx { get; set; }
        public string? MaMauSac { get; set; }
        public double? DonGiaBan { get; set; }
        public string? GioiThieuSp { get; set; }
        public decimal? Gia { get; set; }
        public string? AnhDaiDien { get; set; }
        public double? GiamGia { get; set; }
        public int? Slton { get; set; }

        public virtual TChatLieu? MaChatLieuNavigation { get; set; }
        public virtual THangSx? MaHangSxNavigation { get; set; }
        public virtual TLoaiSp? MaLoaiNavigation { get; set; }
        public virtual TMauSac? MaMauSacNavigation { get; set; }
        public virtual TQuocGia? MaNuocSxNavigation { get; set; }
        public virtual ICollection<TChiTietHdb> TChiTietHdbs { get; set; }
    }
}
