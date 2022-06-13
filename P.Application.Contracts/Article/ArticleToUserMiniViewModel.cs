namespace P.Application.Contracts.Article;

public class ArticleToUserMiniViewModel
{
    public long Id { get; set; }
    public string Title { get; set; }
    public string ArticleCategory { get; set; }
    public string CreationDate { get; set; }
    public string Image { get; set; }
    public string ShortDescription { get; set; }
    public long Count { get; set; }
}