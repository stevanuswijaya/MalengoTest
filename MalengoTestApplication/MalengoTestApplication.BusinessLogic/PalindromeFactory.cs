using MalengoTestApplication.BusinessLogic.CommonFunctions;
using MalengoTestApplication.Models;
using System;
using System.Linq;
using System.Text;

namespace MalengoTestApplication.BusinessLogic
{
    public class PalindromeFactory
    {
        private static PalindromeFactory instance;
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public int MinLength { set; get; }

        public int MaxLength { set; get; }

        public int MaxCapacity { set; get; }

        public static PalindromeFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PalindromeFactory(5, 10, 10);
                }
                return instance;
            }
        }

        public PalindromeFactory(int minLength, int maxLength, int maxCapacity)
        {
            MinLength = minLength;
            MaxLength = maxLength;
            MaxCapacity = maxCapacity;
        }

        public PalindromeViewModel PopulatePalindromeString()
        {
            if (PalindromeViewModel.Instance.PalindromeList == null)
                PalindromeViewModel.Instance.PalindromeList = new System.Collections.Generic.List<PalindromeModel>();
            StringBuilder newPalindrome = new StringBuilder("");

            if (MinLength > 0 && MaxLength > 0 && MaxCapacity > 0)
            {
                decimal length;
                do
                {
                    newPalindrome.Clear();
                    //Prepare random number between minlength to maxlength
                    var random = new Random();
                    length = random.Next(MinLength, MaxLength + 1);

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

                if (MaxCapacity <= PalindromeViewModel.Instance.ListCount)
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
