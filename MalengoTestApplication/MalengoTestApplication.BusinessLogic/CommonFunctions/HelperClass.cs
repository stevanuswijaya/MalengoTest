using System;

namespace MalengoTestApplication.BusinessLogic.CommonFunctions
{
    public static class HelperClass
    {
        public static string Reverse(string text)
        {
            if (text == null) return null;
            char[] array = text.ToCharArray();
            Array.Reverse(array);
            return new string(array);
        }
    }
}