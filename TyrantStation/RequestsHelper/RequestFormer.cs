using System;
using System.Collections.Generic;
using System.Text;
using System.Net;

namespace DI.TyrantStation.RequestsHelper
{
    /// <summary>
    /// Формирует запросы. тонны строк текста
    /// </summary>
    public static class RequestFormer
    {
        /// <summary>
        /// Дефолтный юзер агент
        /// </summary>
        private static String DefaultUserAgent { get { return "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/37.0.2062.103 Safari/537.36"; } }

        /// <summary>
        /// Дефолтный юзер агент
        /// </summary>
        private static String DefaultClient { get { return "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/37.0.2062.103 Safari/537.36"; } }


        public static WebRequest CreateGetHuntingRequest(String userId, String password)
        {
            String dataString = "password=" + password;
            byte[] data = GetBytes(dataString);

            WebRequest huntingTargets = WebRequest.Create("http://mobile.tyrantonline.com/api.php?message=getHuntingTargets&user_id="+userId);
            huntingTargets.Headers.Add("DNT", "1");
            huntingTargets.Method = "POST";
            huntingTargets.Headers.Add(HttpRequestHeader.AcceptLanguage, "ru-RU,ru;q=0.8,en-US;q=0.6,en;q=0.4");
            huntingTargets.ContentType = "application/x-www-form-urlencoded";
            huntingTargets.ContentLength = data.Length;

            var dataStream = huntingTargets.GetRequestStream();
            dataStream.Write(data, 0, data.Length);
            dataStream.Close();  

            return huntingTargets;
        }

        static byte[] GetBytes(string str)
        {
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(str);
            return bytes;
        }
    }
}
