using System;
using System.Collections.Generic;
using System.Text;

namespace DIntegra.TU.Data
{
    /// <summary>
    /// Класс, хранящий в себе информацию о сундуке пользователя.
    /// </summary>
    public class UserChestDescription
    {
        private String _name;
        private String _id;
        private String _url;

        internal UserChestDescription(String name, String id, String url)
        {
            this._name = name
                .Replace(@"/", "")
                .Replace(@"\", "")
                .Replace(@"{", "")
                .Replace(@"}", "")
                .Replace(@"[", "")
                .Replace(@"]", "")
                .Replace(@"&lt;", "")
                .Replace(@"&gt;", ""); 
            this._id = id;
            this._url = url;
        }

        public String Name
        {
            get
            {
                return this._name;
            }
        }

        public String Id
        {
            get
            {
                return this._id;
            }
        }

        internal String Url
        {
            get
            {
                return this._url;
            }
        }
    }
}
