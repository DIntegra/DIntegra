using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace DIntegra.TU.Communicate
{
    public class TUCommunicator
    {
        private Credentials _credential = null;
        private Engine _engine = null;
        private ClientProperties _properties = null;

        /// <summary>
        /// Пользователь от имени которого осуществляется деятельнсть
        /// </summary>
        protected Credentials Credentials
        {
            get
            {
                return this._credential;
            }
        }

        /// <summary>
        /// Движок всего и вся. знает где что лежжит. откуда что взять
        /// </summary>
        protected Engine Engine
        {
            get
            {
                return this._engine;
            }
        }

        /// <summary>
        /// настройки свойств клиента
        /// </summary>
        protected ClientProperties ClientProperties
        {
            get
            {
                return this._properties;
            }
        }

        /// <summary>
        /// веб адресс конкретного запроса
        /// </summary>
        protected virtual String RequestUrl
        {
            get
            {
                return "http://mobile.tyrantonline.com/api.php?message=getHuntingTargets&user_id=" + this.Credentials.Login;
            }
        }

        protected virtual String RequestData
        {
            get
            {
                return "password="+this.Credentials.Login + "&user_id=" + this.Credentials.Login + "message=getUserAccount";
            }
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="credential"></param>
        /// <param name="engine"></param>
        public TUCommunicator(Credentials credential, Engine engine)
        {
            this._credential = credential;
            this._engine = engine;

            this._properties = new ClientProperties();
        }

        /// <summary>
        /// генерирует тело запроса 
        /// </summary>
        /// <returns></returns>
        protected Byte[] GetRequestData()
        {
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(this.RequestData);
            return bytes;
        }

        /// <summary>
        /// Генерирует реквест
        /// </summary>
        /// <returns></returns>
        public virtual WebRequest CreateRequest()
        {
            var data = this.GetRequestData();


            WebRequest request = WebRequest.Create(this.RequestUrl);

            foreach (ClientHeadProperty prop in this.ClientProperties.HeadProperties)
            {
                if (String.IsNullOrEmpty(prop.Title))
                {
                    request.Headers.Add(prop.Header, prop.Value);
                }
                else
                {
                    request.Headers.Add(prop.Title, prop.Value);
                }
            }

            request.ContentType = this.ClientProperties.ContentType;
            request.Method = this.ClientProperties.Method;
            request.ContentLength = data.Length;
            

            var dataStream = request.GetRequestStream();
            dataStream.Write(data, 0, data.Length);
            dataStream.Close();

            return request;
        }
    }
}
