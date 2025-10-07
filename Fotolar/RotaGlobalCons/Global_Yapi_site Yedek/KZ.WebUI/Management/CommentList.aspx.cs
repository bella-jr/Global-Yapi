using KZ.Business.Abstract;
using KZ.Business.DependencyResolvers.Ninject;
using KZ.WebUI.DependencyResolvers.Ninject;
using KZ.WebUI.Tool.Abstract;
using System;
using System.Web.UI.WebControls;

namespace KZ.WebUI.Management
{
    public partial class CommentList : System.Web.UI.Page
    {
        private ICommentService _commentService;
        private IExpressToolService _expressToolService;

        public CommentList()
        {
            _commentService = InstanceFactory.GetInstance<ICommentService>();
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
                var comments = _commentService.GetList();

                rptCommentList.DataSource = comments;
                rptCommentList.DataBind();
            }
            catch
            {
                return;
            }
        }

        protected void rptCommentList_OnItemCommand(object source, RepeaterCommandEventArgs e)
        {
            try
            {
                var comment = _commentService.GetById(Convert.ToInt32(e.CommandArgument));

                //Yazıyı silme işlemini gerçekleştirmektedir.
                if (e.CommandName == "Delete")
                {
                    _commentService.Delete(comment);

                }

                //Yazı durumunu "pasif" yapma işlemini gerçekletirmektedir.
                else if (e.CommandName == "Active")
                {
                    comment.IsView = false;
                    _commentService.Update(comment);
                }

                //Yazı durumunu "aktif" yapma işlemini gerçekletirmektedir.
                else if (e.CommandName == "Pasive")
                {
                    comment.IsView = true;
                    _commentService.Update(comment);
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
        protected void rptCommentList_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            _expressToolService.Status("hfStatus", "btnActive", "btnPasive", e, rptCommentList);
        }
    }
}