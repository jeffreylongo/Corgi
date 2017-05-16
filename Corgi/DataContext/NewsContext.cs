using Corgi.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Corgi.DataContext
{
    public class NewsContext : DbContext
    {
        public NewsContext() : base("name=DefaultConnection")
        {

        }

        public DbSet<NewsFeed> News { get; set; }
    }

}