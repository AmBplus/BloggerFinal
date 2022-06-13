using System.Globalization;
using Microsoft.EntityFrameworkCore;
using P.Application.Contracts.Article;
using P.Application.Contracts.Comment;
using P.Domain.CommentAgg;
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
        return Context.Articles.Include(x => x.ArticleCategory)
            .Include(x => x.Comments)
            .Where(x => !x.IsDeleted).Select(x =>
                new ArticleToUserMiniViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    ArticleCategory = x.ArticleCategory.Title,
                    CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
                    Image = x.Image,
                    ShortDescription = x.ShortDescription,
                    Count = x.Comments.Count(comment => comment.Status == Statuses.Confirm)
                }).ToList();
    }

    public List<ArticleToUserFullViewModel> GetListArticleToUserFullViewModel()
    {
        return Context.Articles.Include(x => x.ArticleCategory)
            .Include(x => x.Comments)
            .Where(x => !x.IsDeleted).Select(x =>
                new ArticleToUserFullViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    ArticleCategory = x.ArticleCategory.Title,
                    CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
                    Content = x.Content,
                    Image = x.Image,
                    CommentsToUser = x.Comments.Where(comment => comment.Status == Statuses.Confirm).Select(comment =>
                        new CommentToUserViewModel
                        {
                            Name = comment.Name,
                            CreationDate = comment.CreationDate.ToString(CultureInfo.InvariantCulture),
                            Message = comment.Message
                        }),
                    Count = x.Comments.Count(comment => comment.Status == Statuses.Confirm)
                }).ToList();
    }

    public ArticleToUserFullViewModel? GetArticleToUserFullViewModel(long id)
    {
        ArticleToUserFullViewModel? findArticle = Context.Articles.Include(x => x.ArticleCategory)
            .Include(x => x.Comments)
            .Where(x => !x.IsDeleted)
            .Select(x => new ArticleToUserFullViewModel
            {
                Id = x.Id,
                Title = x.Title,
                ArticleCategory = x.ArticleCategory.Title,
                Content = x.Content,
                CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
                Image = x.Image,
                CommentsToUser = x.Comments.Where(b => b.Status == Statuses.Confirm).Select(c =>
                    new CommentToUserViewModel
                    {
                        Name = c.Name,
                        CreationDate = c.CreationDate.ToString(CultureInfo.InvariantCulture),
                        Message = c.Message
                    }),
                Count = x.Comments.Count(b => b.Status == Statuses.Confirm)
            })
            .FirstOrDefault(x => x.Id == id);
        return findArticle;
    }
}