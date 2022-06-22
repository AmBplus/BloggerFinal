namespace _01_Framework.Infrastructure;

public interface IUnitOfWork
{
    void CommitTran();
    void BeginTran();
    void RollBack();
} //