using LearnUnitTest.Core.Domain;
using System.Data.Entity;

namespace LearnUnitTest.Data
{
    public interface IDbContext
    {
        IDbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity;
    }
}