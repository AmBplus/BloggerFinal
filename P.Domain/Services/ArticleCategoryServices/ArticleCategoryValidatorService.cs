using P.Domain.ArticleCategoryAgg;

namespace P.Domain.Services.ArticleCategoryServices;

public class ArticleCategoryValidatorService : IArticleCategoryValidatorService
{
    public ArticleCategoryValidatorService(IArticleCategoryRepository articleCategoryRepository)
    {
        ArticleCategoryRepository = articleCategoryRepository;
    }

    private IArticleCategoryRepository ArticleCategoryRepository { get; }

    public void CheckExitRecord(string title)
    {
        bool flagExistRecord = ArticleCategoryRepository.ExitsBy(title);
        if (flagExistRecord) throw new Exception("This Record Already Exits");
    }

    public void GuardAgainstEmptyTitle(string title)
    {
        if (string.IsNullOrEmpty(title) || string.IsNullOrWhiteSpace(title))
            throw new Exception("Danger => Null Or Empty Or Just White Space => invalid Data");
    }

    public void ValidAll(string title)
    {
        GuardAgainstEmptyTitle(title);
        CheckExitRecord(title);
    }
}