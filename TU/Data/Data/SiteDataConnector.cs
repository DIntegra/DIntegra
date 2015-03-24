using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using System.Collections.Specialized;

namespace DIntegra.TU.Data
{
    /// <summary>
    /// Осуществляет работу с сайтом на низком уровне
    /// </summary>
    internal class SiteDataConnector : WebClient
    {
        public CookieContainer CookieContainer { get; set; }

        private String _userBrotherPassword;
        private String _login = "";
        private String _pass = "";
        private String _loginPageUrl = "http://tyrant.webdever.ru/tuclient/login.php";

        protected String UserBrotherPassword { get { return this._userBrotherPassword; } }
        protected String Login { get { return this._login; } }
        protected String Password { get { return this._pass; } }

        internal SiteDataConnector(String login, String pass, String userBrotherPassword)
        {
            this._login = login;
            this._pass = pass;

            this._userBrotherPassword = userBrotherPassword;
            this.CookieContainer = new CookieContainer();
        }

        protected override WebRequest GetWebRequest(Uri address)
        {
            var request = (HttpWebRequest)base.GetWebRequest(address);
            request.CookieContainer = CookieContainer;
            request.Headers.Add(HttpRequestHeader.AcceptLanguage, "en-US,en;q=0.8");
            request.Credentials = this.Credentials;
            return request;
        }

        private new ICredentials Credentials
        {
            get
            {
                return new NetworkCredential(this.Login, this.Password);
            }
        }

        static byte[] GetBytes(string str)
        {
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(str);
            return bytes;
        }

        public void Authentificate()
        {
            Stream dataStream = null;
            WebResponse response = null;

            try
            {
                String formContent = "password=" + this.UserBrotherPassword + "&submit=";
                var data = GetBytes(formContent);

                var req = this.GetWebRequest(new Uri(this._loginPageUrl));
                var request = (HttpWebRequest)req;

                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.Headers.Add(HttpRequestHeader.AcceptEncoding, "UTF-8");
                request.ContentLength = data.Length;


                dataStream = request.GetRequestStream(); // тут оно вываливается с ошибкой 401. но все чикипуки
                dataStream.Write(data, 0, data.Length);
                dataStream.Flush();
                dataStream.Close();

                response = request.GetResponse();
                dataStream = response.GetResponseStream();             
            }
            catch { }
            finally{
                if (dataStream != null) dataStream.Close();
                if (response != null) response.Close();
            }
        }

        public String GetPageData(String pageUrl)
        {
            String responseFromServer = "";

            WebRequest request = null;
            StreamReader reader = null;
            Stream dataStream = null;
            WebResponse response = null;

            try
            {
                request = this.GetWebRequest(new Uri(pageUrl));
                //request = (HttpWebRequest)req;
                
                request.Method = "GET";               
                request.ContentType = "application/x-www-form-urlencoded";



                //request.ContentLength = data.Length;
                //dataStream = request.GetRequestStream();
                //dataStream.Write(data, 0, data.Length);
                //dataStream.Close();


                response = request.GetResponse();
                dataStream = response.GetResponseStream();
                
                reader = new StreamReader(dataStream);
                responseFromServer = reader.ReadToEnd();

            }
            finally
            {
                //if reader!=null) reader.Close();
                if (dataStream != null) dataStream.Close();
                if (response != null) response.Close();
            }

            return responseFromServer;
        }
    }
}
