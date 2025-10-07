using System.Collections.Generic;
using KZ.Business.Abstract;
using KZ.DataAccess.Abstract;
using KZ.Entity.Models.Data;

namespace KZ.Business.Concrete
{
    public class LanguageManager : ILanguageService
    {
        private ILanguageDal _languageDal;

        public LanguageManager(ILanguageDal languageDal)
        {
            _languageDal = languageDal;
        }

        public List<Language> GetAll()
        {
            return _languageDal.GetList();
        }
    }
}
