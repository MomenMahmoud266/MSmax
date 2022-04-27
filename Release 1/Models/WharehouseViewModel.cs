using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Release_1.Models
{
    public class WharehouseViewModel
    {
        public wharehouse_bd wharehouse { get; set; }

        public string Selectedunit { get; set; }
        public List<country_bd> active_countries { get; set; }

    }
}