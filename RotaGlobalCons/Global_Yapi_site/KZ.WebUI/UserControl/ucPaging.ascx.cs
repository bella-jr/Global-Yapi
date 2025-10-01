using System;
using System.Collections.Specialized;
using System.Globalization;
using System.Text;
using System.Web;

namespace KZ.WebUI.UserControl
{
    public partial class ucPaging : System.Web.UI.UserControl
    {
        int sayfaadet = 0;
        int sayfa = 1;
        int toplam = 0;
        int adet = 10;

        int sayfaQueryString = 0;
        int sayfaURL = 0;
        bool toplamGoster = false;


        #region Properties

        public bool ToplamGoster
        {
            get { return toplamGoster; }
            set { toplamGoster = value; }
        }

        public string ToplamMetin { get; set; }

        public int Sayfa
        {
            get { return sayfa; }
            set { sayfa = value; }
        }
        public int Adet
        {
            get { return adet; }
            set { adet = value; }
        }
        public int Toplam
        {
            get { return toplam; }
            set { toplam = value; }
        }
        public int Baslangic
        {
            get
            {
                return (this.Sayfa - 1) * this.Adet;
            }
        }
        public int SayfaAdet
        {
            get { return sayfaadet; }
            set { sayfaadet = value; }
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void Sayfala()
        {
            try
            {
                NameValueCollection nameValueCollection = null;
                string url = Request.RawUrl;
                if (url.IndexOf("?") > -1)
                {
                    string qs = url.Substring(url.IndexOf("?") + 1);
                    nameValueCollection = HttpUtility.ParseQueryString(qs);
                    if (nameValueCollection["page"] != null)
                        sayfaQueryString = Convert.ToInt32(nameValueCollection["page"]);
                }

                if (Request.QueryString["page"] != null)
                    sayfaURL = Convert.ToInt32(nameValueCollection["page"]);

                sayfa = (sayfaQueryString > 0) ? sayfaQueryString :
                            (sayfaURL > 0) ? sayfaURL : 1;
            }
            catch (Exception)
            {
                // sayfa = 1;
            }

            if (ToplamGoster)
            {
                lblToplam.Text = string.Format(ToplamMetin, toplam.ToString("N0", new CultureInfo("tr-TR")));
                pnlToplam.Visible = true;
            }
            else
            {
                pnlToplam.Visible = false;
            }

            sayfaadet = (toplam / adet);
            sayfaadet += (toplam % adet) > 0 ? 1 : 0;


            if (sayfa > sayfaadet) sayfa = 1;

            pnlSayfalama.Visible = (sayfaadet > 1);

            if (pnlSayfalama.Visible)
                SayfalaDevam();
            else
            {
                if (ToplamGoster)
                    pnlToplam.CssClass = "sayfalamatoplam2";
            }
        }

        void SayfalaDevam()
        {
            lblSayfalama.Text = @"<ul class=""cs_pagination_box cs_white_color cs_semi_bold"">";

            //if (sayfa > 5)
            //    lblSayfalama.Text += SayfaNoYazdir(1);

            if (sayfa > 6)
            {
                //lblSayfalama.Text += " .. ";
            }
            //if (sayfa > 11)
            //{
            //    lblSayfalama.Text += SayfaNoYazdir(sayfa - 10);
            //    //lblSayfalama.Text += " .. ";
            //}
            //// if (sayfa - 5 > 2) lblSayfalama.Text += " .. ";

            int bas = (sayfa > 5) ? sayfa - 5 : 1;
            int son = bas + 10;

            if (sayfa > sayfaadet - 5)
                bas = sayfa - 5 - (5 - (sayfaadet - sayfa));

            for (int i = bas; i <= son; i++)
            {
                if (i >= 1 && i <= sayfaadet)
                    lblSayfalama.Text += SayfaNoYazdir(i);
            }

            //if (sayfa + 6 < sayfaadet) lblSayfalama.Text += " .. ";

            //if (sayfa < sayfaadet - 10)
            //{
            //    //lblSayfalama.Text += " .. ";
            //    lblSayfalama.Text += SayfaNoYazdir(sayfa + 10);

            //}
            if (sayfa < sayfaadet - 5)
            {
                //lblSayfalama.Text += " .. ";
            }

            //if (sayfa + 5 < sayfaadet + 1)
            //    lblSayfalama.Text += SayfaNoYazdir(sayfaadet);

            lblSayfalama.Text += "</ul>";
        }

        private string SayfaNoYazdir(int i, string str)
        {
            StringBuilder sb = new StringBuilder();
            string sayfaAdresi = "";
            string path = Request.RawUrl;

            int bas = path.IndexOf("page=");

            if (bas > -1)
            {
                int bit = path.IndexOf("&", path.IndexOf("page="));

                if (bit > -1)
                    sayfaAdresi = string.Format("{0}page={1}{2}", path.Substring(0, bas), i.ToString(), path.Substring(bit));
                else
                    sayfaAdresi = string.Format("{0}page={1}", path.Substring(0, bas), i.ToString());

                if (i != sayfa)
                    sb.Append(string.Format(@"<li><a {2} href=""{0}"">{1}</a></li>", sayfaAdresi, str,
                    (i == sayfa) ? @" class=""cs_pagination_item cs_center active""" : @" class=""cs_pagination_item cs_center"""));
                else
                    sb.Append(string.Format(@"<li><a {1}>{0}</a></li>", str,
                     (i == sayfa) ? @" class=""cs_pagination_item cs_center active""" : @" class=""cs_pagination_item cs_center"""));
            }
            else
            {
                int bit = path.IndexOf("&");
                if (bit == -1) bit = path.IndexOf("?");
                sayfaAdresi = string.Format("{0}{2}page={1}", path, str,
                    (bit > -1) ? "&" : "?");

                if (i != sayfa)
                    sb.Append(string.Format(@"<li><a {2} href=""{0}"">{1}</a></li>", sayfaAdresi, str,
                    (i == sayfa) ? @" class=""cs_pagination_item cs_center active""" : @" class=""cs_pagination_item cs_center"""));
                else
                    sb.Append(string.Format(@"<li><a {1}>{0}</a></li>", str,
                     (i == sayfa) ? @" class=""cs_pagination_item cs_center active""" : @" class=""cs_pagination_item cs_center"""));
            }

            return sb.ToString();
        }

        private string SayfaNoYazdir(int i)
        {
            return SayfaNoYazdir(i, i.ToString());
        }
    }
}