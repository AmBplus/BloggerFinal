using Microsoft.AspNetCore.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using P.Application.Contracts.ArticleCategory;

namespace MasterArticleBlogger.Areas.Adminstrator.Pages.ArticleCategoryManagement;

public class UpdateModel : PageModel
{
    public UpdateModel(IArticleCategoryApplication articleCategoryApplication)
    {
        ArticleCategoryApplication = articleCategoryApplication;
    }

    private IArticleCategoryApplication ArticleCategoryApplication { get; set; }
    [BindProperty] public UpdateCategoryArticle? UpdateCategoryArticle { get; set; }

    public IActionResult OnGet(long id)
    {
        UpdateCategoryArticle = ArticleCategoryApplication.GetUpdateCategoryArticle(id);
        RequestHeaders? typedHeaders =
            HttpContext.Request.GetTypedHeaders();

        string? httpReferer =
            typedHeaders?.Referer?.AbsoluteUri;
        if (UpdateCategoryArticle == null)
        {
            if (httpReferer == null)
                return RedirectToPage("/Index");
            return RedirectToPage(httpReferer);
        }

        return Page();
    }


    public RedirectToPageResult OnPost()
    {
        ArticleCategoryApplication.Update(UpdateCategoryArticle);
        return RedirectToPage("./List");
    }
}