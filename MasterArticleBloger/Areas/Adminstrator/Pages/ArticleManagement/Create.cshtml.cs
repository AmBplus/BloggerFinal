using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using P.Application.Contracts.Article;
using P.Application.Contracts.ArticleCategory;

namespace MasterArticleBloger.Areas.Adminstrator.Pages.ArticleManagement
{
    public class CreateModel : PageModel
    {
        public CreateModel(IArticleApplication articleApplication, IArticleCategoryApplication articleCategory)
        {
            ArticleApplication = articleApplication;
            ArticleCategory = articleCategory;
        }

        public void OnGet()
        {
            SelectCategoryListItems = ArticleCategory.List().Select
            (x => new SelectListItem
                (x.Title, x.Id.ToString())).ToList();
        }

        private IArticleApplication ArticleApplication { get; set; }
        private IArticleCategoryApplication ArticleCategory { get; set; }
        [BindProperty] public CreateArticle CreateArticle { get; set; }

        public List<SelectListItem> SelectCategoryListItems { get; set; }

        //public  Createdmodel  createdModels { get; set; }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                ArticleApplication.Add(CreateArticle);
                return RedirectToPage("./Index");
            }

            SelectCategoryListItems = ArticleCategory.List().Select
            (x => new SelectListItem
                (x.Title, x.Id.ToString())).ToList();
            return Page();
        }
    }
}
