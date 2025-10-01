using System;
using System.Collections.Generic;
using KZ.Business.Abstract;
using KZ.Business.DependencyResolvers.Ninject;
using KZ.Core;
using KZ.Entity.Enums;
using KZ.Entity.Models.Data;
using KZ.WebUI.Tool.Abstract;

namespace KZ.WebUI.Tool.Concrete
{
    public class MenuToolManager : IMenuToolService
    {
        private IMenuService _menuService;

        public MenuToolManager()
        {
            _menuService = InstanceFactory.GetInstance<IMenuService>();
        }

        private string menuText = "", sidebarMenuText = "", accordionMenuText = "", mobileMenuText = "", footerMenuText = "", footerMenuText2 = "", headetTopMenuText = "", footerSubMenuText = "", leftMenuText = "", rightMenuText = "";

        //Footer menülerini listeleme işlemini gerçekleştirmektedir.
        public string FooterMenuList(byte languageId)
        {
            //if (HttpContext.Current.Application["footerMenu"] == null)
            //{
            string link = "", target = "";
            foreach (var item in _menuService.GetAll_FooterList(languageId))
            {
                if (item.IsExternal)
                    link = item.Link;
                else
                {
                    if (item.IsSubMenuListView)
                    {
                        link = String.Format("/{0}{1}/{2}/{3}", Resources.value.url_Folder, Resources.value.url_Kategoriler, Tools.UrlSeo(item.Name), item.Id.ToString());
                    }
                    else
                    {
                        link = item.TypeId == (byte)MenuType.Menu
                      ? String.Format("/{0}{1}/{2}/{3}", Resources.value.url_Folder, Resources.value.url_Menu, Tools.UrlSeo(item.Name), item.Id.ToString())
                      : String.Format("/{0}{1}/{2}/{3}", Resources.value.url_Folder, Resources.value.url_Kategori, Tools.UrlSeo(item.Name), item.Id.ToString());
                    }
                }

                target = item.IsTarget ? "target=\"_blank\"" : "";

                footerMenuText += "<li><a title=\"" + item.Name + "\" " + target + " href=\"" + link + "\">" + item.Name + "</a>";
                //FooterSubMenuList(item.Id);
                footerMenuText += "</li>";
            }
            //    HttpContext.Current.Application["footerMenu"] = footerMenuText;

            //    return (string)HttpContext.Current.Application["footerMenu"];
            //}
            //else
            //    return (string)HttpContext.Current.Application["footerMenu"];
            return footerMenuText;
        }

        public string FooterMenuList2(byte languageId)
        {
            //if (HttpContext.Current.Application["footerMenu"] == null)
            //{
            string link = "", target = "";
            foreach (var item in _menuService.GetAll_FooterList2(languageId))
            {
                if (item.IsExternal)
                    link = item.Link;
                else
                {
                    if (item.IsSubMenuListView)
                    {
                        link = String.Format("/{0}{1}/{2}/{3}", Resources.value.url_Folder, Resources.value.url_Kategoriler, Tools.UrlSeo(item.Name), item.Id.ToString());
                    }
                    else
                    {
                        link = item.TypeId == (byte)MenuType.Menu
                      ? String.Format("/{0}{1}/{2}/{3}", Resources.value.url_Folder, Resources.value.url_Menu, Tools.UrlSeo(item.Name), item.Id.ToString())
                      : String.Format("/{0}{1}/{2}/{3}", Resources.value.url_Folder, Resources.value.url_Kategori, Tools.UrlSeo(item.Name), item.Id.ToString());
                    }
                }

                target = item.IsTarget ? "target=\"_blank\"" : "";

                footerMenuText2 += "<li><a title=\"" + item.Name + "\" " + target + " href=\"" + link + "\">" + item.Name + "</a>";
                //FooterSubMenuList(item.Id);
                footerMenuText2 += "</li>";
            }
            //    HttpContext.Current.Application["footerMenu"] = footerMenuText;

            //    return (string)HttpContext.Current.Application["footerMenu"];
            //}
            //else
            //    return (string)HttpContext.Current.Application["footerMenu"];
            return footerMenuText2;
        }

