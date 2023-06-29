
namespace WebApplication5.BL.helper;

    //this class to validate that end date bigger than start date
   public class DateVaildator
    {
        public static  bool validate(DateTime start,DateTime end)
        {
            if(start.Date >= end.Date)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    
}
