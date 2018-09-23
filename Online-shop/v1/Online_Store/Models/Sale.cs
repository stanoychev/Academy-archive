using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online_Store.Models
{
    public class Sale
    {
        public Sale()
        {
        }

        public Sale(int priceReduction)
        {
            this.PriceReduction = priceReduction;
        }
        
        [Key, ForeignKey("Product")]
        public int ProductId { get; set; }

        [Required]
        public virtual Product Product { get; set; }

        [Required]
        public decimal PriceReduction { get; set; }
    }
}
