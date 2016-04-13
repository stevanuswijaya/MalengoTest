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
            // Prepare data
            PalindromeFactory.Instance.MinLength = 7;
            PalindromeFactory.Instance.MaxLength = 8;
            PalindromeFactory.Instance.MaxCapacity = 10;
            // Populate new palindrome string
            var result = PalindromeFactory.Instance.PopulatePalindromeString();

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
