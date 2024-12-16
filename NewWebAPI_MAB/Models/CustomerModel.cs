using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NewWebAPI_MAB.Models
{
    public class CustomerModel
    {
        [Key]
        public int CustomerID { get; set; }

        [Required]
        [MaxLength(100)]
        public string CustomerName { get; set; }

        [Required]
        [MaxLength(100)]
        public string HomeAddress { get; set; }

        [Required]
        [MaxLength(100)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MaxLength(15)]
        public string MobileNo { get; set; }

        [Required]
        [MaxLength(15)]
        public string GST_NO { get; set; }

        [Required]
        [MaxLength(100)]
        public string CityName { get; set; }

        [Required]
        [MaxLength(15)]
        public string PinCode { get; set; }

        [Required]
        [Column(TypeName = "DECIMAL(10,2)")]
        public decimal NetAmount { get; set; }

        [ForeignKey("UserID")]
        public int UserID { get; set; }

        public virtual UserModel User { get; set; }
    }
}
