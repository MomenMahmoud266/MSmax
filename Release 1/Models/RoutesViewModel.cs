using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Release_1.Models
{
    public class RoutesViewModel
    {
        public route_bd route { get; set; }
        public List<country_bd> countries { get; set; }
        public List<city_bd> cities { get; set; }

    }
}