using Online_Store.Core.Providers;
using Online_Store.Data;

namespace Online_Store.Commands.EmptyCommand
{
    public class EmptyCommand : Command
    {
        public EmptyCommand(IStoreContext context, IWriter writer, IReader reader)
            : base(context, writer, reader)
        {
        }

        public override string Execute()
        {
            return "Command doesn`t exist. Type [help] for list of currently supported commands.";
        }
    }
}
/*

    
--delete from Categories
--delete from Sales
--delete from ShippingDetails
--delete from Feedbacks
--delete from Products
--delete from Sellers
--delete from Users

select * from Users
select * from Sellers
select * from Products
select * from Categories
select * from Sales
select * from ShippingDetails
select * from Feedbacks


 * */
