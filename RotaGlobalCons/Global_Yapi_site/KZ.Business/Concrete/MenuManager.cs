using System.Collections.Generic;
using System.Linq;
using KZ.Business.Abstract;
using KZ.DataAccess.Abstract;
using KZ.Entity.Models.Data;

namespace KZ.Business.Concrete
{
    public class MenuManager : IMenuService

    {
        private IMenuDal _menuDal;

        public MenuManager(IMenuDal menuDal)
        {
            _menuDal = menuDal;
        }

        public void Add(Menu menu)
        {
            _menuDal.Add(menu);
        }

        public void Update(Menu menu)
        {
            _menuDal.Update(menu);
        }

        public void Delete(Menu menu)
        {
            _menuDal.Delete(menu);
        }

        public List<Menu> GetAll(byte languageId)
        {
            return _menuDal.GetList(x => x.LanguageId == languageId).OrderBy(x => x.SequenceNumber).ToList();
        }

        public List<Menu> GetAllType(byte typeId, byte languageId)
        {
            return _menuDal.GetList(x => x.TypeId == typeId && x.LanguageId == languageId);
        }

        public List<Menu> GetAll_NoExternal(byte languageId)
        {
            return _menuDal.GetList(x => x.IsExternal == false && x.LanguageId == languageId).OrderBy(x => x.SequenceNumber).ToList();
        }

        public List<Menu> GetAll_MainList(byte languageId)
        {
            return _menuDal.GetList(x => x.MainMenuId == 3 && x.LanguageId == languageId).OrderBy(x => x.SequenceNumber).ToList();
        }

        public List<Menu> GetAll_SubList(int mainMenuId)
        {
            return _menuDal.GetList(x => x.MainMenuId == mainMenuId).OrderBy(x => x.SequenceNumber).ToList();
        }

        public List<Menu> GetAll_FooterList(byte languageId)
        {
            return _menuDal.GetList(x => x.IsFooter && x.LanguageId == languageId).OrderBy(x => x.FooterSequenceNumber).ToList();
        }

        public List<Menu> GetAll_UIMenuList(int mainMenuId, byte languageId)
        {
            return _menuDal.GetList(x => x.MainMenuId == mainMenuId && x.IsHeader && x.LanguageId == languageId).OrderBy(x => x.SequenceNumber).ToList();
        }

        public List<Menu> GetAll_HomeMenuList(byte languageId)
        {
            return _menuDal.GetList(x => x.IsHome && x.LanguageId == languageId).OrderBy(x => x.HomeSequenceNumber).ToList();
        }

        public List<Menu> GetAll_HomeProductList(byte languageId)
        {
            return _menuDal.GetList(x => x.IsProduct && x.LanguageId == languageId).OrderBy(x => x.HomeSequenceNumber).ToList();
        }

        public Menu GetById(int id)
        {
            return _menuDal.Get(x => x.Id == id);
        }

        public List<Menu> GetAll_AccordionList(byte languageId)
        {
            return _menuDal.GetList(x => x.IsHeaderAccordion && x.IsHeaderMainAccordion && x.LanguageId == languageId).OrderBy(x => x.AccordionSequenceNumber).ToList();
        }

        public List<Menu> GetAll_SubAccordionList(int mainMenuId)
        {
            return _menuDal.GetList(x => x.IsHeaderAccordion && x.MainMenuId == mainMenuId).OrderBy(x => x.SequenceNumber).ToList();
        }

        public List<Menu> GetAll_SidebarList(byte languageId)
        {
            return _menuDal.GetList(x => x.IsSidebar && x.LanguageId == languageId).OrderBy(x => x.SequenceNumber).ToList();
        }

        public List<Menu> GetAll_SubSidebarList(int mainMenuId)
        {
            return _menuDal.GetList(x => x.IsSidebar && x.MainMenuId == mainMenuId);
        }

        public List<Menu> GetAll_SubMegaMenuList(byte languageId)
        {
            return _menuDal.GetList(x => x.IsMegaSubView && x.LanguageId == languageId);
        }

        public List<Menu> GetAll_SubFooterList(int mainMenuId)
        {
            return _menuDal.GetList(x => x.IsFooter && x.MainMenuId == mainMenuId).OrderBy(x => x.SequenceNumber).ToList();
        }

        public List<Menu> GetAll_HeaderTopMenuList(byte languageId)
        {
            return _menuDal.GetList(x => x.LanguageId == languageId && x.IsHeaderTop).OrderBy(x => x.HeaderTopSequenceNumber).ToList();
        }

        public List<Menu> GetAll_HomeMenuList(int mainMenuId, byte languageId)
        {
            return _menuDal.GetList(x => x.IsHome && x.LanguageId == languageId && x.MainMenuId == mainMenuId).OrderBy(x => x.SequenceNumber).ToList();

        }

        public List<Menu> GetAll_HomeMenuList2(byte languageId)
        {
            return _menuDal.GetList(x => x.IsHome2 && x.LanguageId == languageId).OrderBy(x => x.HomeSequenceNumber2).ToList();
        }

        public List<Menu> GetAll_LeftMenuList(byte languageId)
        {
            return _menuDal.GetList(x => x.LanguageId == languageId && x.IsLeftView && x.MainMenuId == 0).OrderBy(x => x.HeaderLeftSequenceNumber).ToList();
        }

        public List<Menu> GetAll_RightMenuList(byte languageId)
        {
            return _menuDal.GetList(x => x.LanguageId == languageId && x.IsRightView && x.MainMenuId == 0).OrderBy(x => x.HeaderRightSequenceNumber).ToList();
        }

        public List<Menu> GetAll_FooterList2(byte languageId)
        {
            return _menuDal.GetList(x => x.IsFooter2 && x.LanguageId == languageId);
        }
    }
}
