using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using P.Application.Contracts.ArticleCategory;

namespace MasterArticleBloger.Areas.Adminstrator.Pages.ArticleCategoryManagement
{
    public class CreateModel : PageModel
    {
        public CreateModel(IArticleCategoryApplication articleCategoryApplication)
        {
            _ArticleCategoryApplication = articleCategoryApplication;
        }


        public readonly IArticleCategoryApplication _ArticleCategoryApplication;

        [BindProperty] public AddCategoryArticle CategoryArticleCommand { get; set; }

        public void OnGet()
        {
        }

        public RedirectToPageResult OnPost()
        {
            _ArticleCategoryApplication.Add(CategoryArticleCommand);
            return RedirectToPage("./List");
        }
    }
}
