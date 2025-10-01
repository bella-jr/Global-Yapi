using KZ.Entity.Models.Data.General;

namespace KZ.Entity.Models.Data
{
    public class TabFilterProduct : BaseEntity
    {
        public int ProductId { get; set; }

        public int TabFilterId { get; set; }

        public virtual Product Product { get; set; }
        public virtual TabFilter TabFilter { get; set; }
    }
}
