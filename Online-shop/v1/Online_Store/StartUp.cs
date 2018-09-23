using Ninject;
using Online_Store.Core;
using Online_Store.Data;
using Online_Store.Migrations;
using Online_Store.Ninject;
using Online_Store.ReportGenerators;
using System.Data.Entity;
using System.Linq;

namespace Online_Store
{
    public class StartUp
    {
        public static void Main()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StoreContext, Configuration>());
            using (var context = new StoreContext())
            {
                var databaseMaterialization = context.Users.ToList();

                //var gen = new PdfGenerators();
                //gen.GeneratePdf(context, "../", "NAMEPDF.pdf");
            }


            IKernel kernel = new StandardKernel(new StoreModule());

            IEngine engine = kernel.Get<IEngine>();
            engine.Start();

            //using (var context = new StoreContext())
            //{
            //    var product = new Product("name2", 20.12m, PaymentMethodEnum.Cash);
            //    var shipD = new ShippingDetails(20m);
            //    product.ShippingDetails = shipD;
            //    //product.SellerId = 1;
            //    product.Seller = context.Users.Single(i => i.Id == 1).Seller;

            //    context.Products.Add(product);
            //    context.ShippingDetails.Add(shipD);

            //    context.SaveChanges();
            //}

            //using (var context = new StoreContext())
            //{
            //    var feed = new Feedback(5, "lilii maliii");
            //    feed.Product = context.Products.First();

            //    context.Feedbacks.Add(feed);
            //    context.SaveChanges();
            //}
        }
    }
}
