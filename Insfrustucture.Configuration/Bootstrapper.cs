using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using P.Application.Article;
using P.Application.ArticleCategory;
using P.Application.Contracts.Article;
using P.Application.Contracts.ArticleCategory;
using P.Domain.ArticleAgg;
using P.Domain.ArticleCategoryAgg;
using P.Domain.Services.ArticleCategoryServices;
using P.Domain.Services.ArticleServices;
using P.Infrastructure.EfCore;
using P.Infrastructure.EfCore.Repository.ArticeRepository;
using P.Infrastructure.EfCore.Repository.ArticleCategoryRepository;

namespace Insfrustucture.Configuration;

public class Bootstrapper
{
    public static void Config(IServiceCollection services, string connection)
    {
        services.AddDbContext<MasterBlogerContext>(op
            => op.UseSqlServer(connection
                , x => x.MigrationsAssembly("MasterArticleBloger")
            ));
        // ArticleCategoryServices
        services.AddTransient<IArticleCategoryRepository, ArticleCategoryRepository>();
        services.AddTransient<IArticleCategoryApplication, ArticleCategoryApplication>();
        services.AddTransient<IArticleCategoryValidatorService, ArticleCategoryValidatorService>();
        // ArticleServices
        services.AddTransient<IArticleRepository, ArticleRepository>();
        services.AddTransient<IArticleApplication, ArticleApplication>();
        services.AddTransient<IArticleValidatorServices, ArticleValidatorServices>();
    }
}