using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShopQuanAo.Models
{
    public class ChiTietHoaDon
    {
        [Key]
        public string MaHD { get; set; }
        [ForeignKey("SanPham")]
        public int MaSP { get; set; }
        public int SoLuong { get; set; }
        public double DonGia { get; set; }
        public virtual SanPham SanPham { get; set; }
    }
}
