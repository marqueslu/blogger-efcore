using blogger.api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace blogger.api.Data.Maps
{
    public class ArticleMap : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.ToTable("Article");
            builder.HasKey("Id");
            builder.Property(x => x.Title).IsRequired().HasMaxLength(200).HasColumnType("varchar(200)");
            builder.Property(x => x.Content).IsRequired().HasColumnType("varchar(max)");
        }
    }
}