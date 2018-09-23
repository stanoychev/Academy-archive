using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Online_Store.Commands;
using Online_Store.Commands.FeedbackCommands;
using Online_Store.Core.Providers;
using Online_Store.Data;
using Online_Store.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Online_Store_Tests.Commands.FeedbackCommands.ListFeedbacksCommandTests
{
    [TestClass]
    public class Execute_Should
    {
        [TestMethod]
        public void ListFeedbacksAsString_WhenInvoked()
        {
            //arrange
            var context = new Mock<IStoreContext>();
            var writer = new Mock<IWriter>();
            var reader = new Mock<IReader>();

            string productName = "testproduct";

            Product testproduct1 = new Product();
            Product testproduct2 = new Product();
            Product testProductObject = new Product(); //no need from mock, because it contains no logic
            testProductObject.ProductName = productName;

            List<Product> productCollection = new List<Product>() { testProductObject, testproduct1, testproduct2 };

            var productsInDbMock = new Mock<DbSet>();
            
            //productsInDbMock.Setup(x => x.)

            //context.Setup(x => x.Products).Returns(productCollection);

            ICommand listFeedbacks = new ListFeedbacksCommand(context.Object, writer.Object, reader.Object);

            //act


            //assert

        }
    }
}
