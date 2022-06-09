using P.Domain.ArticleCategoryAgg;

namespace P.Domain.ArticleAgg;

public class Article
{
    public Article(string title, string shortDescription, string image, string content, long articleCategoryId)
    {
        Title = title;
        ShortDescription = shortDescription;
        Image = image;
        Content = content;
        ArticleCategoryId = articleCategoryId;
    }

    public long Id { get;}
    public string Title { get;private set; }
    public string ShortDescription { get;private set; }
    public string Image { get; private set; }
    public string Content { get; private set; }
    public DateTime CreationDate { get; private set; }
    public bool IsDeleted { get; private set; }
    public long ArticleCategoryId { get; private set; }
    public  ArticleCategory ArticleCategor { get; set; }  
    public void ChangeState(bool state)
    {
        IsDeleted = state;
    }
}