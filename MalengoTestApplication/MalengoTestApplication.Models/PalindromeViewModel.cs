using System.Collections.Generic;

namespace MalengoTestApplication.Models
{
    public class PalindromeViewModel
    {
        private static PalindromeViewModel instance;

        private PalindromeViewModel()
        {
            if (PalindromeList == null)
                PalindromeList = new List<PalindromeModel>();
            if (IsGenerated == null)
                IsGenerated = true;
        }

        public static PalindromeViewModel Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PalindromeViewModel();
                }
                return instance;
            }
        }

        public List<PalindromeModel> PalindromeList
        {
            set; get;
        }

        public bool? IsGenerated
        {
            set; get;
        }

        public int ListCount
        {
            get
            {
                return PalindromeList != null ? PalindromeList.Count : 0;
            }
        }
    }
}