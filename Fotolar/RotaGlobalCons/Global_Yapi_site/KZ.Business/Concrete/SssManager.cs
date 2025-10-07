using KZ.Business.Abstract;
using System.Collections.Generic;
using KZ.Entity.Models.Data;
using KZ.DataAccess.Abstract;

namespace KZ.Business.Concrete
{
    public class SssManager : ISssService
    {
        private ISssDal _sssDal;
        public SssManager(ISssDal SssDal)
        {
            _sssDal = SssDal;
        }

        public void Add(SSS sss)
        {
            _sssDal.Add(sss);
        }

        public void Delete(SSS sss)
        {
            _sssDal.Delete(sss);
        }

        public SSS GetById(int id)
        {
            return _sssDal.Get(x => x.Id == id);
        }

        public List<SSS> GetList(int languageId)
        {
            return _sssDal.GetList(x=> x.LanguageId == languageId);
        }

        public List<SSS> GetList_Home(int languageId)
        {
            return _sssDal.GetList(x => x.IsHome && x.IsView && x.LanguageId == languageId);
        }

        public List<SSS> GetList_UI(int languageId)
        {
            return _sssDal.GetList(x => x.IsView && x.LanguageId == languageId);
        }

        public void Update(SSS sss)
        {
            _sssDal.Update(sss);
        }
    }
}
