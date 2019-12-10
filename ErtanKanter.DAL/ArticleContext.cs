using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErtanKanter.DAL
{
    public class ArticleContext : DbContext
    {
        public ArticleContext(DbContextOptions options)
           : base(options)
        {
        }

        public DbSet<Article> Articles { get; set; }
    }
}
