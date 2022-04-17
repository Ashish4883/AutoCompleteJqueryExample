using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AutoCompleteJqueryExample.Models
{
    public class CityContext : DbContext
    {
        public DbSet<City> City { get; set; }

        public System.Data.Entity.DbSet<AutoCompleteJqueryExample.Models.billing> billings { get; set; }
    }
}