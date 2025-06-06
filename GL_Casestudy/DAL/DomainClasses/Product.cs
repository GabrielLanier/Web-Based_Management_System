using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GL_Casestudy.DAL.DomainClasses
{
    public class Product
    {
        [Key]
        public string? ProductId { get; set; }

        [ForeignKey("BrandId")]
        public Brand? Brand { get; set; }

        [Required]
        public int BrandId { get; set; }
        
        [Required]
        [StringLength(200)]
        public string? ProductName { get; set; }
        
        [Required]
        [StringLength(200)]
        public string? GraphicName { get; set; }

        [Required]
        [Column(TypeName = "money")]
        public decimal CostPrice { get; set; }

        [Required]
        [Column(TypeName = "money")]
        public decimal MSRP { get; set; }

        [Required]
        public int QtyOnHand { get; set; }

        [Required]
        public int QtyOnBackOrder { get; set; }

        [StringLength (2000)]
        public string? Description { get; set; }

    }
}
