using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Online_Store.Core.Providers;
using Online_Store.Data;
using Online_Store.Models;

namespace Online_Store.Commands.FeedbackCommands
{
    public class EditCommentCommand : Command, ICommand
    {
        public EditCommentCommand(IStoreContext context, IWriter writer, IReader reader) : base(context, writer, reader)
        {
        }

        public override string Execute()
        {
            IList<string> parameters = TakeInput();

            var product = parameters[0];
            var feedbackId = int.Parse(parameters[1]);
            var newComment = parameters[2];

            Feedback feedback = base.context.Feedbacks.Single(f => f.Id == feedbackId);

            feedback.Comment = newComment;

            return $"Comment edited succesfully";
        }

        private IList<string> TakeInput()
        {
            var product = base.ReadOneLine("Product: ");
            var feedback = base.ReadOneLine("Feedback ID: ");
            var newComment = base.ReadOneLine("Edit comment: ");

            return new List<string>() { product, feedback, newComment };
           
        }
    }
}
