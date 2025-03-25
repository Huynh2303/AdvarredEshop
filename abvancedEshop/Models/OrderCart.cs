using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace abvancedEshop.Models
{
    public class OrderCart
    {
        [Key]
        public int OrderId { get; set; }

        [ForeignKey("Chechout")]
        public int ChechoutId { get; set; } // Liên kết với thông tin khách hàng
        public Chechout Chechout { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.Now;

        public decimal TotalAmount { get; set; } // Tổng tiền đơn hàng

    }
}
