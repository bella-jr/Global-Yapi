using KZ.Entity.Models.Data;

namespace KZ.Business.Abstract
{
    public interface ISeoUrlRedirectService
    {
        SeoUrlRedirect Get(string oldUrl);
    }
}