        private string FooterSubMenuList(int id)
        {
            //if (HttpContext.Current.Application["footerSubMenu"] == null)
            //{
            string urlLink = "", target = "";
            var menu = _menuService.GetAll_SubList(id);
            footerMenuText += "<ul class=\"footer-list\">";
            foreach (var item in menu)
            {
                if (item.IsExternal)
                    urlLink = item.Link;
                else
                {
                    if (item.IsSubMenuListView)
                    {
                        urlLink = String.Format("/{0}{1}/{2}/{3}", Resources.value.url_Folder, Resources.value.url_Kategoriler, Tools.UrlSeo(item.Name), item.Id.ToString());
                    }
                    else
                    {
                        urlLink = item.TypeId == (byte)MenuType.Menu
                      ? String.Format("/{0}{1}/{2}/{3}", Resources.value.url_Folder, Resources.value.url_Menu, Tools.UrlSeo(item.Name), item.Id.ToString())
                      : String.Format("/{0}{1}/{2}/{3}", Resources.value.url_Folder, Resources.value.url_Kategori, Tools.UrlSeo(item.Name), item.Id.ToString());
                    }
                }

                target = item.IsTarget ? "target=\"_blank\"" : "";

                footerMenuText += "<li><a title=\"" + item.Name + "\" " + target + " href=\"" + urlLink + "\">" + item.Name + "</a>";
                //FooterSubMenuList(item.Id);
                footerMenuText += "</li>";
            }
            footerMenuText += "</ul>";

            //    HttpContext.Current.Application["footerSubMenu"] = footerSubMenuText;

            //    return (string)HttpContext.Current.Application["footerSubMenu"];
            //}
            //else
            //    return (string)HttpContext.Current.Application["footerSubMenu"];
            return footerMenuText;
        }


