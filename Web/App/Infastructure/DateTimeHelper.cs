using System;
using System.Collections.Generic;
using System.Linq;
using System.Web; 

namespace Web.App.Infastructure
{
    public class DateTimeHelper
    {
        public DateTime GetAdjustedDate
        {
            get
            {
                //meester server no have right time for you.
                var configs = new ConfigsController(null);
                dynamic timeZoneOffset = ((IEnumerable<dynamic>)configs.Get("TimeZoneOffset")).FirstOrDefault();
                double tzo = (timeZoneOffset != null ) ? Convert.ToInt32(timeZoneOffset.Value) : -4;
                return DateTime.UtcNow.AddHours(tzo);
            }
        }
    }
}