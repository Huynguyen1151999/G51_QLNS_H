using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShopQuanAo.Models
{
    public class HoaDon
    {
        [Key]
        public int MaHD { get; set; }
        [ForeignKey("KhachHang")]
        [Column(Order = 0)]
        public string MaKH { get; set; }
        [ForeignKey("NhanVien")]
        [Column(Order = 1)]
        public string MaNV { get; set; }
        public DateTime NgayLapHD { get; set; }
        public DateTime NgayGiaoHang { get; set; }
        public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; }
        public virtual KhachHang KhachHang { get; set; }
        public virtual NhanVien NhanVien { get; set; }
    }
}
