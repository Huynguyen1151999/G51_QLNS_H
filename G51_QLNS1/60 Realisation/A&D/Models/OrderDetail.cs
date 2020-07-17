using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShopQuanAo.Models
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        [ForeignKey("Order")]
        public int OrderId { get; set; }
        [ForeignKey("SanPham")]
        public int MaSP { get; set; }
        public int TenSP { get; set; }
        [DisplayFormat(DataFormatString = "	{0:0,0}")]
        public double DonGia { get; set; }
        public int SoLuong { get; set; }
        [DisplayFormat(DataFormatString = "	{0:0,0}")]
        public double ThanhTien
        {
            get { return SoLuong * DonGia; }
        }
        public virtual Order Order { get; set; }
        public virtual SanPham SanPham { get; set; }
    }
}
