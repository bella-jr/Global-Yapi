using System.Collections.Generic;
using KZ.Business.Abstract;
using KZ.DataAccess.Abstract;
using KZ.Entity.Models.Data;

namespace KZ.Business.Concrete
{
    public class ExtarnelArticleManager : IExtarnelArticleService
    {
        private IExternalArticleDal _externalArticleDal;

        public ExtarnelArticleManager(IExternalArticleDal externalArticleDal)
        {
            _externalArticleDal = externalArticleDal;
        }

        public void Add(ExternalArticle externalArticle)
        {
            _externalArticleDal.Add(externalArticle);
        }

        public void Update(ExternalArticle externalArticle)
        {
            _externalArticleDal.Update(externalArticle);
        }

        public void Delete(ExternalArticle externalArticle)
        {
            _externalArticleDal.Delete(externalArticle);
        }

        public List<ExternalArticle> GetAll(byte languageId)
        {
            return _externalArticleDal.GetList(x => x.LanguageId == languageId);
        }

        public ExternalArticle GetById(int id)
        {
            return _externalArticleDal.Get(x => x.Id == id);
        }

        public bool GetArticleControl(string link)
        {
            return _externalArticleDal.Get(x => x.Link == link) == null ? true : false;
        }

        public ExternalArticle GetByLink(string link)
        {
            return _externalArticleDal.Get(x => x.Link == link && x.IsStatus);
        }

        public List<ExternalArticle> GetAll_GalleryId(int galleryId, byte languageId)
        {
            return _externalArticleDal.GetList(x => x.GalleryId == galleryId && x.LanguageId == languageId);
        }
    }
}
