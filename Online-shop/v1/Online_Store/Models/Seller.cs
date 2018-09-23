using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online_Store.Models
{
    public class Seller
    {
        private ICollection<Product> products;

        private ICollection<Feedback> feedbacks;

        public Seller()
        {
            this.products = new HashSet<Product>();
            this.feedbacks = new HashSet<Feedback>();
        }

        [Key, ForeignKey("User")]
        public int UserId { get; set; }

        public virtual User User { get; set; }
        
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

        public virtual ICollection<Feedback> Feedbacks
        {
            get
            {
                return this.feedbacks;
            }
            set
            {
                this.feedbacks = value;
            }
        }
    }
}
