namespace _01_Framework.Domain;

public class BaseModel<T>
{
    public T Id { get; private set; }
    public DateTime CreationDate { get; }

    protected BaseModel()
    {
        CreationDate = DateTime.Now;
    }
}