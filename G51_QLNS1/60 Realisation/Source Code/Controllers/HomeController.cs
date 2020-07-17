using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ShopQuanAo.Models;
using SQLitePCL;

namespace ShopQuanAo.Controllers
{
    public class HomeController : Controller
    {
        private readonly SaleContext _context;

        public HomeController(SaleContext _context)
        {
            this._context = _context;
        }
        public IActionResult Index(int? page, int maloaisp = 0)
        {

            var loaiSP = _context.LoaiSanPhams.ToList();
            Hashtable tenloaiSP = new Hashtable();
            foreach (var item in loaiSP)
            {
                tenloaiSP.Add(item.MaLoaiSP, item.TenLoaiSP);
            }
            ViewBag.TenLoaiSP = tenloaiSP;
            if (maloaisp == 0)
            {
                int sotrang = _context.Sanphams.Count() / 6;
                ViewBag.Count = sotrang;

                int number = 1;
                if (page != null)
                {
                    number = page.GetValueOrDefault() * 6;
                }

                //var item = from p in _context.Sanphams
                //           select p;
                //return View(item.OrderBy(s => s.MaSP).Skip(number).Take(6).ToList());
                var sanphams = _context.Sanphams.Include(s => s.LoaiSanPham);
                return View(sanphams.ToList());
            }
            else
            {
                var sanPhams = _context.Sanphams.Include(s => s.LoaiSanPham).Where(x => x.MaLoaiSP == maloaisp);
                return View(sanPhams);
            }
        }
        public IActionResult Trangchu()
        { 
            return View();
        }
        public async Task<IActionResult> Thongtinsanpham(int id)
        {
            

            var sanPham = await _context.Sanphams.Include(s => s.LoaiSanPham).FirstOrDefaultAsync(m => m.MaSP == id);
            if (sanPham == null)
            {
                return NotFound();
            }

            var sanPhamFeature = await _context.Sanphams.Include(s => s.LoaiSanPham).Where(m => m.Feature == 1).ToListAsync();

            SanPhamVM spVM = new SanPhamVM()
            {
                Sanpham = sanPham,
                ListSanPhamFeature = sanPhamFeature
            };

            return View(spVM);
        }
        public ActionResult TimKiem(long max, long min)
        {
            var link = _context.Sanphams.Where(x => x.DonGia >= min && x.DonGia <= max).ToList();
            return View(link);
        }

        //public ActionResult Sapxepgiam(int? page,int maloaisp = 0)
        //{
        //    var loaiSP = _context.LoaiSanPhams.ToList();
        //    Hashtable tenloaiSP = new Hashtable();
        //    foreach (var item in loaiSP)
        //    {
        //        tenloaiSP.Add(item.MaLoaiSP, item.TenLoaiSP);
        //    }
        //    ViewBag.TenLoaiSP = tenloaiSP;

        //    if (maloaisp == 0)
        //    {
        //        int sotrang = _context.Sanphams.Count() / 3;
        //        ViewBag.Count = sotrang;

        //        int number = 0;
        //        if (page != null)
        //        {
        //            number = page.GetValueOrDefault() * 3;
        //        }

        //        var item = from p in _context.Sanphams
        //                   select p;
        //        return View(item.OrderBy(s => s.MaSP).Skip(number).Take(3).ToList());
        //    }
        //    else
        //    {
        //        int sotrang = _context.Sanphams.Count() / 3;
        //        ViewBag.Count = sotrang;

        //        int number = 0;
        //        if (page != null)
        //        {
        //            number = page.GetValueOrDefault() * 3;
        //        }
        //        var sanPhams = _context.Sanphams.Include(s => s.LoaiSanPham).Where(x => x.MaLoaiSP == maloaisp).OrderByDescending(x => x.DonGia);
        //        return View(sanPhams.ToList());
        //    }
        //}
    }
    }