        //Header menülerini listeleme işlemini gerçekleştirmektedir.
        public string Header_GenerateMenu(byte languageId)
        {
            //if (HttpContext.Current.Application["headerMenu"] == null)
            //{
            int flag = 0;
            string link = "", target = "", liClass = "", icon = "";

            var mainMenu = _menuService.GetAll_UIMenuList(0, languageId);

            foreach (var item in mainMenu)
            {
                //Mega menü şeklinde listeleme islemini gerçekleştirmektedir.
                if (item.IsMega)
                {
                    var subMenus = _menuService.GetAll_SubMegaMenuList(languageId);

                    string mainCategory = "", subCategory = "";

                    if (item.IsExternal)
                        link = item.Link;
                    else
                    {
                        if (item.IsSubMenuListView)
                        {
                            link = String.Format("/{0}{1}/{2}/{3}", Resources.value.url_Folder, Resources.value.url_Kategoriler, Tools.UrlSeo(item.Name), item.Id.ToString());
                        }
                        else
                        {
                            link = item.TypeId == (byte)MenuType.Menu
                          ? String.Format("/{0}{1}/{2}/{3}", Resources.value.url_Folder, Resources.value.url_Menu, Tools.UrlSeo(item.Name), item.Id.ToString())
                          : String.Format("/{0}{1}/{2}/{3}", Resources.value.url_Folder, Resources.value.url_Kategori, Tools.UrlSeo(item.Name), item.Id.ToString());
                        }
                    }

                    mainCategory += "<li class=\"megamenu-holder\"><a title=\"" + item.Name + "\" " + target + " href=\"" + link + "\">" + item.Name + " <i class=\"ion-chevron-down\"></i></a><ul class=\"umino-megamenu\">";

                    foreach (var item2 in subMenus)
                    {
                        if (item2.IsExternal)
                            link = item2.Link;
                        else
                        {
                            if (item2.IsSubMenuListView)
                            {
                                link = String.Format("/{0}{1}/{2}/{3}", Resources.value.url_Folder, Resources.value.url_Kategoriler, Tools.UrlSeo(item2.Name), item2.Id.ToString());
                            }
                            else
                            {
                                link = item.TypeId == (byte)MenuType.Menu
                              ? String.Format("/{0}{1}/{2}/{3}", Resources.value.url_Folder, Resources.value.url_Menu, Tools.UrlSeo(item2.Name), item2.Id.ToString())
                              : String.Format("/{0}{1}/{2}/{3}", Resources.value.url_Folder, Resources.value.url_Kategori, Tools.UrlSeo(item2.Name), item2.Id.ToString());
                            }
                        }

                        target = item2.IsTarget ? "target=\"_blank\"" : "";


                        flag += 1;
                        subCategory += "<li><a title=\"" + item.Name + "\" " + target + " href=\"" + link + "\">" + item2.Name + "</a></li>";
                        if (flag == 4)
                        {
                            subCategory += "</ul></li>";
                            subCategory += "<li><ul class=\"p-0-5\">";

                            flag = 0;
                        }
                    }


                    menuText += mainCategory + "<li><ul class=\"p-0-5\">" + subCategory + "</ul></li></ul></li>";
                    //menuText = menuText.Replace("<div class=\"col-md-6\"><ul></ul></div></div></div></li>", "");
                }
                else
                {
                    var subMenu = _menuService.GetAll_UIMenuList(item.Id, languageId);

                    if (item.IsExternal)
                        link = item.Link;
                    else
                    {
                        if (item.IsSubMenuListView)
                        {
                            link = String.Format("/{0}{1}/{2}/{3}", Resources.value.url_Folder, Resources.value.url_Kategoriler, Tools.UrlSeo(item.Name), item.Id.ToString());
                        }
                        else
                        {
                            link = item.TypeId == (byte)MenuType.Menu
                          ? String.Format("/{0}{1}/{2}/{3}", Resources.value.url_Folder, Resources.value.url_Menu, Tools.UrlSeo(item.Name), item.Id.ToString())
                          : String.Format("/{0}{1}/{2}/{3}", Resources.value.url_Folder, Resources.value.url_Kategori, Tools.UrlSeo(item.Name), item.Id.ToString());
                        }
                    }

                    target = item.IsTarget ? "target=\"_blank\"" : "";

                    if (subMenu.Count > 0)
                    {
                        liClass = "dropdown";
                        menuText += String.Format(@"<li class=""{0}""><a title=""{3}"" {1} href=""{2}"">{3}</a>", liClass, target, link, item.Name);
                    }
                    else
                    {
                        liClass = "";
                        menuText += String.Format(@"<li class=""{0}""><a title=""{3}"" {0} href=""{2}"">{3}</a>", liClass, target, link, item.Name);
                    }


                    Header_SubMenuGetList(item.Id, languageId);
                    menuText += " </li>";
                }

            }
            return menuText;
            //    HttpContext.Current.Application["headerMenu"] = menuText;
            //    return (string)HttpContext.Current.Application["headerMenu"];
            //}
            //else
            //    return (string)HttpContext.Current.Application["headerMenu"];
        }

