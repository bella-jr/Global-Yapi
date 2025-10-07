using System;
using System.Web;
using KZ.Entity.Enums;
using KZ.WebUI.DependencyResolvers.Ninject;
using KZ.WebUI.Models;
using KZ.WebUI.Tool.Abstract;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;

namespace KZ.WebUI.General_Pages
{
    public partial class Contact : BasePage
    {
        private IExpressToolService _expressToolService;
        private IMailService _mailService;

        public Contact()
        {
            _expressToolService = WebUIInstanceFactory.GetInstance<IExpressToolService>();
            _mailService = WebUIInstanceFactory.GetInstance<IMailService>();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                CreateCaptchaImage();
        }

        protected void btnSend_OnClick(object sender, EventArgs e)
        {
            try
            {
                if (txtCode.Text == Session["contactForm"].ToString())
                {

                    _mailService.ContactForm_MailSend(_expressToolService, txtNameSurname.Text, txtMail.Text.Trim(), txtPhone.Text,
                        "İletişim Formu", txtMessage.Text.Trim(), "İletişim formundan yeni bir mesajınız var.", (byte)LanguageType.Turkce);

                    Session.Remove("contactForm");

                    Response.Redirect("/" + Resources.value.url_Folder + Resources.value.url_FormBasarili, false);
                }
                else
                {
                    lblMessage.Text = "Kodlar uyuşmuyor !";
                    CreateCaptchaImage();
                }
            }
            catch
            {
                Response.Write("<script language='javascript'>window.alert('" + Resources.value.formHataliMesaj + "'); window.location.href='" + HttpContext.Current.Request.RawUrl + "';</script>");
            }
        }

        public void CreateCaptchaImage()
        {
            string code = "";
            code = RandomData();

            //Üretilen kodu Session nesnesine aktarır.
            Session.Add("contactForm", code);
            //Rastgele üretilen metini alıp resme dönüştürelim.
            //boş bir resim dosyası oluştur.
            Bitmap bmp = new Bitmap(150, 75);
            //Graphics sınıfı ile resmin kontrolunu alır.
            Graphics g = Graphics.FromImage(bmp);
            //arka plan rengi verdik
            //Color colour = ColorTranslator.FromHtml("#0cc6c6");
            //Arka plan rengini soluklaştırdık.
            //g.Clear(System.Drawing.Color.FromArgb(30, colour));
            //DrawString 20‘ye 0 kordinatına kodu‘u yazdırır.
            g.DrawString(code, new Font("Comic Sanns MS", 20), new SolidBrush(System.Drawing.ColorTranslator.FromHtml("#000")), 15, 20);
            //Resmi binary olarak alıp sayfaya yazdırmak ıcın MemoryStream kullandık.
            MemoryStream ms = new MemoryStream();
            bmp.Save(ms, ImageFormat.Png);
            var base64Data = Convert.ToBase64String(ms.ToArray());
            imgKod.ImageUrl = "data:image/jpg;base64," + base64Data;
            g.Dispose();
            bmp.Dispose();
            ms.Close();
            ms.Dispose();
        }

        public string RandomData()
        {
            string value = "";
            //Türkçe karakterleri kullanmaktan vazgeçtim.
            string array = "ABCDEFGHIJKLMNOPRSTUVYZ0123456789";
            Random r = new Random();
            //Toplam 6 karakterden oluşan rastgele bir metin oluşturalım.
            for (int i = 0; i < 5; i++)
            {
                value = value + array[r.Next(0, 33)];
            }
            return value;
        }
    }
}