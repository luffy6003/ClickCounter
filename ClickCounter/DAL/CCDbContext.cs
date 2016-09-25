using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using ClickCounter.Models;
namespace ClickCounter.DAL
{
    public class CCDbContext : DbContext
    {
        public CCDbContext() : base("name=CCDbContext")
        {

        }

        public DbSet<Counter> Counters { get; set; }
    }
}