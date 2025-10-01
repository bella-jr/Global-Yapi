using System;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using KZ.Business.Abstract;
using KZ.Business.DependencyResolvers.Ninject;
using KZ.Entity.Models.Data;
using KZ.WebUI.DependencyResolvers.Ninject;
using KZ.WebUI.Tool.Abstract;

namespace KZ.WebUI.Management
{
    public partial class TabFilterList : Page
    {
        private ITabFilterService _tabFilterService;
        private IExpressToolService _expressToolService;
        private ICookieService _cookieService;

        public TabFilterList()
        {
            _tabFilterService = InstanceFactory.GetInstance<ITabFilterService>();
            _expressToolService = WebUIInstanceFactory.GetInstance<IExpressToolService>();
            _cookieService = WebUIInstanceFactory.GetInstance<ICookieService>();
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
                var cookieAdmin = _cookieService.GetSessionAdmin();
                var tabFilters = _tabFilterService.GetAll(cookieAdmin.LanguageId);

                rptTabFilterList.DataSource = tabFilters;
                rptTabFilterList.DataBind();
            }
            catch
            {
                return;
            }
        }

        [WebMethod]
        public static TabFilter GetTabFilter(int filterId)
        {
            ITabFilterService _tabFilterService;
            _tabFilterService = InstanceFactory.GetInstance<ITabFilterService>();
            var data = _tabFilterService.GetById(filterId);
            return data;
        }

        protected void btnUpdateSave_OnClick(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(hfId.Value);
                var tabFilter = _tabFilterService.GetById(id);

                tabFilter.Name = txtName.Text.Trim();

                _tabFilterService.Update(tabFilter);

                txtName.Text = "";

                LoadData();
                ltlMessage.Text = _expressToolService.AdminLabelAlertMessage("success");
            }
            catch
            {
                ltlMessage.Text = _expressToolService.AdminLabelAlertMessage("danger");
            }
        }

        protected void btnAddSave_OnClick(object sender, EventArgs e)
        {
            try
            {
                _tabFilterService.Add(new TabFilter()
                {
                    Name = txtAddName.Text.Trim(),
                    LanguageId = _cookieService.GetSessionAdmin().LanguageId,
                    IsView = true,
                    SequenceNumber = 0,
                    CreationDate = DateTime.Now
                });

                txtAddName.Text = "";

                LoadData();
                ltlMessage.Text = _expressToolService.AdminLabelAlertMessage("success");
            }
            catch
            {
                ltlMessage.Text = _expressToolService.AdminLabelAlertMessage("danger");
            }
        }

        protected void rptTabFilterList_OnItemCommand(object source, RepeaterCommandEventArgs e)
        {
            try
            {
                var filter = _tabFilterService.GetById(Convert.ToInt32(e.CommandArgument));
                if (e.CommandName == "Delete")
                {
                    _tabFilterService.Delete(filter);
                }

                //Slider durumunu "pasif" yapma işlemini gerçekletirmektedir.
                else if (e.CommandName == "Active")
                {
                    filter.IsDefaultSelected = false;
                    _tabFilterService.Update(filter);
                }

                //Slider durumunu "aktif" yapma işlemini gerçekletirmektedir.
                else if (e.CommandName == "Pasive")
                {
                    filter.IsDefaultSelected = true;
                    _tabFilterService.Update(filter);

                }

                //Slider durumunu "pasif" yapma işlemini gerçekletirmektedir.
                else if (e.CommandName == "ViewActive")
                {
                    filter.IsView = false;
                    _tabFilterService.Update(filter);
                }

                //Slider durumunu "aktif" yapma işlemini gerçekletirmektedir.
                else if (e.CommandName == "ViewPasive")
                {
                    filter.IsView = true;
                    _tabFilterService.Update(filter);

                }

                LoadData();
                ltlMessage.Text = _expressToolService.AdminLabelAlertMessage("success");
            }
            catch
            {
                ltlMessage.Text = _expressToolService.AdminLabelAlertMessage("danger");
            }
        }

        protected void rptTabFilterList_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            _expressToolService.Status("hfStatus", "btnActive", "btnPasive", e, rptTabFilterList);
            _expressToolService.Status("hfViewStatus", "btnViewActive", "btnViewPasive", e, rptTabFilterList);
        }
    }
}