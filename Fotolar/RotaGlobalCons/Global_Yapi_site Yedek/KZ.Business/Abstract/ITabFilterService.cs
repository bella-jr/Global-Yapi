using System.Collections.Generic;
using KZ.Entity.Models.Data;

namespace KZ.Business.Abstract
{
    public interface ITabFilterService
    {
        void Add(TabFilter tabFilter);
        void Update(TabFilter tabFilter);
        void Delete(TabFilter tabFilter);
        List<TabFilter> GetAll(byte languageId);

        List<TabFilter> GetAll_UI(byte languageId);

        TabFilter GetById(int id);
    }
}
