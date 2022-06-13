using System.Globalization;
using Microsoft.EntityFrameworkCore;
using P.Application.Contracts.Article;
using P.Domain.ArticleAgg;
using P.Infrastructure.EfCore;

namespace P.Query;

public class ArticleToUserQuery : IArticleToUserQuery
{
    public ArticleToUserQuery(MasterBlogerContext context)
    {
        Context = context;
    }

    private MasterBlogerContext Context { get; }

    public List<ArticleToUserMiniViewModel> GetListArticleToUserMiniViewModel()
    {
        return Context.Articles.Include(x => x.ArticleCategory).Where(x => !x.IsDeleted).Select(x =>
            new ArticleToUserMiniViewModel
            {
                Id = x.Id,
                Title = x.Title,
                ArticleCategory = x.ArticleCategory.Title,
                CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
                Image = x.Image,
                ShortDescription = x.ShortDescription
            }).ToList();
    }

    public List<ArticleToUserFullViewModel> GetListArticleToUserFullViewModel()
    {
        return Context.Articles.Include(x => x.ArticleCategory).Where(x => !x.IsDeleted).Select(x =>
            new ArticleToUserFullViewModel
            {
                Id = x.Id,
                Title = x.Title,
                ArticleCategory = x.ArticleCategory.Title,
                CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
                Content = x.Content,
                Image = x.Image
            }).ToList();
    }

    public ArticleToUserFullViewModel? GetArticleToUserFullViewModel(long id)
    {
        Article? findArticle = Context.Articles.Include(x => x.ArticleCategory).Where(x => !x.IsDeleted)
            .FirstOrDefault(x => x.Id == id);
        if (findArticle == null) return null;
        return new ArticleToUserFullViewModel
        {
            Id = findArticle.Id,
            Title = findArticle.Title,
            ArticleCategory = findArticle.ArticleCategory.Title,
            Content = findArticle.Content,
            CreationDate = findArticle.CreationDate.ToString(CultureInfo.InvariantCulture),
            Image = findArticle.Image
        };
    }
}