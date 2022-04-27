using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Release_1.Models
{
    public class CityViewModel
    {   public city_bd city { get; set; }
        public List<country_bd> active_countries { get; set; }

    }
}