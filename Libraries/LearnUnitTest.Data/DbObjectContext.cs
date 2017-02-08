using LearnUnitTest.Core.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnUnitTest.Data
{
    public class DbObjectContext : DbContext, IDbContext
    {
        static DbObjectContext()
        {
            Database.SetInitializer<DbObjectContext>(null);
        }

        public DbObjectContext() : this("LearnUnitTestConnection") { }

        public DbObjectContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {
            Database.Log = log => Debug.WriteLine(log);
        }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity
        {
            return base.Set<TEntity>();
        }
    }
}
