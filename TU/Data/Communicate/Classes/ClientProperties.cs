using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace DIntegra.TU.Communicate
{
    public class ClientProperties
    {
        private String _contentType = "application/x-www-form-urlencoded";
        private String _method = "POST";
        private String _userAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/37.0.2062.103 Safari/537.36";
        private String _defaultClient = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/37.0.2062.103 Safari/537.36";

        private List<ClientHeadProperty> _headProperties = null;

        public String ContentType
        {
            get
            {
                return this._contentType;
            }
            set
            {
                this._contentType = value;
            }
        }

        public String Method
        {
            get
            {
                return this._method;
            }
            set
            {
                this._method = value;
            }
        }

        public String UserAgent
        {
            get
            {
                return this._userAgent;
            }
            set
            {
                this._userAgent = value;
            }
        }

        public String DefaultClient
        {
            get
            {
                return this._defaultClient;
            }
            set
            {
                this._defaultClient = value;
            }
        }

        public List<ClientHeadProperty> HeadProperties
        {
            get
            {
                return this._headProperties;
            }
        }

        internal ClientProperties()
        {
            this._headProperties = new List<ClientHeadProperty>();

            this._headProperties.Add(new ClientHeadProperty()
            {
                Header = HttpRequestHeader.AcceptLanguage,
                Value = "ru-RU,ru;q=0.8,en-US;q=0.6,en;q=0.4"
            });

            this._headProperties.Add(new ClientHeadProperty()
            {
                Title = "DNT",
                Value = "1"
            });
        }       
    }
}
