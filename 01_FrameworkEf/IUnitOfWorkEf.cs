using _01_Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace _01_FrameworkEf;

public class UnitOfWorkEf:IUnitOfWork
{
    private DbContext Context;

    public UnitOfWorkEf(DbContext context)
    {
        Context = context;
    }

    public void CommitTran()
    {
        Context.Database.CommitTransaction();
    }

    public void BeginTran()
    {
        Context.Database.BeginTransaction();
    }

    public void RollBack()
    {
        Context.Database.RollbackTransaction();
    }
}