using MalengoTestApplication.Models;

namespace MalengoTestApplication.BusinessLogic.Interface
{
    public interface IPalindromeFactory
    {
        PalindromeViewModel PopulatePalindromeString(int minLength, int maxLength, int maxCapacity);
    }
}
