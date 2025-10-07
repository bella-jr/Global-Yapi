using System.Data.Entity.ModelConfiguration;
using KZ.Entity.Models.Data;

namespace KZ.Entity.Models.Mapping
{
    public class GalleryMap : EntityTypeConfiguration<Gallery>
    {
        public GalleryMap()
        {
            HasMany(x => x.GalleryImages)
                .WithRequired(x => x.Gallery)
                .HasForeignKey(x => x.GalleryId)
                .WillCascadeOnDelete(true);

        }
    }
}
