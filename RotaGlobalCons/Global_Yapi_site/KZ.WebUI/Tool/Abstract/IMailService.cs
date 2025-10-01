using KZ.Entity.Models.Data;

namespace KZ.WebUI.Tool.Abstract
{
    public interface IMailService
    {
        bool AddNewsUserInformation_MailSend(User user, IExpressToolService _expressToolService, string password,
            string link);

        bool AddNewAdminInformation_MailSend(User user, IExpressToolService _expressToolService, string password,
            string link);

        bool ForgetPassword_MailSend(User user, IExpressToolService _expressToolService, byte languageId,
            string password, bool isPanel, string panelTitle, string link);

        bool ContactForm_MailSend(IExpressToolService _expressToolService, string nameSurname, string mail, string phone,
            string subject, string message, string title, byte languageId);
        
    }
}
