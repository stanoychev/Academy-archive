using Online_Store.Core.Providers;
using Online_Store.Data;
using System.Linq;
using System.Text;

namespace Online_Store.Commands.FeedbackCommands
{
    public class ListFeedbacksCommand : Command, ICommand
    {
        public ListFeedbacksCommand(IStoreContext context, IWriter writer, IReader reader) : base(context, writer, reader)
        {
        }

        public override string Execute()
        {
            var productName = base.ReadOneLine("Product: ");

            var feedbacks = base.context.Products.Single(p => p.ProductName == productName).Feedbacks;

            StringBuilder builder = new StringBuilder();

            foreach (var feedback in feedbacks)
            {
                builder.Append(feedback);
            }

            return builder.ToString();
        }

    }
}
