using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NewWebAPI_MAB.Models
{
    public class OrderModel
    {
        [Key]
        public int OrderID { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        [Required]
        [ForeignKey("CustomerID")]
        public int CustomerID { get; set; }

        public virtual CustomerModel Customer { get; set; }

        public string PaymentMode { get; set; }

        public decimal? TotalAmount { get; set; }

        [Required]
        [MaxLength(100)]
        public string ShippingAddress { get; set; }

        [ForeignKey("UserID")]
        public int UserID { get; set; }

        public virtual UserModel User { get; set; }
    }
}
