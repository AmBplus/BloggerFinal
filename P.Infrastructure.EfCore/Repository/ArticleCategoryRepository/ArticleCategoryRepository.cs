using P.Domain.ArticleCategoryAgg;

namespace P.Infrastructure.EfCore.Repository.ArticleCategoryRepository;

public class ArticleCategoryRepository : IArticleCategoryRepository
{
    private readonly MasterBlogerContext _context;

    public ArticleCategoryRepository(MasterBlogerContext context)
    {
        _context = context;
    }

    public List<ArticleCategory> GetAll()
    {
        return _context.ArticleCategories.ToList();
    }

    public void Add(ArticleCategory entity)
    {
        _context.ArticleCategories.Add(entity);
        Save();
    }

    public ArticleCategory Getby(long id)
    {
        return _context.ArticleCategories.FirstOrDefault(x => x.Id == id);
    }

    public void Save()
    {
        _context.SaveChanges();
    }

    public bool ExitsBy(string Title)
    {
        return _context.ArticleCategories.Any(x => x.Title == Title);
    }
}