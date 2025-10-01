using KZ.Business.Abstract;
using KZ.Business.DependencyResolvers.Ninject;
using KZ.WebUI.DependencyResolvers.Ninject;
using KZ.WebUI.Tool.Abstract;
using System;
using System.Web.UI.WebControls;

namespace KZ.WebUI.Management
{
    public partial class MostSearchedList : System.Web.UI.Page
    {
        private IMostSearchedService _mostSearchedService;
        private IExpressToolService _expressToolService;

        public MostSearchedList()
        {
            _mostSearchedService = InstanceFactory.GetInstance<IMostSearchedService>();
            _expressToolService = WebUIInstanceFactory.GetInstance<IExpressToolService>();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                LoadData();
        }

        private void LoadData()
        {
            try
            {
                var mostSearcheds = _mostSearchedService.GetList();

                rptMostSearchedList.DataSource = mostSearcheds;
                rptMostSearchedList.DataBind();
            }
            catch
            {
                return;
            }
        }

        protected void rptMostSearchedList_OnItemCommand(object source, RepeaterCommandEventArgs e)
        {
            try
            {
                var mostSearched = _mostSearchedService.GetById(Convert.ToInt32(e.CommandArgument));

                //Yazıyı silme işlemini gerçekleştirmektedir.
                if (e.CommandName == "Delete")
                {
                    _mostSearchedService.Delete(mostSearched);

                }

                //Yazı durumunu "pasif" yapma işlemini gerçekletirmektedir.
                else if (e.CommandName == "Active")
                {
                    mostSearched.IsView = false;
                    _mostSearchedService.Update(mostSearched);
                }

                //Yazı durumunu "aktif" yapma işlemini gerçekletirmektedir.
                else if (e.CommandName == "Pasive")
                {
                    mostSearched.IsView = true;
                    _mostSearchedService.Update(mostSearched);
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
        protected void rptMostSearchedList_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            _expressToolService.Status("hfStatus", "btnActive", "btnPasive", e, rptMostSearchedList);
        }
    }
}