using System;
using System.Configuration;
using System.Xml;

namespace KZ.WebUI.Tool
{
    public static class StaticDataTool
    {
        public static string getDomainName()
        {
            return ConfigurationManager.AppSettings["DomainName"];
        }

        public static string getSiteAddress()
        {
            return ConfigurationManager.AppSettings["SiteAddress"];
        }

        public static string getCompanyName()
        {
            return ConfigurationManager.AppSettings["CompanyName"];
        }

        public static int getPhotoUploadLimit()
        {
            return Convert.ToInt32(ConfigurationManager.AppSettings["Photo_UploadSize"]);
        }

        public static string getPhotoUploadSizeName()
        {
            return ConfigurationManager.AppSettings["Photo_UploadSizeName"];
        }

        public static int getFileUploadLimit()
        {
            return Convert.ToInt32(ConfigurationManager.AppSettings["File_UploadSize"]);
        }

        public static string getFileUploadSizeName()
        {
            return ConfigurationManager.AppSettings["File_UploadSizeName"];
        }

        public static string getProductThumbImageWidth()
        {
            return ConfigurationManager.AppSettings["ProductThumbImageWidth"];
        }

        public static string getProductThumbImageHeight()
        {
            return ConfigurationManager.AppSettings["ProductThumbImageHeight"];
        }

        public static string getProductSmallImageWidth()
        {
            return ConfigurationManager.AppSettings["ProductSmallImageWidth"];
        }

        public static string getProductSmallImageHeight()
        {
            return ConfigurationManager.AppSettings["ProductSmallImageHeight"];
        }

        public static string getProductMediumImageWidth()
        {
            return ConfigurationManager.AppSettings["ProductMediumImageWidth"];
        }

        public static string getProductMediumImageHeight()
        {
            return ConfigurationManager.AppSettings["ProductMediumImageHeight"];
        }

        public static string getProductBigImageWidth()
        {
            return ConfigurationManager.AppSettings["ProductBigImageWidth"];
        }

        public static string getProductBigImageHeight()
        {
            return ConfigurationManager.AppSettings["ProductBigImageHeight"];
        }

        public static string getGallerySmallImageWidth()
        {
            return ConfigurationManager.AppSettings["GallerySmallImageWidth"];
        }

        public static string getGallerySmallImageHeight()
        {
            return ConfigurationManager.AppSettings["GallerySmallImageHeight"];
        }

        public static string getGalleryBigImageWidth()
        {
            return ConfigurationManager.AppSettings["GalleryBigImageWidth"];
        }

        public static string getGalleryBigImageHeight()
        {
            return ConfigurationManager.AppSettings["GalleryBigImageHeight"];
        }

        public static string getBlogImageSmallWidth()
        {
            return ConfigurationManager.AppSettings["BlogImageSmallWidth"];
        }

        public static string getBlogImageSmallHeight()
        {
            return ConfigurationManager.AppSettings["BlogImageSmallHeight"];
        }

        public static string getBlogImageWidth()
        {
            return ConfigurationManager.AppSettings["BlogImageWidth"];
        }

        public static string getBlogImageHeight()
        {
            return ConfigurationManager.AppSettings["BlogImageHeight"];
        }

        public static string getSliderImageWidth()
        {
            return ConfigurationManager.AppSettings["SliderImageWidth"];
        }

        public static string getSliderImageHeight()
        {
            return ConfigurationManager.AppSettings["SliderImageHeight"];
        }

        public static string getReferenceImageWidth()
        {
            return ConfigurationManager.AppSettings["ReferenceImageWidth"];
        }

        public static string getReferenceImageHeight()
        {
            return ConfigurationManager.AppSettings["ReferenceImageHeight"];
        }

        public static string getCategoryImageWidth()
        {
            return ConfigurationManager.AppSettings["CategoryImageWidth"];
        }

        public static string getCategoryImageHeight()
        {
            return ConfigurationManager.AppSettings["CategoryImageHeight"];
        }

        public static string getPropertyIconWidth()
        {
            return ConfigurationManager.AppSettings["PropertyIconWidth"];
        }

        public static string getPropertyIconHeight()
        {
            return ConfigurationManager.AppSettings["PropertyIconHeight"];
        }

        public static string getMailTemplateLogoUrl()
        {
            return ConfigurationManager.AppSettings["MailTemplateLogoUrl"];
        }
        public static decimal GetDovizKur(string moneyType)
        {
            try
            {
                XmlDocument xmlVerisi = new XmlDocument();
                xmlVerisi.Load(ConfigurationManager.AppSettings["MerkezBankasiApi"]);
                return Convert.ToDecimal(xmlVerisi.SelectSingleNode(string.Format("Tarih_Date/Currency[@Kod='{0}']/ForexSelling", moneyType)).InnerText.Replace('.', ','));
            }
            catch
            {
                return 0;
            }
        }

        public static string getTurkisPriceMoneySybmbol()
        {
            return ConfigurationManager.AppSettings["TurkishPriceMoneySybmbol"];
        }
    }
}