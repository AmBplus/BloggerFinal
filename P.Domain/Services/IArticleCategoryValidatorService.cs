using P.Domain.ArticleCategoryAgg;

namespace P.Domain.Services;

public interface IArticleCategoryValidatorService
{
    void CheckExitRecord(string title);
    void GurdAgainstEmptyTitle(string title);
    void ValidAll(string title);
}

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

    public void GurdAgainstEmptyTitle(string title)
    {
        if (string.IsNullOrEmpty(title) || string.IsNullOrWhiteSpace(title))
            throw new Exception("Danger => Null Or Empty Or Just White Space => invalid Data");
    }

    public void ValidAll(string title)
    {
        GurdAgainstEmptyTitle(title);
        CheckExitRecord(title);
    }
}