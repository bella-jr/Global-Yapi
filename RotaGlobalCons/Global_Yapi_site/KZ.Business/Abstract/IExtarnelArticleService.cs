using System.Collections.Generic;
using KZ.Entity.Models.Data;

namespace KZ.Business.Abstract
{
    public interface IExtarnelArticleService
    {
        void Add(ExternalArticle externalArticle);
        void Update(ExternalArticle externalArticle);
        void Delete(ExternalArticle externalArticle);
        List<ExternalArticle> GetAll(byte languageId);
        ExternalArticle GetById(int id);
        bool GetArticleControl(string link);
        ExternalArticle GetByLink(string link);

        List<ExternalArticle> GetAll_GalleryId(int galleryId, byte languageId);

    }
}
