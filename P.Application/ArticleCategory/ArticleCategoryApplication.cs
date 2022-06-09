using System.Globalization;
using P.Application.Contracts.ArticleCategory;
using P.Domain.ArticleCategoryAgg;
using P.Domain.Services;

namespace P.Application.ArticleCategory;

public class ArticleCategoryApplication : IArticleCategoryApplication
{
    private readonly IArticleCategoryRepository _articleCategoryRepository;
    private readonly IArticleCategoryValidatorService _articleValidatorArticleCategory;

    public ArticleCategoryApplication(IArticleCategoryRepository articleCategoryRepository,
        IArticleCategoryValidatorService articleValidatorArticleCategory)
    {
        _articleCategoryRepository = articleCategoryRepository;
        _articleValidatorArticleCategory = articleValidatorArticleCategory;
    }

    public List<ArticleCategoryViewModel> List()
    {
        List<Domain.ArticleCategoryAgg.ArticleCategory> artileCategoryList = _articleCategoryRepository.GetAll();
        List<ArticleCategoryViewModel> result = new();
        foreach (Domain.ArticleCategoryAgg.ArticleCategory article in artileCategoryList)
            result.Add(new ArticleCategoryViewModel
                {
                    Id = article.Id,
                    IsDeleted = article.IsDeleted,
                    Title = article.Title,
                    CreationDate = article.CreationDate.ToString(CultureInfo.InvariantCulture)
                }
            );

        return result;
    }

    public void Add(AddCategoryArticle command)
    {
        _articleCategoryRepository.Add(
            new Domain.ArticleCategoryAgg.ArticleCategory(command.Title, _articleValidatorArticleCategory));
    }

    public void Update(UpdateCategoryArticle updateCategoryArticle)
    {
        Domain.ArticleCategoryAgg.ArticleCategory? findArticle =
            _articleCategoryRepository.Getby(updateCategoryArticle.Id);
        if (findArticle != null)
        {
            findArticle.ReTitle(updateCategoryArticle.Title);
            _articleCategoryRepository.Save();
        }
    }

    public UpdateCategoryArticle? GetUpdateCategoryArticle(long id)
    {
        Domain.ArticleCategoryAgg.ArticleCategory? findArticle = _articleCategoryRepository.Getby(id);
        if (findArticle != null)
        {
            UpdateCategoryArticle updateArticle = new UpdateCategoryArticle
            {
                Id = findArticle.Id,
                Title = findArticle.Title
            };
            return updateArticle;
        }

        return null;
    }

    public void ReStatus(long id)
    {
        Domain.ArticleCategoryAgg.ArticleCategory? findArticle = _articleCategoryRepository.Getby(id);
        if (findArticle != null)
        {
            if (!findArticle.IsDeleted)
                findArticle.ReStatus(true);
            else
                findArticle.ReStatus(false);
            _articleCategoryRepository.Save();
        }
    }
}