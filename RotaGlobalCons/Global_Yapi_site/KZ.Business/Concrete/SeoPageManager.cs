using System.Collections.Generic;
using KZ.Business.Abstract;
using KZ.DataAccess.Abstract;
using KZ.Entity.Models.Data;

namespace KZ.Business.Concrete
{
    public class SeoPageManager : ISeoPageService
    {
        private ISeoPageDal _seoPageDal;

        public SeoPageManager(ISeoPageDal seoPageDal)
        {
            _seoPageDal = seoPageDal;
        }

        public void Add(SeoPage seoPage)
        {
            _seoPageDal.Add(seoPage);
        }

        public void Update(SeoPage seoPage)
        {
            _seoPageDal.Update(seoPage);
        }

        public SeoPage GetById(int id)
        {
            return _seoPageDal.Get(x => x.Id == id);
        }

        public SeoPage GetByUrl(string url)
        {
            return _seoPageDal.Get(x => x.Url == url);
        }

        public List<SeoPage> GetAll()
        {
            return _seoPageDal.GetList();
        }
    }
}
