using _01_Framework.Domain;
using P.Domain.ArticleAgg;
using P.Domain.Services.ArticleCategoryServices;

namespace P.Domain.ArticleCategoryAgg;

public class ArticleCategory :BaseModel<long>
{
    public string Title { get; private set; }
    public bool IsDeleted { get; private set; }
    public ICollection<Article> Articles { get; set; }

    protected ArticleCategory()  :base()
    {
    }

    public ArticleCategory(string title, IArticleCategoryValidatorService validateService):base()
    {
        validateService.ValidAll(title);
        Title = title;
         IsDeleted = false;
         Articles = new List<Article>();
    }

    public void ReTitle(string title)
    {
        Title = title;
    }

    public void ReStatus(bool status)
    {
        IsDeleted = status;
    }
}