        //Header ana menülerinin alt menülerini listeleme işlemini gerçekleştirmektedir.
        private void Header_SubMenuGetList(int mainMenuId, byte languageId)
        {
            var menu = _menuService.GetAll_UIMenuList(mainMenuId, languageId);
            if (menu.Count == 0) { }
            else
            {
                menuText += "<ul>";
                string link = "", target = "", liClass = "";
                foreach (var item in menu)
                {
                    var subMenu = _menuService.GetAll_UIMenuList(item.Id, languageId);

                    if (item.IsExternal)
                        link = item.Link;
                    else
                    {
                        if (item.IsSubMenuListView)
                        {
                            link = String.Format("/{0}{1}/{2}/{3}", Resources.value.url_Folder, Resources.value.url_Kategoriler, Tools.UrlSeo(item.Name), item.Id.ToString());
                        }
                        else
                        {
                            link = item.TypeId == (byte)MenuType.Menu
                          ? String.Format("/{0}{1}/{2}/{3}", Resources.value.url_Folder, Resources.value.url_Menu, Tools.UrlSeo(item.Name), item.Id.ToString())
                          : String.Format("/{0}{1}/{2}/{3}", Resources.value.url_Folder, Resources.value.url_Kategori, Tools.UrlSeo(item.Name), item.Id.ToString());
                        }
                    }

                    target = item.IsTarget ? "target=\"_blank\"" : "";

                    liClass = subMenu.Count > 0 ? "class=\"elementskit-dropdown-has\"" : "";

                    if (subMenu.Count > 0)
                    {
                        menuText += "<li " + liClass + "><a title=\"" + item.Name + "\" " + target + " href=\"" + link + "\">" + item.Name + "</a>";
                        Header_SubMenuGetList(item.Id, languageId);
                        menuText += "</li>";
                    }
                    else
                    {
                        menuText += "<li " + liClass + "><a title=\"" + item.Name + "\" " + target + " href=\"" + link + "\">" + item.Name + "</a>";
                        Header_SubMenuGetList(item.Id, languageId);
                        menuText += "</li>";
                    }

                }
                menuText += "</ul>";
            }
        }


        //Header kısmındaki accordion menülerini listeleme işlemini gerçekleştirmektedir.
        public string Header_GenerateAccordionMenu(byte languageId)
        {
            string link = "", target = "", dropdownClassLi = "";

            var mainMenu = _menuService.GetAll_AccordionList(languageId);

            foreach (var item in mainMenu)
            {
                var subMenus = _menuService.GetAll_SubAccordionList(item.Id);

                if (item.IsExternal)
                    link = item.Link;
                else
                {
                    if (item.IsSubMenuListView)
                    {
                        link = String.Format("/{0}{1}/{2}/{3}", Resources.value.url_Folder, Resources.value.url_Kategoriler, Tools.UrlSeo(item.Name), item.Id.ToString());
                    }
                    else
                    {
                        link = item.TypeId == (byte)MenuType.Menu
                      ? String.Format("/{0}{1}/{2}/{3}", Resources.value.url_Folder, Resources.value.url_Menu, Tools.UrlSeo(item.Name), item.Id.ToString())
                      : String.Format("/{0}{1}/{2}/{3}", Resources.value.url_Folder, Resources.value.url_Kategori, Tools.UrlSeo(item.Name), item.Id.ToString());
                    }
                }

                target = item.IsTarget ? "target=\"_blank\"" : "";

                dropdownClassLi = subMenus.Count > 0 ? "class=\"right-menu\"" : "";

                accordionMenuText += "<li " + dropdownClassLi + "><a title=\"" + item.Name + "\" " + target + " href=\"" + link + "\">" + item.Name + "</a>";
                Header_SubAccordionMenuGetList(subMenus);
                accordionMenuText += "</li>";
            }

            return accordionMenuText;
        }

        private void Header_SubAccordionMenuGetList(List<Menu> subMenus)
        {
            if (subMenus.Count == 0) { }
            else
            {
                accordionMenuText += "<ul class=\"cat-dropdown_menu cat-dropdown_menu-2\">";
                string link = "", target = "";
                foreach (var item in subMenus)
                {
                    if (item.IsExternal)
                        link = item.Link;
                    else
                    {
                        if (item.IsSubMenuListView)
                        {
                            link = String.Format("/{0}{1}/{2}/{3}", Resources.value.url_Folder, Resources.value.url_Kategoriler, Tools.UrlSeo(item.Name), item.Id.ToString());
                        }
                        else
                        {
                            link = item.TypeId == (byte)MenuType.Menu
                          ? String.Format("/{0}{1}/{2}/{3}", Resources.value.url_Folder, Resources.value.url_Menu, Tools.UrlSeo(item.Name), item.Id.ToString())
                          : String.Format("/{0}{1}/{2}/{3}", Resources.value.url_Folder, Resources.value.url_Kategori, Tools.UrlSeo(item.Name), item.Id.ToString());
                        }
                    }

                    target = item.IsTarget ? "target=\"_blank\"" : "";

                    accordionMenuText += "<li><a title=\"" + item.Name + "\" " + target + " href=\"" + link + "\">" + item.Name + "</a>";
                    //Header_SubAccordionMenuGetList(subMenus);
                    accordionMenuText += "</li>";
                }
                accordionMenuText += "</ul>";
            }
        }

