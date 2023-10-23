using BTL_WEB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Events;
using System.ComponentModel.DataAnnotations;
using X.PagedList;
using X.PagedList.Mvc.Core;

namespace BTL_WEB.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin")]
    [Route("Admin/homeadmin")]
    public class HomeAdminController : Controller
    {
        SQLBanKinhMat1Context db = new SQLBanKinhMat1Context();
        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }
        [Route("sanpham")]
        public IActionResult SanPham(int? page)
        {
            int pageSize = 10;
            int pageNumber = page == null || page <0 ? 1: page.Value;
            var lstSanPham = db.TDanhMucSps.AsNoTracking().OrderBy(x => x.MaSp);
            PagedList<TDanhMucSp> lst = new PagedList<TDanhMucSp>(lstSanPham,pageNumber,pageSize);
            return View(lst);
        }
        [Route("Themsanphammoi")]
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.MaLoai = new SelectList(db.TLoaiSps.ToList(), "MaLoai", "Loai");
            
            ViewBag.MaChatLieu = new SelectList(db.TChatLieus.ToList(), "MaChatLieu", "ChatLieu");
            ViewBag.MaHangSx = new SelectList(db.THangSxes.ToList(), "MaHangSx", "HangSx");
            ViewBag.MaNuocSx = new SelectList(db.TQuocGia.ToList(), "MaNuoc", "TenNuoc");
            ViewBag.MaMauSac = new SelectList(db.TMauSacs.ToList(), "MaMauSac", "TenMauSac");
            return View();
        }
        [Route("Themsanphammoi")]
        [HttpPost]
        public IActionResult Add(TDanhMucSp SanPham)
        {
            if(ModelState.IsValid)
            {
                db.TDanhMucSps.Add(SanPham);
                db.SaveChanges();
                return RedirectToAction("SanPham");
            }
            return View(SanPham);
        }

        [Route("Suasanpham")]
        [HttpGet]
        public IActionResult Upd(string maSp)
        {
            ViewBag.MaLoai = new SelectList(db.TLoaiSps.ToList(), "MaLoai", "Loai");

            ViewBag.MaChatLieu = new SelectList(db.TChatLieus.ToList(), "MaChatLieu", "ChatLieu");
            ViewBag.MaHangSx = new SelectList(db.THangSxes.ToList(), "MaHangSx", "HangSx");
            ViewBag.MaNuocSx = new SelectList(db.TQuocGia.ToList(), "MaNuoc", "TenNuoc");
            ViewBag.MaMauSac = new SelectList(db.TMauSacs.ToList(), "MaMauSac", "TenMauSac");
            var sanPham = db.TDanhMucSps.Find(maSp);

            return View(sanPham);
        }
        [Route("Suasanpham")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upd(TDanhMucSp sanPham)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sanPham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("SanPham", "HomeAdmin");
            }
            return View(SanPham);
        }

        [Route("Xoasanpham")]
        [HttpGet]
        public IActionResult Delete(string maSP)
        {
            TempData["Message"] = "";
            var chiTietSanPham = db.TChiTietHdbs.Where(x => x.MaSp == maSP).ToList();
            if(chiTietSanPham.Count > 0)
            {
                TempData["Message"] = "Không thể xóa do đã được bán";
                return View("SanPham", "HomeAdmin");
            }
            db.Remove(db.TDanhMucSps.Find(maSP));
            db.SaveChanges();
            TempData["Message"] = "Sản phẩm đã được xóa";
            return RedirectToAction("SanPham", "HomeAdmin");
        }

    }
}
