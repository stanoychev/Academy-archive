using Online_Store.Core.Factories;
using Online_Store.Core.Providers;
using Online_Store.Data;
using Online_Store.Models;
using System.Collections.Generic;
using System.Linq;

namespace Online_Store.Commands.FeedbackCommands
{
    public class AddFeedbackCommand : Command, ICommand
    {
        private IModelFactory factory;

        public AddFeedbackCommand(IModelFactory factory, IStoreContext context, IWriter writer, IReader reader) : base(context, writer, reader)
        {
            this.factory = factory;
        }

        public override string Execute()
        {
            IList<string> parameters = TakeInput();

            var toBeRated = parameters[0].ToLower();
            var Id = int.Parse(parameters[1]);
            var rating = int.Parse(parameters[2]);
            var comment = parameters[3];

            var feedback = factory.CreateFeedback();
            feedback.Rating = rating;
            feedback.Comment = comment;

            if (toBeRated == "seller")
            {
                base.context.Sellers.Single(x => x.UserId == Id).Feedbacks.Add(feedback);
            }
            else if (toBeRated == "product")
            {
                base.context.Products.Single(x => x.Id == Id).Feedbacks.Add(feedback);
            }
            
            return $"Feedback added successfully";
        }

        private IList<string> TakeInput()
        {
            var toBeRated = base.ReadOneLine("What do you want to rate, seller or product? ");
            var Id = base.ReadOneLine("Enter ID: ");
            var rating = base.ReadOneLine("Rate this product: ");
            var comment = base.ReadOneLine("Add comment: ");

            return new List<string>() {toBeRated, Id, rating, comment };

        }
    }
}
