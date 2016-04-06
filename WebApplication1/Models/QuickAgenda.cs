using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class QuickAgenda: DbContext
    {

        public DbSet<Person> People { get; set; }

        public System.Data.Entity.DbSet<WebApplication1.Models.Car> Cars { get; set; }

        public DbSet<File> Files { get; set; }
    }
}