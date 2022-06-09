using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P.Domain.ArticleAgg;
using P.Domain.ArticleCategoryAgg;

namespace P.Infrastructure.EfCore.Mapping;

public class ArticleMaping : IEntityTypeConfiguration<Article>
{
    public void Configure(EntityTypeBuilder<Article> builder)
    {
        builder.ToTable("Articles");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.ArticleCategoryId);
        builder.Property(x => x.Title);
        builder.Property(x => x.Content);
        builder.Property(x => x.CreationDate);
        builder.Property(x => x.Image);
        builder.Property(x => x.ShortDescription);
        builder.HasOne(x => x.ArticleCategor).WithMany(x => x.Articles).HasForeignKey(x => x.ArticleCategoryId);

    }
}