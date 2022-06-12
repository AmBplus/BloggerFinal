namespace P.Domain.ArticleAgg;

public class ArticleBaseModel
{
    public long Id { get; set; }
    public string Title { get; set; }
    public string ArticleCategory { get; set; }
    public bool IsDeleted { get; set; }
    public string CreationDate { get; set; }
}