using KZ.Entity.Models.Data;

namespace KZ.Business.Abstract
{
    public interface IHomePageContentService
    {
        HomePageContent Get(byte languageId);
        
        void Update(HomePageContent homePageContent);
    }
}
