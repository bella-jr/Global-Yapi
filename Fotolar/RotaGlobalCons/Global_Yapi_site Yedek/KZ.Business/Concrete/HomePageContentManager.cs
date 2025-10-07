using KZ.Business.Abstract;
using KZ.DataAccess.Abstract;
using KZ.Entity.Models.Data;

namespace KZ.Business.Concrete
{
    public class HomePageContentManager : IHomePageContentService
    {
        private IHomePageContentDal _homePageContentDal;

        public HomePageContentManager(IHomePageContentDal homePageContentDal)
        {
            _homePageContentDal = homePageContentDal;
        }

        public HomePageContent Get(byte languageId)
        {
            return _homePageContentDal.Get(x => x.LanguageId == languageId);
        }

        public void Update(HomePageContent homePageContent)
        {
            _homePageContentDal.Update(homePageContent);
        }
    }
}
