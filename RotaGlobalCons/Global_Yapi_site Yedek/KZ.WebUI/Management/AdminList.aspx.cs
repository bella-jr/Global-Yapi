using System;
using System.Web.UI.WebControls;
using KZ.Business.Abstract;
using KZ.Business.DependencyResolvers.Ninject;
using KZ.Entity.Enums;
using KZ.WebUI.DependencyResolvers.Ninject;
using KZ.WebUI.Tool.Abstract;

namespace KZ.WebUI.Management
{
    public partial class AdminList : System.Web.UI.Page
    {
        private IUserService _userService;
        private IExpressToolService _expressToolService;

        public AdminList()
        {
            _userService = InstanceFactory.GetInstance<IUserService>();
            _expressToolService = WebUIInstanceFactory.GetInstance<IExpressToolService>();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                LoadData();
        }

        //Yetkili kullanıcıları listeleme işlemini gerçekleştirmektedir.
        private void LoadData()
        {
            try
            {
                var admins = _userService.GetAll((byte)TypeUser.Admin);

                rptAdminList.DataSource = admins;
                rptAdminList.DataBind();
            }
            catch
            {
                return;
            }
        }

        protected void rptAdminList_OnItemCommand(object source, RepeaterCommandEventArgs e)
        {
            try
            {
                var user = _userService.GetById(Convert.ToInt32(e.CommandArgument));

                //Admin silme işlemini gerçekleştirmektedir.
                if (e.CommandName == "Delete")
                {
                    user.IsDeleted = true;
                    _userService.Delete(user);
                }

                //Admin durumunu "pasif" yapma işlemini gerçekletirmektedir.
                else if (e.CommandName == "Active")
                {
                    user.IsStatus = false;
                    _userService.Update(user);
                }

                //Admin durumunu "aktif" yapma işlemini gerçekletirmektedir.
                else if (e.CommandName == "Pasive")
                {
                    user.IsStatus = true;
                    _userService.Update(user);
                }

                LoadData();
                ltlMessage.Text = _expressToolService.AdminLabelAlertMessage("success");
            }
            catch
            {
               ltlMessage.Text = _expressToolService.AdminLabelAlertMessage("danger");
            }
        }

        //Aktif-Pasif butonlarını ilgili durumlara göre listeleme işlemeini gerçekeştirmektedir.
        protected void rptAdminList_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            _expressToolService.Status("hfStatus", "btnActive", "btnPasive", e, rptAdminList);
        }
    }
}