using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traveller.Core;
using Traveller.Core.Factories;

namespace UnitTestProject1.Core.Providers.CommandParser.Tests
{
    [TestClass]
    public class ParseParameters_Should
    {
        [TestMethod]
        [DataRow("createtrain 300 0.4 3")]
        [DataRow("createairplane 250 1 true")]
        [DataRow("createticket 0 30")]
        [DataRow("listvehicles")]
        [DataRow("listjourneys")]
        [DataRow("listtickets")]
        public void ReturnsListFromStringsWithoutTheActualCoomand_WhenTheCommandHasParameters(string fullCommand)
        {
            //arrange
            IParser testParser = new Traveller.Core.Providers.CommandParser();
            int expectedNumberOfParameters = fullCommand.Split().Length-1;
            List<string> expectedParametersList = fullCommand.Split().ToList();
            expectedParametersList.RemoveAt(0);

            //act
            List<string> testList = testParser.ParseParameters(fullCommand).ToList();

            //assert
            Assert.AreEqual(expectedNumberOfParameters, testList.Count);
            CollectionAssert.AreEquivalent(expectedParametersList, testList);
        }

        [TestMethod]
        [DataRow("listvehicles")]
        [DataRow("listjourneys")]
        [DataRow("listtickets")]
        public void ReturnsEmptyListFromStrings_WhenTheCommandHasNoParameters(string fullCommand)
        {
            //arrange
            IParser testParser = new Traveller.Core.Providers.CommandParser();

            //act
            IList<string> testList = testParser.ParseParameters(fullCommand);

            //act and assert
            Assert.IsNotNull(testList);
            Assert.AreEqual(0, testList.Count);
            //That means it`s not null, but it`s empty.
        }

        [TestMethod]
        public void ThrowsException_WhenTheCommandIsNullOrEmpty()
        {
            //arrange
            string nullTestCommand = null;
            string emptyTestCommand = "";

            IParser testParser = new Traveller.Core.Providers.CommandParser();

            //act and assert
            Assert.ThrowsException<ArgumentNullException>(() => testParser.ParseParameters(nullTestCommand));
            Assert.ThrowsException<ArgumentException>(() => testParser.ParseParameters(emptyTestCommand));
        }
    }
}
