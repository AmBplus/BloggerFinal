using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using P.Application.ArticleCategory;
using P.Application.Contracts.ArticleCategory;
using P.Domain.ArticleCategoryAgg;
using P.Domain.Services;
using P.Infrastructure.EfCore;
using P.Infrastructure.EfCore.Repository.ArticleCategoryRepository;

namespace Insfrustucture.Configuration;

public class Bootstrapper
{
    public static void Config(IServiceCollection services, string connection)
    {
        services.AddDbContext<MasterBlogerContext>(op => op.UseSqlServer(connection));
        services.AddTransient<IArticleCategoryRepository, ArticleCategoryRepository>();
        services.AddTransient<IArticleCategoryApplication, ArticleCategoryApplication>();
        services.AddTransient<IArticleCategoryValidatorService, ArticleCategoryValidatorService>();
    }
}