namespace P.Domain.Services.ArticleCategoryServices;

public interface IArticleCategoryValidatorService
{
    void CheckExitRecord(string title);
    void GuardAgainstEmptyTitle(string title);
    void ValidAll(string title);
}