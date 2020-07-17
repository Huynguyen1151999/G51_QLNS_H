using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShopQuanAo.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        [ForeignKey("KhachHang")]
        [Column(Order = 0)]
        public string MaKH { get; set; }
        [ForeignKey("NhanVien")]
        [Column(Order = 1)]
        public string MaNV { get; set; }
        [Required]
        [DisplayName("Tên khách hàng")]
        public string CustomerName { get; set; }
        [DisplayName("Địa Chỉ")]
        [Required]
        public string Address { get; set; }
        [DisplayName("Email")]
        [Required]
        public string Email { get; set; }
        [DisplayName("Số điện thoại")]
        [Required]
        public string Phone { get; set; }
        public DateTime OrderDate { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual KhachHang KhachHang { get; set; }
        public virtual NhanVien NhanVien { get; set; }
    }
}
