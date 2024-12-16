using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NewWebAPI_MAB.Models
{
    public class ProductModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductID { get; set; }

        [Required]
        [MaxLength(100)]
        public string ProductName { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal ProductPrice { get; set; }

        [Required]
        [MaxLength(100)]
        public string ProductCode { get; set; }

        [Required]
        [MaxLength(100)]
        public string Description { get; set; }

        [Required]
        public int UserID { get; set; }

        [ForeignKey("UserID")]
        public virtual UserModel User { get; set; }
    }
}
