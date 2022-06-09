using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using P.Application.Contracts.ArticleCategory;

namespace MasterArticleBloger.Areas.Adminstrator.Pages.ArticleCategoryManagement
{
    public class IndexModel : PageModel
    {
        public IndexModel(IArticleCategoryApplication articleCategoryApplication)
        {
            _ArticleCategoryApplication = articleCategoryApplication;
        }


        public List<ArticleCategoryViewModel> ArticleCategoriesViews { get; set; }
        public readonly IArticleCategoryApplication _ArticleCategoryApplication;

        public void OnGet()
        {
            ArticleCategoriesViews = _ArticleCategoryApplication.List();
        }

        public RedirectToPageResult OnPostReStatus(long id)
        {
            _ArticleCategoryApplication.ReStatus(id);
            return RedirectToPage("./List");
        }

        public RedirectToPageResult Status(long id)
        {
            _ArticleCategoryApplication.ReStatus(id);
            return RedirectToPage("./List");
        }
    }
}
