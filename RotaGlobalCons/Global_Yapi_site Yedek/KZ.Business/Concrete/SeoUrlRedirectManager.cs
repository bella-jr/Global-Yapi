using KZ.Business.Abstract;
using KZ.DataAccess.Abstract;
using KZ.Entity.Models.Data;

namespace KZ.Business.Concrete
{
    public class SeoUrlRedirectManager : ISeoUrlRedirectService
    {
        private ISeoUrlRedirectDal _seoUrlRedirectDal;

        public SeoUrlRedirectManager(ISeoUrlRedirectDal seoUrlRedirectDal)
        {
            _seoUrlRedirectDal = seoUrlRedirectDal;
        }

        public SeoUrlRedirect Get(string oldUrl)
        {
            return _seoUrlRedirectDal.Get(x => x.OldUrl == oldUrl);
        }
    }
}
