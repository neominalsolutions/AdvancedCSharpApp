using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akedas.Common.Datetime
{
  public static class DateTimeExtensions
  {
    // this DateTime ile this ile extend edilecek sınıf
    public static string GetFormatedDate(this DateTime dateTime, string format = "DD-MM-YYYY HH:mm")
    {
      if(format == "DD-MM-YYYY HH:mm")
      {
        return $"{dateTime.Day}/{dateTime.Month}/{dateTime.Year} {dateTime.Hour}:{dateTime.Minute}";
      }
      else if(format == "MM-DD-YYYY HH:mm")
      {
        return $"{dateTime.Month}/{dateTime.Day}/{dateTime.Year} {dateTime.Hour}:{dateTime.Minute}";
      }

      return dateTime.ToShortDateString();
   
    }
  }
}
