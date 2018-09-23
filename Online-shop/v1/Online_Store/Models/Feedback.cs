using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online_Store.Models
{
    public class Feedback
    {
        public Feedback()
        {
        }

        public Feedback(int rating, string comment = null)
        {
            this.Rating = rating;
            this.Comment = comment;
        }

        public int Id { get; set; }

        [Required]
        public int Rating { get; set; }

        public string Comment { get; set; }

        public Nullable<DateTime> Date { get; set; }

        public int UserId { get; set; }

        public int? ProductId { get; set; }

        public virtual Product Product { get; set; }

        [ForeignKey("Seller")]
        public int? SellerId { get; set; }

        public virtual Seller Seller { get; set; }

        public override string ToString()
        {
            string text = string.Format("Feedback for product with Id = {0}:\n{1}", this.ProductId, this.Comment);

            string decoratedText = string.Format("/ / / / / / / / / / / / / / / / /\n{0}\n",text);

            return decoratedText;
        }
    }
}
