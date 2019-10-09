using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using BasketballCompetition.Models;
using BasketballCompetition.Controllers;

namespace UnitTest_Jing
{
    [TestClass]
    public class UnitTest_Team
    {
        [TestMethod]
        public void TeamUnitTest()
        {   //Arrange:Initialise objects and sets the value of sample data used in the method being tested
            TeamsUnitTestController controller = new TeamsUnitTestController();
            //Act:Invoke the method being tested
            IActionResult result = controller.Index() as IActionResult;
            //Assert: Verify the tested method behaves as expected
            Assert.IsNotNull(result);

        }
    }
}
