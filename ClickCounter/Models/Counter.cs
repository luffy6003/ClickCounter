using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ClickCounter.Models
{
    public class Counter
    {
        [Key]
        public int CounterId { get; set; }
        public int ClickCounter { get; set; }

        
    }
}