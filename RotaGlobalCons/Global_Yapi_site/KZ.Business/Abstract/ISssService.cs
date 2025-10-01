using KZ.Entity.Models.Data;
using System.Collections.Generic;

namespace KZ.Business.Abstract
{
    public interface ISssService
    {
        void Add(SSS sss);

        void Update(SSS sss);

        void Delete(SSS sss);

        SSS GetById(int id);

        List<SSS> GetList(int languageId);

        List<SSS> GetList_UI(int languageId);

        List<SSS> GetList_Home(int languageId);
    }
}
