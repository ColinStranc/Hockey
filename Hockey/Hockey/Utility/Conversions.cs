using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace Hockey.Utility
{
    public class Conversions
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(Conversions));

        public static int HeightMixedImperialtoInches(string mixedImperial)
        {
            
            string normalizedMixedImperial = mixedImperial.Replace("'", ".");
            String[] heightInFeetAndInches = normalizedMixedImperial.Split('.');
            if (heightInFeetAndInches.Length != 2)
            {
                return 0;
            }
            else
            {
                int heightInInches = (int.Parse(heightInFeetAndInches[0]) * 12)
                                     + int.Parse(heightInFeetAndInches[1]);
                return heightInInches;
            }
        }

        public static DateTime? DateStringToDateTimeMmmDYyyy(string dateAsString)
        {
            if (dateAsString == "")
            {
                return null;
            }
            else
            {
                return DateTime.ParseExact(dateAsString, "MMM d, yyyy", null);
            }
        }
        /*
        public static DateTime DateStringToDateTimeYyyy_Mm_Dd(string dateAsString)
        {
            return 
        }
        */
        public static int SafeParseInt(string str, int retval)
        {
            if (str == "")
            {
                return retval;
            }
            else
            {
                return int.Parse(str);
            }
        }
    }
}
