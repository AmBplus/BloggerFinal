using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using P.Application.Contracts.Article;

namespace MasterArticleBloger.Areas.Adminstrator.Pages.ArticleManagement;

public class IndexModel : PageModel
{
    public IndexModel(IArticleApplication articleApplication)
    {
        ArticleApplication = articleApplication;
    }

    [BindProperty] public long Id { get; set; }
    private IArticleApplication ArticleApplication { get; set; }

    //public IEnumerable<ArticleViewModel> ArtileList { get; set; }
    public List<ArticleViewModel> ArtileList { get; set; }

    public void OnGet()
    {
        //    ArtileList = ArticleApplication.List();
        ArtileList = ArticleApplication.GetListOfArticleViewModel();
    }

    public RedirectToPageResult OnPostReStatus()
    {
        ArticleApplication.ReStatus(Id);
        return RedirectToPage("./Index");
    }
}