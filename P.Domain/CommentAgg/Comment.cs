using _01_Framework.Domain;
using P.Domain.ArticleAgg;

namespace P.Domain.CommentAgg;

public class Comment : BaseModel<long>
{
    public string Name { get; }
    public string Email { get; }
    public string Message { get; }
    public byte Status { get; private set; }
    public long ArticleId { get; }
    public Article Article { get; private set; }

    protected Comment()
    {
    }

    public Comment(string name, string email, string message, long articleId)
    {
        Name = name;
        Email = email;
        Message = message;
        ArticleId = articleId;
        Status = Statuses.NotDefined;
    }

    public void ChangeStatus(byte status)
    {
        Status = status;
    }
}