using KZ.Entity.Models.Data.General;

namespace KZ.Entity.Models.Data
{
    public class ProductMenu : BaseEntity
    {
        public int ProductId { get; set; }

        public int MenuId { get; set; }

        public virtual Product Product { get; set; }

        public int SequenceNumber { get; set; }
    }
}
