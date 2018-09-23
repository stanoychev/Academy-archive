using Online_Store.Models;
using System.Data.Entity;

namespace Online_Store.Data
{
    public class StoreContext : DbContext, IStoreContext
    {
        public StoreContext()
            : base("StoreDB")
        {

        }   

        public IDbSet<User> Users { get; set; }
        public IDbSet<Seller> Sellers { get; set; }
        public IDbSet<Cart> Carts { get; set; }
        public IDbSet<Product> Products { get; set; }
        public IDbSet<Category> Categories { get; set; }
        public IDbSet<ShippingDetails> ShippingDetails { get; set; }
        public IDbSet<Feedback> Feedbacks { get; set; }
        public IDbSet<Sale> Sales { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasRequired(t => t.ShippingDetails)
                .WithRequiredPrincipal(t => t.Product)
                .WillCascadeOnDelete(true);

            //modelBuilder.Entity<Cart>()
            //    .HasKey(c => c.UserId);

            //modelBuilder.Entity<Cart>()
            //    .HasRequired(t => t.User);

            modelBuilder.Entity<Feedback>()
                .HasOptional(x => x.Product);

            modelBuilder.Entity<Product>()
                .HasMany(x => x.Feedbacks)
                .WithOptional(x => x.Product)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Sale>()
                .HasKey(x => x.ProductId);

            modelBuilder.Entity<Product>()
                .HasOptional(x => x.Sale)
                .WithRequired(x => x.Product)
                .WillCascadeOnDelete(true);

            base.OnModelCreating(modelBuilder);
        }
    }

}