        //Header kısmındaki accordion menülerini listeleme işlemini gerçekleştirmektedir.
        public string SidebarMenuList(byte languageId, bool isIcon = false)
        {
            string link = "", target = "", icon = "";
            var menus = _menuService.GetAll_SidebarList(languageId);
            foreach (var item in menus)
            {
                //var subMenus = _menuService.GetAll_SubSidebarList(item.Id);

                if (item.IsExternal)
                    link = item.Link;
                else
                {
                    if (item.IsSubMenuListView)
                    {
                        link = String.Format("/{0}{1}/{2}/{3}", Resources.value.url_Folder, Resources.value.url_Kategoriler, Tools.UrlSeo(item.Name), item.Id.ToString());
                    }
                    else
                    {
                        link = item.TypeId == (byte)MenuType.Menu
                      ? String.Format("/{0}{1}/{2}/{3}", Resources.value.url_Folder, Resources.value.url_Menu, Tools.UrlSeo(item.Name), item.Id.ToString())
                      : String.Format("/{0}{1}/{2}/{3}", Resources.value.url_Folder, Resources.value.url_Kategori, Tools.UrlSeo(item.Name), item.Id.ToString());
                    }
                }

                target = item.IsTarget ? "target=\"_blank\"" : "";

                //if (subMenus.Count > 0)
                //{
                //    liClass = "class=\"has-sub\"";
                //    icon = "<i class=\"ion-chevron-right\"></i>";
                //}
                //else
                //{
                //    liClass = "";
                //    icon = "";
                //}

                //icon = "<span><i class=\"far fa-long-arrow-right\"></i></span>";

                sidebarMenuText += "<li><a title=\"" + item.Name + "\" " + target + "  href=\"" + link + "\">" + item.Name + "</a>" + icon;
                //GetSidebarSubMenuList(subMenus);
                sidebarMenuText += "</li>";
            }
            return sidebarMenuText;
        }

        private void GetSidebarSubMenuList(List<Menu> menus)
        {
            if (menus.Count > 0)
            {
                string link = "", target = "";

                sidebarMenuText += "<ul>";
                foreach (var item in menus)
                {
                    if (item.IsExternal)
                        link = item.Link;
                    else
                    {
                        if (item.IsSubMenuListView)
                        {
                            link = String.Format("/{0}{1}/{2}/{3}", Resources.value.url_Folder, Resources.value.url_Kategoriler, Tools.UrlSeo(item.Name), item.Id.ToString());
                        }
                        else
                        {
                            link = item.TypeId == (byte)MenuType.Menu
                          ? String.Format("/{0}{1}/{2}/{3}", Resources.value.url_Folder, Resources.value.url_Menu, Tools.UrlSeo(item.Name), item.Id.ToString())
                          : String.Format("/{0}{1}/{2}/{3}", Resources.value.url_Folder, Resources.value.url_Kategori, Tools.UrlSeo(item.Name), item.Id.ToString());
                        }
                    }

                    target = item.IsTarget ? "target=\"_blank\"" : "";

                    sidebarMenuText += "<li><a title=\"" + item.Name + "\" " + target + "  href=\"" + link + "\">" + item.Name + "</a></li>";
                }
                sidebarMenuText += "</ul>";
            }
        }


