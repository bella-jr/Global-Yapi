using System.Collections.Generic;
using KZ.Entity.Models.Data;

namespace KZ.Business.Abstract
{
    public interface IMostSearchedService
    {
        void Add(MostSearched mostSearched);

        void Update(MostSearched mostSearched);

        void Delete(MostSearched mostSearched);

        MostSearched GetById(int id);

        List<MostSearched> GetList();

        List<MostSearched> GetList_UI();
    }
}
