using System.Globalization;
using Microsoft.EntityFrameworkCore;
using P.Application.Contracts.Article;
using P.Domain.ArticleAgg;

namespace P.Infrastructure.EfCore.Repository.ArticeRepository;

public class ArticleRepository : IArticleRepository
{
    public ArticleRepository(MasterBlogerContext context)
    {
        _context = context;
    }

    private MasterBlogerContext _context { get; }

    public List<IArticleViewModel> GetAllByViewModel()
    {
        return _context.Articles.Include(x => x.ArticleCategory).Select(x =>
            (IArticleViewModel)new ArticleViewModel
            {
                Id = x.Id,
                Title = x.Title,
                IsDeleted = x.IsDeleted,
                CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
                ArticleCategory = x.ArticleCategory.Title
            }).ToList();
    }

    public List<T> GetAllByViewModelGeneric<T>() where T : IArticleViewModel, new()
    {
        return _context.Articles.Include(x => x.ArticleCategory).Select(x =>
            new T
            {
                Id = x.Id,
                Title = x.Title,
                IsDeleted = x.IsDeleted,
                CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
                ArticleCategory = x.ArticleCategory.Title
            }).ToList();
    }

    List<Article> IArticleRepository.GetAll()
    {
        return _context.Articles.ToList();
    }

    public T? GetUpdateArticle<T>(long id) where T : IUpdateArticle, new()
    {
        return _context.Articles.Where(x => x.Id == id).Select(x => new T
        {
            Id = x.Id,
            ArticleCategoryId = x.ArticleCategoryId,
            Content = x.Content,
            Image = x.Image,
            ShortDescription = x.ShortDescription,
            Title = x.ShortDescription
        }).FirstOrDefault();
    }

    public IUpdateArticle? GetUpdateArticle(long id)
    {
        return _context.Articles.Where(x => x.Id == id).Select(x => (IUpdateArticle)new UpdateArticle
        {
            Id = x.Id,
            ArticleCategoryId = x.ArticleCategoryId,
            Content = x.Content,
            Image = x.Image,
            ShortDescription = x.ShortDescription,
            Title = x.ShortDescription
        }).FirstOrDefault();
    }


    public void Add(Article entity)
    {
        _context.Articles.Add(entity);
        Save();
    }

    public Article Getby(long id)
    {
        return _context.Articles.FirstOrDefault(x => x.Id == id);
    }

    public void Save()
    {
        _context.SaveChanges();
    }
}