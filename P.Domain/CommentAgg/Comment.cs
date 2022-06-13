using P.Domain.ArticleAgg;

namespace P.Domain.CommentAgg;

public class Comment
{
    public long Id { get; private set; }
    public string Name { get; }
    public string Email { get; }
    public string Message { get; }
    public byte Status { get; }
    public DateTime CreationDate { get; }
    public long ArticleId { get; }
    public Article Article { get; private set; }

    public Comment(string name, string email, string message, long articleId)
    {
        Name = name;
        Email = email;
        Message = message;
        ArticleId = articleId;
        CreationDate = DateTime.Now;
        Status = Statuses.NotDefined;
    }
}