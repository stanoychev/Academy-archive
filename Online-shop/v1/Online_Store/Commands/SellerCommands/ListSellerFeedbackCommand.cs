using Bytes2you.Validation;
using Online_Store.Core.Providers;
using Online_Store.Data;
using System.Linq;
using System.Text;

namespace Online_Store.Commands.SellerCommands
{
    public class ListSellerFeedbackCommand : Command, ICommand
    {
        private ILoggedUserProvider loggedUserProvider;

        public ListSellerFeedbackCommand(ILoggedUserProvider loggedUserProvider, IStoreContext context,
            IWriter writer, IReader reader)
            : base(context, writer, reader)
        {
            Guard.WhenArgument(loggedUserProvider, "loggedUserProvider").IsNull().Throw();

            this.loggedUserProvider = loggedUserProvider;
        }

        public override string Execute()
        {
            var feedbacks = this.context.Sellers
                          .Single(i => i.UserId == this.loggedUserProvider.CurrentUserId).Feedbacks;
            if (feedbacks.Count == 0)
            {
                return "You aren't selling any products!";
            }

            StringBuilder result = new StringBuilder();
            foreach (var feedback in feedbacks)
            {
                result.Append(feedback.ToString());
            }

            return result.ToString();
        }
    }
}
