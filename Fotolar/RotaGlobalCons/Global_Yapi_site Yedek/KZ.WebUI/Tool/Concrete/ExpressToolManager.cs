using System;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ImageResizer;
using KZ.Business.Abstract;
using KZ.Core;
using KZ.Entity.Enums;
using KZ.WebUI.Tool.Abstract;

namespace KZ.WebUI.Tool.Concrete
{
    public class ExpressToolManager : IExpressToolService
    {
        //Başarılı işlem bilgilendirme mesajı gösterme işlemini gerçekleştirmektedir.
        public void SuccessAlertMessage(Page page, string link)
        {
            ScriptManager.RegisterStartupScript(page, GetType(), "message",
                "<script>successMessage('" + link + "')</script>",
                false);
        }

        //Hatalı işlem bilgilendirme mesajı gösterme işlemini gerçekleştirmektedir.
        public void ErrorAlertMessage(Page page, string link)
        {
            ScriptManager.RegisterStartupScript(page, GetType(), "message",
                "<script>errorMessage('" + link + "')</script>",
                false);
        }

        //Silme sırasında ilişkili veri varsa ise bilgilendirme mesajı gösterme işlemini gerçekleştirmektedir.
        public void DeleteInfoAlertMessage(Page page, string link)
        {
            ScriptManager.RegisterStartupScript(page, GetType(), "warning",
                "<script>deleteInfoMessage('" + link + "')</script>",
                false);
        }

        public void InfoAlertMessage(Page page, string message)
        {
            ScriptManager.RegisterStartupScript(page, GetType(), "warning",
                "<script>infoMessage('" + message + "')</script>",
                false);
        }

        public string AlertMessageRedirect(string redirect, string title)
        {
            return "<script language='javascript'>window.alert('" + title + "'); window.location.href='" + redirect + "';</script>";
        }

        //Listeleme sayfalarındaki Aktif/Pasif butonlarını ilgili durumlara göre açıp kapatma işlemini gerçekleştirir.
        public void Status(string statusControl, string activeControl, string pasiveControl, RepeaterItemEventArgs e, Repeater rpt)
        {

            HiddenField status = ((HiddenField)e.Item.FindControl(statusControl));
            Button active = ((Button)e.Item.FindControl(activeControl));
            Button pasive = ((Button)e.Item.FindControl(pasiveControl));

            if (status.Value == "True")
                pasive.Visible = false;
            else
                active.Visible = false;
        }

        //Resim yükleme işlemini gerçekleştirmektedir.
        public string ImageUpload(string folder, FileUpload e, string width, string height, string name = "", string extention = "jpg")
        {
            Stream stream = e.PostedFile.InputStream;
            System.Drawing.Image image = System.Drawing.Image.FromStream(stream);

            FitMode fitMode;
            if (image.Width >= image.Height || image.Width == image.Height)
                fitMode = FitMode.Pad;
            else
                fitMode = FitMode.Pad;

            string guid = Guid.NewGuid().ToString();
            var resizeCropSettings = new ResizeSettings("width=" + width + "&height=" + height + "") { Mode = fitMode };
            string fileName1 = Path.Combine(folder, name + guid);
            ImageBuilder.Current.Build(folder + e.FileName, fileName1, resizeCropSettings, false, true);

            FileDelete(folder, e.FileName);

            string extension = System.IO.Path.GetExtension(e.FileName);

            return guid + extension;
        }

        //Çoklu resim yükleme işlemini gerçekleştirmektedir.
        public void MultiImageUpload(string folder, HttpPostedFile e, string width, string height, string guid, string name, string extention = "jpg")
        {
            FitMode fitMode;
            Stream stream = e.InputStream;
            System.Drawing.Image image = System.Drawing.Image.FromStream(stream);

            //if (image.Width >= image.Height || image.Width == image.Height)
            //    fitMode = FitMode.Pad;
            //else
            //    fitMode = FitMode.None;

            fitMode = FitMode.Pad;

            var resizeCropSettings = new ResizeSettings("width=" + width + "&height=" + height + "&format=" + extention + "") { Mode = fitMode };
            string fileName1 = Path.Combine(folder, name + guid);
            ImageBuilder.Current.Build(folder + e.FileName, fileName1, resizeCropSettings, false, true);
        }

        //Dosya/fotoğraf yükleme işlemini gerçekleştirmektedir.
        public string FileUpload(string folder, FileUpload flp)
        {
            try
            {
                string guid = Guid.NewGuid().ToString();
                string fileName = guid + Path.GetExtension(flp.PostedFile.FileName);
                flp.SaveAs(folder + fileName);
                return fileName;
            }
            catch
            {
                return null;
            }
        }

