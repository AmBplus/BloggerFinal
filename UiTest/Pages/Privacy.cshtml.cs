using Microsoft.AspNetCore.Mvc.RazorPages;
using P.Infrastructure.EfCore.Repository.ArticleCategoryRepository;

namespace UiTest.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly ArticleCategoryRepository articlecategory;

        public PrivacyModel(ArticleCategoryRepository articlecategory)
        {
            this.articlecategory = articlecategory;
        }

        public void OnGet()
        {
        }
    }
}