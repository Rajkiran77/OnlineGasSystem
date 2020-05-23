using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;


namespace OnlineGasAgencySystem.Helper
{
   /* public static class Phonenum
    { 
    public static long? Phoneno(string userphone, string phoneFormat)
    {

        if (phoneFormat == "")
        {
            // If phone format is empty, code will use default format (###) ###-####
            phoneFormat = "(###-###-####";
        }

        // First, remove everything except of numbers
        Regex regexObj = new Regex(@"[^\d]");
        userphone = regexObj.Replace(userphone, "");

        // Second, format numbers to phone string
        if (userphone.Length > 0)
        {
            userphone= Convert.ToInt64(userphone).ToString(phoneFormat);
        }
        
        return userphone;
    }
    
    }*/
}