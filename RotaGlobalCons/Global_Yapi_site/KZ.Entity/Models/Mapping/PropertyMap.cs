using System.Data.Entity.ModelConfiguration;
using KZ.Entity.Models.Data;

namespace KZ.Entity.Models.Mapping
{
    public class PropertyMap : EntityTypeConfiguration<Property>
    {
        public PropertyMap()
        {
            HasMany(x => x.ProductProperties)
                .WithRequired(x => x.Property)
                .HasForeignKey(x => x.PropertyId)
                .WillCascadeOnDelete(true);
        }
    }
}
