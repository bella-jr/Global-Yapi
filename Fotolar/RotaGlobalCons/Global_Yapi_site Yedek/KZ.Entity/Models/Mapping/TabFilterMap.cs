using System.Data.Entity.ModelConfiguration;
using KZ.Entity.Models.Data;

namespace KZ.Entity.Models.Mapping
{
    public class TabFilterMap : EntityTypeConfiguration<TabFilter>
    {
        public TabFilterMap()
        {
            HasMany(x => x.TabFilterProducts)
                .WithRequired(x => x.TabFilter)
                .HasForeignKey(x => x.TabFilterId)
                .WillCascadeOnDelete(true);
        }
    }
}
