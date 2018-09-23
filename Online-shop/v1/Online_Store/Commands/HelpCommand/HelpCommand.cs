using Online_Store.Core.Providers;
using Online_Store.Data;

namespace Online_Store.Commands.HelpCommand
{
    public class HelpCommand : Command
    {
        public HelpCommand(IStoreContext context, IWriter writer, IReader reader)
            : base(context, writer, reader)
        {
        }

        public override string Execute()
        {
            string wellcome = "Wellcome to the Online shop.";
            string line0    = "For your ease all commands are case insensitive.";
            string line1    = "This means: [lpbc] = [Lpbc] = [lPbC] = [LPBC]";
            string line2    = "# # # # # # # # # Account commands:";
            string line3    = "[Login]                    or  [li]    Login.";
            string line4    = "[Logout]                   or  [lo]    Logout.";
            string line5    = "[CreateUser]               or  [cu]    Creates new user account.";
            string line6    = "[BecomeSeller]             or  [bs]    Makes the currently logged user with seller privileges.";
            string line7    = "[Exit]                     or  [e]     Quits the application.";
            string line8    = "# # # # # # # # # Product commands:";
            string line9    = "[AddProduct]               or  [ap]    Adds a product. Only available for sellelrs.";
            string line10   = "[ListAllProducts]          or  [lap]   Lists all products.";
            string line11   = "[ListFeedbacksForProduct]  or  [lffp]  Lists all feedbacks for choosen product.";
            string line12   = "[ListProductsByCategory]   or  [lpbc]  Lists all products in choosen category.";
            string line13   = "[ListProductsOnSale]       or  [lpos]  Lists all  products, which are on sale.";
            string line14   = "[RemoveProduct]            or  [rp]    Removes product. Only available for sellelrs.";
            string line15   = "# # # # # # # # # Seller products:";
            string line16   = "[SellerProducts]           or  [sp]    Lists all products by the seller, who posted them.";
            string line17   = "[ListSellerFeedbacks]      or  [lsf]   Lists all feedbacks for some seller.";
            string line18   = "[UpdateProduct]            or  [up]    Updates products properties.";
            string line19   = "# # # # # # # # # Cart commands:";   
            string line20   = "[AddToCart]                or  [atc]   Adds some product to the users cart.";
            string line21   = "[CheckoutCart]             or  [cc]    Checks the users cart out.";
            string line22   = "# # # # # # # # # Feedback commands:";
            string line23   = "[AddFeedback]              or  [af]    Adds a feedback for selelr or product.";
            string line24   = "[EditComment]              or  [ef]    Edits comment, left from the currently logged user.";
            string line25   = "[ListFeedbacks]            or  [lf]    Lists the feedbacks for some product or seller.";
            string line26   = "# # # # # # # # # # # # # # # # # # # # # # # # #";

            string[] allcommands = new string[]
            {
                wellcome, line0, line1, line2, line3, line4, line5, line6, line7, line8, line9, line10,
                line11, line12, line13, line14, line15, line16, line17, line18, line19, line20,
                line21, line22, line23, line24, line25, line26
            };

            return string.Join("\n", allcommands);
        }

    }
}
