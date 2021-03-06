using System;
using blogger.api.Data.Maps;
using blogger.api.Models;
using Microsoft.EntityFrameworkCore;

namespace blogger.api.Data
{
    public class BloggerDataContext : DbContext
    {
        public DbSet<Article> Articles {get; set;}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=localhost,1433;Database=Blogger;User ID=SA;Password=123Aa321");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ArticleMap());
        }
    }
}