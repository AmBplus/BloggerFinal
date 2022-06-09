using P.Domain.Services.ArticleCategoryServices;

namespace P.Domain.ArticleCategoryAgg;

public class ArticleCategory
{
    public long Id { get; }
    public string Title { get; private set; }
    public bool IsDeleted { get; private set; }
    public DateTime CreationDate { get; }

    public ArticleCategory(string title, IArticleCategoryValidatorService validateService)
    {
        validateService.ValidAll(title);
        Title = title;
         IsDeleted = false;
         CreationDate = DateTime.Now;
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