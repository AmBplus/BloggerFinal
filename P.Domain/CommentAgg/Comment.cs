using P.Domain.ArticleAgg;

namespace P.Domain.CommentAgg;

public class Comment
{
    public long Id { get; private set; }
    public string Name { get; private set; }
    public string Email { get; private set; }
    public string Message { get; private set; }
    public byte Status { get; private set; }
    public DateTime CreationDate { get; private set; }
    public long ArticleId { get; private set; }
    public Article Article { get;private set; }

    public Comment(string name, string email, string message, long articleId)
    {
        Name = name;
        Email = email;
        Message = message;
        ArticleId = articleId;
        CreationDate = DateTime.Now;
        Status = Statuses.NotDefined ;
    }
}