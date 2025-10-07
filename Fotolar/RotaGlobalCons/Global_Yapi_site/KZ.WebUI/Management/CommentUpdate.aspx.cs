using KZ.Business.Abstract;
using KZ.Business.DependencyResolvers.Ninject;
using KZ.WebUI.DependencyResolvers.Ninject;
using KZ.WebUI.Tool.Abstract;
using System;

namespace KZ.WebUI.Management
{
    public partial class CommentUpdate : System.Web.UI.Page
    {
        private ICommentService _commentService;
        private IExpressToolService _expressToolService;
        private ICkEditorService _ckEditorService;

        public CommentUpdate()
        {
            _commentService = InstanceFactory.GetInstance<ICommentService>();
            _expressToolService = WebUIInstanceFactory.GetInstance<IExpressToolService>();
            _ckEditorService = WebUIInstanceFactory.GetInstance<ICkEditorService>();
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
                int id = Convert.ToInt32(RouteData.Values["id"]);
                var comment = _commentService.GetById(id);

                txtName.Text = comment.Name;
                txtSurname.Text = comment.Surname;
                ckeDescription.Text = comment.Description;
                cbIsHome.Checked = comment.IsHome;
                cbIsView.Checked = comment.IsView;

            }
            catch
            {
                return;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(RouteData.Values["id"]);
                var comment = _commentService.GetById(id);

                comment.Name = txtName.Text;
                comment.Surname = txtSurname.Text;
                comment.Description = ckeDescription.Text;
                comment.IsView = cbIsView.Checked;
                comment.IsHome = cbIsHome.Checked;

                _commentService.Update(comment);

                ltlMessage.Text = _expressToolService.AdminLabelAlertMessage("success");
            }
            catch
            {
                ltlMessage.Text = _expressToolService.AdminLabelAlertMessage("danger");
            }
        }

    }
}