using System.Collections.Generic;
using KZ.Entity.Models.Data;

namespace KZ.Business.Abstract
{
    public interface ISeoPageService
    {
        void Add(SeoPage seoPage);

        void Update(SeoPage seoPage);

        SeoPage GetById(int id);

        SeoPage GetByUrl(string url);

        List<SeoPage> GetAll();
    }
}
