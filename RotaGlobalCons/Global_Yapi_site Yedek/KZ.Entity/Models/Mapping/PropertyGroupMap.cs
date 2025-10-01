using System.Data.Entity.ModelConfiguration;
using KZ.Entity.Models.Data;

namespace KZ.Entity.Models.Mapping
{
    public class PropertyGroupMap : EntityTypeConfiguration<PropertyGroup>
    {
        public PropertyGroupMap()
        {
            HasMany(x => x.Properties)
                .WithRequired(x => x.PropertyGroup)
                .HasForeignKey(x => x.PropertyGroupId)
                .WillCascadeOnDelete(true);
        }
    }
}