        //FTP klasöründen dosya/fotoğraf silme işlemi gerçekleştirmektedir.
        public void FileDelete(string path, string image)
        {
            if (image.Contains("Default.jpg") == false)
            {
                FileInfo fix = new FileInfo(path + image);
                fix.Delete();
            }
        }

        //Mail gönderme işlemini gerçekleştirmektedir.
        public void MailSend(string subject, string message, string sendMailAddress, IMailSettingService mailSettingManager, Tools tool)
        {
            var mailData = mailSettingManager.GetAll();
            tool.MailSend(mailData.Server, mailData.Account, mailData.Password, mailData.Ssl, mailData.Port, mailData.Address, mailData.Title, subject, message, sendMailAddress);
        }

        public void MailSend_Photo(string subject, string message, string sendMailAddress, IMailSettingService mailSettingManager, Tools tool, FileUpload flp)
        {
            var mailData = mailSettingManager.GetAll();
            tool.MailSend2(mailData.Server, mailData.Account, mailData.Password, mailData.Ssl, mailData.Port, mailData.Address, mailData.Title, subject, message, sendMailAddress, flp);
        }

        public string LabelAlertMessage(string alertType, string message)
        {
            return "<div class=\"alert alert-" + alertType + "\"><a class=\"close\" data-dismiss=\"alert\"><span aria-hidden=\"true\">×</span></a><p class=\"text-small\">" + message + "</p></div>";
        }

        //Tüm textbox kontrolleriniz temizleme işlemini gerçekleştirmektedir.
        public void ClearTextbox(Panel pnl)
        {
            foreach (Control c in pnl.Controls)
            {
                if (c is TextBox)
                {
                    TextBox txt = c as TextBox;
                    txt.Text = "";
                }
            }
        }

        //Tüm textbox ve dropdownlist kontrollerini temizleme işlemini gerçekleştirmektedir.
        public void ClearTextboxDropdown(Panel pnl)
        {
            foreach (Control c in pnl.Controls)
            {
                if (c is TextBox)
                {
                    TextBox txt = c as TextBox;
                    txt.Text = "";
                }

                if (c is DropDownList)
                {
                    DropDownList drp = c as DropDownList;
                    drp.SelectedIndex = 0;
                }
            }
        }

        //Tüm textbox,dropdownlist ve checkbox kontollerini temizleme işlemini gerçekleştirmektedir.
        public void ClearTextboxDropdownCheckbox(Panel pnl)
        {
            foreach (Control c in pnl.Controls)
            {
                if (c is TextBox)
                {
                    TextBox txt = c as TextBox;
                    txt.Text = "";
                }

                if (c is DropDownList)
                {
                    DropDownList drp = c as DropDownList;
                    drp.SelectedIndex = 0;
                }

                if (c is CheckBox)
                {
                    CheckBox chk = c as CheckBox;
                    chk.Checked = false;
                }
            }
        }

        //Tüm checkbox kontollerini temizleme işlemini gerçekleştirmektedir.
        public void ClearCheckbox(Panel pnl)
        {
            foreach (Control c in pnl.Controls)
            {
                if (c is CheckBox)
                {
                    CheckBox chk = c as CheckBox;
                    chk.Checked = false;
                }
            }
        }

        //Özel olarak mail şablonunu elde etme işlemini gerçekleştirmektedir.
        public string GetMailTemplate(string mailTemplate, byte languageId)
        {
            string templatePath = "";
            switch (languageId)
            {
                case (byte)LanguageType.Turkce:
                    templatePath = "/MailTemplate/TR/" + mailTemplate;
                    break;
            }

            using (StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath(templatePath)))
            {
                return reader.ReadToEnd();
            }
        }

        public static string SummaryText(string value, int count)
        {
            try
            {
                return Tools.ClearHtml(HttpUtility.HtmlDecode(value).Length > count
                    ? Tools.ClearHtml(HttpUtility.HtmlDecode(value)).Substring(0, count)
                    : Tools.ClearHtml(HttpUtility.HtmlDecode(value)));
            }
            catch
            {
                return "-";
            }
        }

        public string AdminLabelAlertMessage(string alertType, string message = "")
        {
            if (alertType == "success" && message == "")
            {
                return "<div class=\"alert alert-" + alertType + "\" role=\"alert\">İşleminiz başarı ile gerçekleştirilmiştir.</div>";
            }

            if (alertType == "danger" && message == "")
            {
                return "<div class=\"alert alert-" + alertType + "\" role=\"alert\">İşlem sırasında hata meydana geldi.</div>";
            }

            return "<div class=\"alert alert-" + alertType + "\" role=\"alert\">" + message + "</div>";
        }
    }
}