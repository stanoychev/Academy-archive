using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online_Store.Models
{
    public class Category
    {
        private ICollection<Product> products;

        public Category()
        {
            this.products = new HashSet<Product>();
        }

        public Category(string categoryName)
        {
            this.CategoryName = categoryName;
        }

        public int Id { get; set; }
        //vtorirpod.categ.id == pyrviprod.categ.id
        [Required]
        [StringLength(450)]
        [Index(IsUnique = true)]
        public string CategoryName { get; set; }

        public virtual ICollection<Product> Products
        {
            get
            {
                return this.products;
            }
            set
            {
                this.products = value;
            }
        }
    }
}