        public string Mobile_GenerateMenu(byte languageId)
        {
            //int flag = 0;
            string link = "", target = "", liClass = "", aClass = "";

            var mainMenu = _menuService.GetAll_UIMenuList(0, languageId);

            foreach (var item in mainMenu)
            {
                var subMenu = _menuService.GetAll_UIMenuList(item.Id, languageId);

                if (item.IsExternal)
                    link = item.Link;
                else
                {
                    if (item.IsSubMenuListView)
                    {
                        link = String.Format("/{0}{1}/{2}/{3}", Resources.value.url_Folder, Resources.value.url_Kategoriler, Tools.UrlSeo(item.Name), item.Id.ToString());
                    }
                    else
                    {
                        link = item.TypeId == (byte)MenuType.Menu
                      ? String.Format("/{0}{1}/{2}/{3}", Resources.value.url_Folder, Resources.value.url_Menu, Tools.UrlSeo(item.Name), item.Id.ToString())
                      : String.Format("/{0}{1}/{2}/{3}", Resources.value.url_Folder, Resources.value.url_Kategori, Tools.UrlSeo(item.Name), item.Id.ToString());
                    }
                }

                target = item.IsTarget ? "target=\"_blank\"" : "";

                aClass = subMenu.Count > 0 ? "class=\"has-arrow\"" : "";

                mobileMenuText += "<li " + liClass + "><a " + aClass + " title=\"" + item.Name + "\" " + target + " href=\"" + link + "\">" + item.Name + "</a>";
                Mobile_SubMenuGetList(item.Id, languageId);
                mobileMenuText += "</li>";

            }
            return mobileMenuText;
        }

        public void Mobile_SubMenuGetList(int mainMenuId, byte languageId)
        {
            var menu = _menuService.GetAll_UIMenuList(mainMenuId, languageId);
            if (menu.Count == 0) { }
            else
            {
                mobileMenuText += "<ul class=\"sub-menu\">";
                string link = "", target = "", liClass = "";
                foreach (var item in menu)
                {
                    if (item.IsExternal)
                        link = item.Link;
                    else
                    {
                        if (item.IsSubMenuListView)
                        {
                            link = String.Format("/{0}{1}/{2}/{3}", Resources.value.url_Folder, Resources.value.url_Kategoriler, Tools.UrlSeo(item.Name), item.Id.ToString());
                        }
                        else
                        {
                            link = item.TypeId == (byte)MenuType.Menu
                          ? String.Format("/{0}{1}/{2}/{3}", Resources.value.url_Folder, Resources.value.url_Menu, Tools.UrlSeo(item.Name), item.Id.ToString())
                          : String.Format("/{0}{1}/{2}/{3}", Resources.value.url_Folder, Resources.value.url_Kategori, Tools.UrlSeo(item.Name), item.Id.ToString());
                        }
                    }

                    target = item.IsTarget ? "target=\"_blank\"" : "";

                    //liClass = menu.Count > 0 ? "class=\"menu-item-has-children\"" : "";

                    mobileMenuText += "<li " + liClass + "><a title=\"" + item.Name + "\" " + target + " href=\"" + link + "\">" + item.Name + "</a>";
                    Mobile_SubMenuGetList(item.Id, languageId);
                    mobileMenuText += "</li>";
                }
                mobileMenuText += "</ul>";
            }
        }

        public void clearText()
        {
            menuText = "";
        }

        public string HeaderTopMenuList(byte languageId)
        {
            string link = "", target = "";
            foreach (var item in _menuService.GetAll_HeaderTopMenuList(languageId))
            {
                if (item.IsExternal)
                    link = item.Link;
                else
                {
                    if (item.IsSubMenuListView)
                    {
                        link = String.Format("/{0}{1}/{2}/{3}", Resources.value.url_Folder, Resources.value.url_Kategoriler, Tools.UrlSeo(item.Name), item.Id.ToString());
                    }
                    else
                    {
                        link = item.TypeId == (byte)MenuType.Menu
                      ? String.Format("/{0}{1}/{2}/{3}", Resources.value.url_Folder, Resources.value.url_Menu, Tools.UrlSeo(item.Name), item.Id.ToString())
                      : String.Format("/{0}{1}/{2}/{3}", Resources.value.url_Folder, Resources.value.url_Kategori, Tools.UrlSeo(item.Name), item.Id.ToString());
                    }
                }

                target = item.IsTarget ? "target=\"_blank\"" : "";

                headetTopMenuText += "<li><a title=\"" + item.Name + "\" " + target + " href=\"" + link + "\">" + item.Name + "</a>";
            }
            return headetTopMenuText;
        }

