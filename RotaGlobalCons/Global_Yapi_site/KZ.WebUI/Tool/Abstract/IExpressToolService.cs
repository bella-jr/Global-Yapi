using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KZ.Business.Abstract;
using KZ.Core;

namespace KZ.WebUI.Tool.Abstract
{
    public interface IExpressToolService
    {
        void SuccessAlertMessage(Page page, string link);

        void ErrorAlertMessage(Page page, string link);

        void DeleteInfoAlertMessage(Page page, string link);

        void InfoAlertMessage(Page page, string message);

        string AlertMessageRedirect(string redirect, string title);

        void Status(string statusControl, string activeControl, string pasiveControl, RepeaterItemEventArgs e,
            Repeater rpt);

        string ImageUpload(string folder, FileUpload e, string width, string height, string name = "",
            string extention = "jpg");

        void MultiImageUpload(string folder, HttpPostedFile e, string width, string height, string guid, string name,
            string extention = "jpg");

        string FileUpload(string folder, FileUpload flp);

        void FileDelete(string path, string image);

        void MailSend(string subject, string message, string sendMailAddress, IMailSettingService mailSettingManager,
            Tools tool);

        void MailSend_Photo(string subject, string message, string sendMailAddress, IMailSettingService mailSettingManager,
            Tools tool, FileUpload flp);

        string LabelAlertMessage(string alertType, string message);

        void ClearTextbox(Panel pnl);

        void ClearTextboxDropdown(Panel pnl);

        void ClearTextboxDropdownCheckbox(Panel pnl);

        void ClearCheckbox(Panel pnl);

        string GetMailTemplate(string mailTemplate, byte languageId);

        string AdminLabelAlertMessage(string alertType, string message = "");
    }
}
