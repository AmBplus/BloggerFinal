using P.Domain.ArticleAgg;

namespace P.Application.Contracts.Article
{
    public class ArticleViewModel : IArticleViewModel
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string ArticleCategory { get; set; }
        public bool IsDeleted { get; set; }
        public string CreationDate { get; set; }
    }
}