        public string Header_LeftGenerateMenu(byte languageId)
        {
            int flag = 0;
            string link = "", target = "", liClass = "", icon = "";

            var mainMenu = _menuService.GetAll_LeftMenuList(languageId);

            foreach (var item in mainMenu)
            {
                var subMenu = _menuService.GetAll_UIMenuList(item.Id, languageId);

                if (item.IsExternal)
                    link = item.Link;
                else
                {
                    if (item.IsSubMenuListView)
                    {
                        link = String.Format("/{0}{1}/{2}/{3}", Resources.value.url_Folder, Resources.value.url_Kategoriler, Tools.UrlSeo(item.Name), item.Id.ToString());
                    }
                    else
                    {
                        link = item.TypeId == (byte)MenuType.Menu
                      ? String.Format("/{0}{1}/{2}/{3}", Resources.value.url_Folder, Resources.value.url_Menu, Tools.UrlSeo(item.Name), item.Id.ToString())
                      : String.Format("/{0}{1}/{2}/{3}", Resources.value.url_Folder, Resources.value.url_Kategori, Tools.UrlSeo(item.Name), item.Id.ToString());
                    }
                }

                target = item.IsTarget ? "target=\"_blank\"" : "";

                if (subMenu.Count > 0)
                {
                    liClass = "class=\"sub-menu-down\"";
                    leftMenuText += String.Format(@"<li class=""{0}""><a title=""{3}"" {1} href=""{2}"">{3}</a>", liClass, target, link, item.Name);
                }
                else
                {
                    liClass = "";
                    leftMenuText += String.Format(@"<li class=""{0}""><a title=""{3}"" {0} href=""{2}"">{3}</a>", liClass, target, link, item.Name);
                }


                Header_LeftSubMenuGetList(item.Id, languageId);
                leftMenuText += " </li>";

            }
            return leftMenuText;
        }

        private void Header_LeftSubMenuGetList(int mainMenuId, byte languageId)
        {
            var menu = _menuService.GetAll_UIMenuList(mainMenuId, languageId);
            if (menu.Count == 0) { }
            else
            {
                leftMenuText += "<ul class=\"sub-menu\">";
                string link = "", target = "";
                foreach (var item in menu)
                {
                    var subMenu = _menuService.GetAll_UIMenuList(item.Id, languageId);

                    if (item.IsExternal)
                        link = item.Link;
                    else
                    {
                        if (item.IsSubMenuListView)
                        {
                            link = String.Format("/{0}{1}/{2}/{3}", Resources.value.url_Folder, Resources.value.url_Kategoriler, Tools.UrlSeo(item.Name), item.Id.ToString());
                        }
                        else
                        {
                            link = item.TypeId == (byte)MenuType.Menu
                          ? String.Format("/{0}{1}/{2}/{3}", Resources.value.url_Folder, Resources.value.url_Menu, Tools.UrlSeo(item.Name), item.Id.ToString())
                          : String.Format("/{0}{1}/{2}/{3}", Resources.value.url_Folder, Resources.value.url_Kategori, Tools.UrlSeo(item.Name), item.Id.ToString());
                        }
                    }

                    target = item.IsTarget ? "target=\"_blank\"" : "";

                    //liClass = subMenu.Count > 0 ? "class=\"menu-item-has-children\"" : "";
                    if (subMenu.Count > 0)
                    {
                        leftMenuText += "<li class=\"dropdown\"><a title=\"" + item.Name + "\" " + target + " href=\"" + link + "\">" + item.Name + "</a>";
                        Header_LeftSubMenuGetList(item.Id, languageId);
                        leftMenuText += "</li>";
                    }
                    else
                    {
                        leftMenuText += "<li><a title=\"" + item.Name + "\" " + target + " href=\"" + link + "\">" + item.Name + "</a>";
                        Header_LeftSubMenuGetList(item.Id, languageId);
                        leftMenuText += "</li>";
                    }

                }
                leftMenuText += "</ul>";
            }
        }

