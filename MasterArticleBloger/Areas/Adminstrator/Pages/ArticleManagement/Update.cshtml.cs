using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using P.Application.Contracts.Article;
using P.Application.Contracts.ArticleCategory;

namespace MasterArticleBlogger.Areas.Adminstrator.Pages.ArticleManagement;

public class UpdateModel : PageModel
{
    [BindProperty] public UpdateArticle UpdateArticle { get; set; }

    public void OnGet(long id)
    {
        UpdateArticle = ArticleApplication.GetUpdateArticleById(id);
        if (UpdateArticle == null) return;
        SelectCategoryListItems = ArticleCategory.List().Select
        (x => new SelectListItem
            (x.Title, x.Id.ToString())).ToList();
    }

    public UpdateModel(IArticleApplication articleApplication, IArticleCategoryApplication articleCategory)
    {
        ArticleApplication = articleApplication;
        ArticleCategory = articleCategory;
    }

    public IActionResult OnPost()
    {
        if (ModelState.IsValid)
        {
            ArticleApplication.Update(UpdateArticle);
            return RedirectToPage("./Index");
        }

        SelectCategoryListItems = ArticleCategory.List().Select
        (x => new SelectListItem
            (x.Title, x.Id.ToString())).ToList();
        return Page();
    }


    private IArticleApplication ArticleApplication { get; set; }
    private IArticleCategoryApplication ArticleCategory { get; set; }


    public List<SelectListItem> SelectCategoryListItems { get; set; }
}