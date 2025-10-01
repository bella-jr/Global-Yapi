using KZ.Business.Abstract;
using System.Collections.Generic;
using KZ.Entity.Models.Data;
using KZ.DataAccess.Abstract;
using System.Linq;

namespace KZ.Business.Concrete
{
    public class MostSearchedManager : IMostSearchedService
    {
        private IMostSearchedDal _mostSearchedDal;
        public MostSearchedManager(IMostSearchedDal MostSearchedDal)
        {
            _mostSearchedDal = MostSearchedDal;
        }

        public void Add(MostSearched mostSearched)
        {
            _mostSearchedDal.Add(mostSearched);
        }

        public void Delete(MostSearched mostSearched)
        {
            _mostSearchedDal.Delete(mostSearched);
        }

        public MostSearched GetById(int id)
        {
            return _mostSearchedDal.Get(x => x.Id == id);
        }

        public List<MostSearched> GetList()
        {
            return _mostSearchedDal.GetList().OrderBy(x=> x.SequenceNumber).ToList();
        }

        public List<MostSearched> GetList_UI()
        {
            return _mostSearchedDal.GetList(x=> x.IsView).OrderBy(x => x.SequenceNumber).ToList();

        }

        public void Update(MostSearched mostSearched)
        {
            _mostSearchedDal.Update(mostSearched);
        }
    }
}
