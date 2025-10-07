using KZ.WebUI.Models;
using System;
using System.Web.UI;

namespace KZ.WebUI.General_Pages
{
    public partial class FormSuccess : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = Resources.value.Mesaj_Bilgilendirme;
        }
    }
}