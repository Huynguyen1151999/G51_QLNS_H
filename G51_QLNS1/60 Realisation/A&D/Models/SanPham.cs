using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShopQuanAo.Models
{
    public class SanPham
    {
        [Key]
        public int MaSP { get; set; }
        public string TenSP { get; set; }
        [DisplayFormat(DataFormatString ="{0:0,0}")]
        public double DonGia { get; set; }
        [ForeignKey("LoaiSanPham")]
        public int MaLoaiSP { get; set; }
        public string HinhSP { get; set; }
        public string Description { get; set; }

        public int Feature { get; set; }
        public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; }
        public virtual LoaiSanPham LoaiSanPham { get; set; }

        internal object ToListAsync()
        {
            throw new NotImplementedException();
        }
    }
}
