namespace P.Application.Contracts.ArticleCategory;

public interface IArticleCategoryApplication
{
    List<ArticleCategoryViewModel> List();
    void Add(AddCategoryArticle command);
    void Update(UpdateCategoryArticle updateCategoryArticle);

    UpdateCategoryArticle? GetUpdateCategoryArticle(long id);
    void ReStatus(long id);
}