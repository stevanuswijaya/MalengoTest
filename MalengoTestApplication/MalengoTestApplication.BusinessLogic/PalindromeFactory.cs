using MalengoTestApplication.BusinessLogic.CommonFunctions;
using MalengoTestApplication.BusinessLogic.Interface;
using MalengoTestApplication.Models;
using System;
using System.Linq;
using System.Text;

namespace MalengoTestApplication.BusinessLogic
{
    public class PalindromeFactory : IPalindromeFactory
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public PalindromeViewModel PopulatePalindromeString(int minLength, int maxLength, int maxCapacity)
        {
            if (PalindromeViewModel.Instance.PalindromeList == null)
                PalindromeViewModel.Instance.PalindromeList = new System.Collections.Generic.List<PalindromeModel>();
            StringBuilder newPalindrome = new StringBuilder("");

            if (minLength > 0 && maxLength > 0 && maxCapacity > 0)
            {
                decimal length;
                do
                {
                    newPalindrome.Clear();
                    //Prepare random number between minlength to maxlength
                    var random = new Random();
                    length = random.Next(minLength, maxLength + 1);

                    //Get the first part of the palindrome string
                    var strings = new string(Enumerable.Repeat(chars,
                        int.Parse((Math.Ceiling(length / 2)).ToString()))
                        .Select(s => s[random.Next(s.Length)]).ToArray());

                    bool isOdd = length % 2 == 1;
                    newPalindrome.Append(strings);

                    //Get the second part of the palindrome string
                    var reversedStrings = HelperClass.Reverse(strings);
                    if (isOdd)
                        reversedStrings = reversedStrings.Remove(0, 1);
                    newPalindrome.Append(reversedStrings);
                }
                while
                (PalindromeViewModel.Instance.ListCount > 0
                && PalindromeViewModel.Instance.PalindromeList.Exists(x=>x.PalindromeString == newPalindrome.ToString()));

                if (maxCapacity <= PalindromeViewModel.Instance.ListCount)
                {
                    PalindromeViewModel.Instance.PalindromeList.RemoveAt(0);
                }

                PalindromeViewModel.Instance.PalindromeList.Add(new PalindromeModel
                {
                    PalindromeString = newPalindrome.ToString(),
                    Length = Convert.ToInt32(length)
                });
                return PalindromeViewModel.Instance;
            }
            return null;
        }
    }
}
