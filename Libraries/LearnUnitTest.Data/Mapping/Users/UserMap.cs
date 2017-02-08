using LearnUnitTest.Core.Domain.Users;
using System.Data.Entity.ModelConfiguration;

namespace LearnUnitTest.Data.Mapping.Users
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            ToTable("Users");

            HasKey(t => t.Id);
        }
    }
}
