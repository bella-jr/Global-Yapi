using System.Collections.Generic;
using System.Linq;
using KZ.Business.Abstract;
using KZ.DataAccess.Abstract;
using KZ.Entity.Models.Data;

namespace KZ.Business.Concrete
{
    public class TabFilterManager : ITabFilterService
    {
        private ITabFilterDal _tabFilterDal;

        public TabFilterManager(ITabFilterDal tabFilterDal)
        {
            _tabFilterDal = tabFilterDal;
        }

        public void Add(TabFilter tabFilter)
        {
            _tabFilterDal.Add(tabFilter);
        }

        public void Update(TabFilter tabFilter)
        {
            _tabFilterDal.Update(tabFilter);
        }

        public void Delete(TabFilter tabFilter)
        {
            _tabFilterDal.Delete(tabFilter);
        }

        public List<TabFilter> GetAll(byte languageId)
        {
            return _tabFilterDal.GetList(x => x.LanguageId == languageId).OrderBy(x => x.SequenceNumber).ToList();
        }

        public List<TabFilter> GetAll_UI(byte languageId)
        {
            return _tabFilterDal.GetList(x => x.LanguageId == languageId && x.IsView).OrderBy(x => x.SequenceNumber).ToList();
        }

        public TabFilter GetById(int id)
        {
            return _tabFilterDal.Get(x => x.Id == id);
        }
    }
}
