using System;
using KZ.WebUI.Models;

namespace KZ.WebUI
{
    public partial class Error : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = Resources.value.Sayfa_Bulunamadi;
        }
    }
}