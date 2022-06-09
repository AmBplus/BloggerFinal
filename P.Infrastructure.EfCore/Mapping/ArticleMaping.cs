using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P.Domain.ArticleAgg;

namespace P.Infrastructure.EfCore.Mapping;

public class ArticleMaping : IEntityTypeConfiguration<Article>
{
    public void Configure(EntityTypeBuilder<Article> builder)
    {
        throw new NotImplementedException();
    }
}