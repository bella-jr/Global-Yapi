using KZ.Entity.Models.Data;
using System.Data.Entity.ModelConfiguration;

namespace KZ.Entity.Models.Mapping
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            HasMany(x => x.LoginLogs)
                .WithRequired(x => x.User)
                .HasForeignKey(x => x.UserId)
                .WillCascadeOnDelete(true);
        }
    }
}
