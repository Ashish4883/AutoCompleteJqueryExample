using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AutoCompleteJqueryExample.Models
{
    [Table("billing")]
    public class billing
    {
        public int id { get; set; }
        public int ClientID { get; set; }
        public string region { get; set; }
        public float billAmount { get; set; }
    }
}