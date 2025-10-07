using KZ.Entity.Models.Data.General;

namespace KZ.Entity.Models.Data
{
    public class SeoUrlRedirect : BaseEntity
    {
        public string OldUrl { get; set; }

        public string NewUrl { get; set; }
    }
}
