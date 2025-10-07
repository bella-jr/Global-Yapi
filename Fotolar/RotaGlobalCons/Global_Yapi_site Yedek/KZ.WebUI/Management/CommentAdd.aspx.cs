using KZ.Business.Abstract;
using KZ.Business.DependencyResolvers.Ninject;
using KZ.Entity.Models.Data;
using KZ.WebUI.DependencyResolvers.Ninject;
using KZ.WebUI.Tool.Abstract;
using System;

namespace KZ.WebUI.Management
{
    public partial class CommentAdd : System.Web.UI.Page
    {
        private ICommentService _commentService;
        private IExpressToolService _expressToolService;
        private ICkEditorService _ckEditorService;

        public CommentAdd()
        {
            _commentService = InstanceFactory.GetInstance<ICommentService>();
            _expressToolService = WebUIInstanceFactory.GetInstance<IExpressToolService>();
            _ckEditorService = WebUIInstanceFactory.GetInstance<ICkEditorService>();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var comment = new Comment();

                comment.Name = txtName.Text;
                comment.Surname = txtSurname.Text;
                comment.Description = ckeDescription.Text;
                comment.IsView = cbIsView.Checked;
                comment.IsHome = cbIsHome.Checked;
                comment.CreationDate = DateTime.Now;

                _commentService.Add(comment);

                _expressToolService.ClearTextboxDropdownCheckbox(pnlContent);

                ltlMessage.Text = _expressToolService.AdminLabelAlertMessage("success");
            }
            catch
            {
                ltlMessage.Text = _expressToolService.AdminLabelAlertMessage("danger");
            }
        }
    }
}