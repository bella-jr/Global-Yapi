using System;
using KZ.Business.Abstract;
using KZ.Business.DependencyResolvers.Ninject;
using KZ.Core;
using KZ.Entity.Enums;
using KZ.Entity.Models.Data;
using KZ.WebUI.Tool.Abstract;

namespace KZ.WebUI.Tool.Concrete
{
    public class MailServiceManager : IMailService
    {
        private IMailSettingService _mailSettingService;

        public MailServiceManager()
        {
            _mailSettingService = InstanceFactory.GetInstance<IMailSettingService>();
        }

        //Yönetim panelinden yeni bir kullanıcı eklendiğinde eklenen kullanıcıya giriş bilgilerini gönderme işlemini gerçekleştirmektedir.
        public bool AddNewsUserInformation_MailSend(User user, IExpressToolService _expressToolService, string password, string link)
        {
            try
            {
                Tools tool = new Tools();

                string mailTemplate = _expressToolService.GetMailTemplate("AddUserInformation.html", (byte)LanguageType.Turkce);
                mailTemplate = mailTemplate.Replace("{NameSurname}", user.Name + " " + user.Surname);
                mailTemplate = mailTemplate.Replace("{Mail}", user.Mail);
                mailTemplate = mailTemplate.Replace("{Password}", password);
                mailTemplate = mailTemplate.Replace("{Link}", link);
                mailTemplate = mailTemplate.Replace("{SiteAddress}", StaticDataTool.getSiteAddress());
                mailTemplate = mailTemplate.Replace("{LogoUrl}", StaticDataTool.getMailTemplateLogoUrl());

                _expressToolService.MailSend(StaticDataTool.getCompanyName() + " | Üyelik Giriş Bilgileri", mailTemplate, user.Mail, _mailSettingService, tool);

                return true;
            }
            catch
            {
                return false;
            }
        }

        //Yönetim panelinden yeni bir yönetici eklendiğinde eklenen kullanıcıya giriş bilgilerini gönderme işlemini gerçekleştirmektedir.
        public bool AddNewAdminInformation_MailSend(User user, IExpressToolService _expressToolService, string password, string link)
        {
            try
            {
                Tools tool = new Tools();

                string mailTemplate = _expressToolService.GetMailTemplate("AdminInformation.html", (byte)LanguageType.Turkce);
                mailTemplate = mailTemplate.Replace("{NameSurname}", user.Name + " " + user.Surname);
                mailTemplate = mailTemplate.Replace("{Mail}", user.Mail);
                mailTemplate = mailTemplate.Replace("{Password}", password);
                mailTemplate = mailTemplate.Replace("{Link}", link);
                mailTemplate = mailTemplate.Replace("{SiteAddress}", StaticDataTool.getSiteAddress());
                mailTemplate = mailTemplate.Replace("{LogoUrl}", StaticDataTool.getMailTemplateLogoUrl());


                _expressToolService.MailSend(StaticDataTool.getCompanyName() + " | Yönetim Paneli Giriş Bilgileri", mailTemplate, user.Mail, _mailSettingService, tool);

                return true;
            }
            catch
            {
                return false;
            }
        }


        //Şifremi Unuttum ? kısmından mail gönderme işlemini gerçekleştirmektedir.
        public bool ForgetPassword_MailSend(User user, IExpressToolService _expressToolService, byte languageId, string password, bool isPanel, string panelTitle, string link)
        {
            try
            {
                Tools tool = new Tools();

                string mailTemplate = _expressToolService.GetMailTemplate("ForgetPassword.html", languageId);
                mailTemplate = mailTemplate.Replace("{NameSurname}", user.Name + " " + user.Surname);
                mailTemplate = mailTemplate.Replace("{Password}", password);
                mailTemplate = mailTemplate.Replace("{Link}", link);
                mailTemplate = mailTemplate.Replace("{SiteAddress}", StaticDataTool.getSiteAddress());
                mailTemplate = mailTemplate.Replace("{LogoUrl}", StaticDataTool.getMailTemplateLogoUrl());


                _expressToolService.MailSend(StaticDataTool.getCompanyName() + " | " + isPanel == "True" ? panelTitle : "Şifremi Unuttum ?", mailTemplate, user.Mail, _mailSettingService, tool);

                return true;
            }
            catch
            {
                return false;
            }
        }

        //İletişim formundan mail gönderme işlemini gerçekleştirmektedir.
        public bool ContactForm_MailSend(IExpressToolService _expressToolService, string nameSurname, string mail, string phone, string subject, string message, string title, byte languageId)
        {
            try
            {
                Tools tool = new Tools();

                string mailTemplate = _expressToolService.GetMailTemplate("ContactForm.html", languageId);
                var mailSetting = _mailSettingService.GetAll();

                mailTemplate = mailTemplate.Replace("{NameSurname}", nameSurname);
                mailTemplate = mailTemplate.Replace("{Mail}", mail);
                mailTemplate = mailTemplate.Replace("{Phone}", phone);
                mailTemplate = mailTemplate.Replace("{Subject}", subject);
                mailTemplate = mailTemplate.Replace("{Message}", message);
                mailTemplate = mailTemplate.Replace("{Date}", DateTime.Now.ToString("dd.MM.yyyy -  H:mm"));
                mailTemplate = mailTemplate.Replace("{SiteAddress}", StaticDataTool.getSiteAddress());
                mailTemplate = mailTemplate.Replace("{LogoUrl}", StaticDataTool.getMailTemplateLogoUrl());

                _expressToolService.MailSend(StaticDataTool.getCompanyName() + " | " + title, mailTemplate, mailSetting.ContactMail, _mailSettingService, tool);

                return true;
            }
            catch
            {
                return false;
            }
        }
        
    }
}