        public string Header_RightGenerateMenu(byte languageId)
        {
            int flag = 0;
            string link = "", target = "", liClass = "", icon = "";

            var mainMenu = _menuService.GetAll_RightMenuList(languageId);

            foreach (var item in mainMenu)
            {
                var subMenu = _menuService.GetAll_UIMenuList(item.Id, languageId);

                if (item.IsExternal)
                    link = item.Link;
                else
                {
                    if (item.IsSubMenuListView)
                    {
                        link = String.Format("/{0}{1}/{2}/{3}", Resources.value.url_Folder, Resources.value.url_Kategoriler, Tools.UrlSeo(item.Name), item.Id.ToString());
                    }
                    else
                    {
                        link = item.TypeId == (byte)MenuType.Menu
                      ? String.Format("/{0}{1}/{2}/{3}", Resources.value.url_Folder, Resources.value.url_Menu, Tools.UrlSeo(item.Name), item.Id.ToString())
                      : String.Format("/{0}{1}/{2}/{3}", Resources.value.url_Folder, Resources.value.url_Kategori, Tools.UrlSeo(item.Name), item.Id.ToString());
                    }
                }

                target = item.IsTarget ? "target=\"_blank\"" : "";

                if (subMenu.Count > 0)
                {
                    liClass = "class=\"sub-menu-down\"";
                    rightMenuText += String.Format(@"<li class=""{0}""><a title=""{3}"" {1} href=""{2}"">{3}</a>", liClass, target, link, item.Name);
                }
                else
                {
                    liClass = "";
                    rightMenuText += String.Format(@"<li class=""{0}""><a title=""{3}"" {0} href=""{2}"">{3}</a>", liClass, target, link, item.Name);
                }


                Header_RightSubMenuGetList(item.Id, languageId);
                rightMenuText += " </li>";

            }
            return rightMenuText;
        }

        private void Header_RightSubMenuGetList(int mainMenuId, byte languageId)
        {
            var menu = _menuService.GetAll_UIMenuList(mainMenuId, languageId);
            if (menu.Count == 0) { }
            else
            {
                rightMenuText += "<ul class=\"sub-menu\">";
                string link = "", target = "";
                foreach (var item in menu)
                {
                    var subMenu = _menuService.GetAll_UIMenuList(item.Id, languageId);

                    if (item.IsExternal)
                        link = item.Link;
                    else
                    {
                        if (item.IsSubMenuListView)
                        {
                            link = String.Format("/{0}{1}/{2}/{3}", Resources.value.url_Folder, Resources.value.url_Kategoriler, Tools.UrlSeo(item.Name), item.Id.ToString());
                        }
                        else
                        {
                            link = item.TypeId == (byte)MenuType.Menu
                          ? String.Format("/{0}{1}/{2}/{3}", Resources.value.url_Folder, Resources.value.url_Menu, Tools.UrlSeo(item.Name), item.Id.ToString())
                          : String.Format("/{0}{1}/{2}/{3}", Resources.value.url_Folder, Resources.value.url_Kategori, Tools.UrlSeo(item.Name), item.Id.ToString());
                        }
                    }

                    target = item.IsTarget ? "target=\"_blank\"" : "";

                    //liClass = subMenu.Count > 0 ? "class=\"menu-item-has-children\"" : "";
                    if (subMenu.Count > 0)
                    {
                        rightMenuText += "<li class=\"dropdown\"><a title=\"" + item.Name + "\" " + target + " href=\"" + link + "\">" + item.Name + "</a>";
                        Header_RightSubMenuGetList(item.Id, languageId);
                        rightMenuText += "</li>";
                    }
                    else
                    {
                        rightMenuText += "<li><a title=\"" + item.Name + "\" " + target + " href=\"" + link + "\">" + item.Name + "</a>";
                        Header_RightSubMenuGetList(item.Id, languageId);
                        rightMenuText += "</li>";
                    }

                }
                rightMenuText += "</ul>";
            }
        }
    }
}