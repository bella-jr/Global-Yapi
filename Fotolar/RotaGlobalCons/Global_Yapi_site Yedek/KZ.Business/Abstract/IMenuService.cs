using System.Collections.Generic;
using KZ.Entity.Models.Data;

namespace KZ.Business.Abstract
{
    public interface IMenuService
    {
        void Add(Menu menu);
        void Update(Menu menu);
        void Delete(Menu menu);
        List<Menu> GetAll(byte languageId);

        List<Menu> GetAllType(byte typeId, byte languageId);

        List<Menu> GetAll_NoExternal(byte languageId);

        List<Menu> GetAll_MainList(byte languageId);

        List<Menu> GetAll_SubList(int mainMenuId);

        List<Menu> GetAll_FooterList(byte languageId);

        List<Menu> GetAll_FooterList2(byte languageId);

        List<Menu> GetAll_SubFooterList(int mainMenuId);


        List<Menu> GetAll_UIMenuList(int mainMenuId, byte languageId);

        List<Menu> GetAll_HomeMenuList(byte languageId);

        List<Menu> GetAll_HomeMenuList2(byte languageId);

        List<Menu> GetAll_HomeProductList(byte languageId);
        List<Menu> GetAll_HomeMenuList(int mainMenuId, byte languageId);

        Menu GetById(int id);

        List<Menu> GetAll_AccordionList(byte languageId);

        List<Menu> GetAll_SubAccordionList(int mainMenuId);

        List<Menu> GetAll_SidebarList(byte languageId);

        List<Menu> GetAll_SubSidebarList(int mainMenuId);

        List<Menu> GetAll_SubMegaMenuList(byte languageId);

        List<Menu> GetAll_HeaderTopMenuList(byte languageId);


        List<Menu> GetAll_LeftMenuList(byte languageId);

        List<Menu> GetAll_RightMenuList(byte languageId);

    }
}
