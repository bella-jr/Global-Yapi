using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using KZ.Entity.Enums;
using KZ.WebUI.Tool.Abstract;
using Menu = KZ.Entity.Models.Data.Menu;

namespace KZ.WebUI.Tool.Concrete
{
    public class FormControlManager : IFormControlService
    {
        public void GenerateDropdownList<TSource>(List<TSource> dataList, DropDownList ddl, string value = "Id",
            string text = "Name")
        {
            ddl.DataValueField = value;
            ddl.DataTextField = text;
            ddl.DataSource = dataList;
            ddl.DataBind();
        }

        public void GenerateListbox<TSource>(List<TSource> dataList, ListBox lst, string value = "Id", string text = "Name")
        {
            lst.DataValueField = value;
            lst.DataTextField = text;
            lst.DataSource = dataList;
            lst.DataBind();
        }

        public void DropDownMenuLoad(List<Menu> list, int mainMenuId, int level, DropDownList ddl)
        {
            level++;
            foreach (var item in list.Where(x => x.MainMenuId == mainMenuId))
            {
                ddl.Items.Add(new ListItem() { Text = String.Format("{0} {1} {2}", " ", new string('→', level), item.TypeId == (byte)MenuType.Kategori ? item.Name + " - (Kategori)" : item.Name), Value = item.Id.ToString() });
                DropDownMenuLoad(list, item.Id, level, ddl);
            }
        }

        public void CategoriesListBoxLoad(List<Entity.Models.Data.Menu> list, int mainMenuId, int level, ListBox lst)
        {
            level++;
            foreach (var item in list.Where(x => x.MainMenuId == mainMenuId))
            {
                lst.Items.Add(new ListItem() { Text = String.Format("{0} {1} {2}", " ", new string('→', level), item.Name), Value = item.Id.ToString() });
                CategoriesListBoxLoad(list, item.Id, level, lst);
            }
        }
    }
}