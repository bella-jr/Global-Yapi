using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace KZ.WebUI.Tool.Abstract
{
    public interface IFormControlService
    {
        void GenerateDropdownList<TSource>(List<TSource> dataList, DropDownList ddl, string value = "Id", string text = "Name");

        void GenerateListbox<TSource>(List<TSource> dataList, ListBox ddl, string value = "Id", string text = "Name");


        void DropDownMenuLoad(List<Entity.Models.Data.Menu> list, int mainMenuId, int level, DropDownList ddl);

        void CategoriesListBoxLoad(List<Entity.Models.Data.Menu> list, int mainMenuId, int level, ListBox lst);

    }
}
