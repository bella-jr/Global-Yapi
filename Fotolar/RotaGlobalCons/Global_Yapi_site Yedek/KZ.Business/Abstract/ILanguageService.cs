using System.Collections.Generic;
using KZ.Entity.Models.Data;

namespace KZ.Business.Abstract
{
    public interface ILanguageService
    {
        List<Language> GetAll();
    }
}
