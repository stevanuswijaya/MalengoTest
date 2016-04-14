using Microsoft.VisualStudio.TestTools.UnitTesting;
using MalengoTestApplication.BusinessLogic;
using MalengoTestApplication.BusinessLogic.CommonFunctions;

namespace MalengoUnitTest
{
    [TestClass]
    public class PalindromeTest
    {
        [TestMethod]
        public void TestPalindromeString()
        {
            var factory = new PalindromeFactory();
            // Populate new palindrome string
            var result = factory.PopulatePalindromeString(7, 8, 10);

            //Check if the result is not null
            Assert.IsNotNull(result);

            //Check if each string is a palindrome
            foreach (var palindromeString in result.PalindromeList)
            {
                var reversed = HelperClass.Reverse(palindromeString.PalindromeString);

                Assert.IsTrue(palindromeString.PalindromeString == reversed);
            }
        }
    }
}
