using System;
using System.Collections.Generic;
using System.Text;

namespace DIntegra.TU.Data
{
    /// <summary>
    /// Позволяет получать данные с сайта
    /// </summary>
    public class SiteDataManager
    {
        private String _userBrotherPassword = String.Empty;
        private String _login = String.Empty;
        private String _pass = String.Empty;

        private SiteChestsManager _SiteChestsManager = null;
        private SiteDeckManager _SiteDeckManager = null;
        private SimFilesManager _SimFilesManager = null;
       

        public SiteDataManager(String login, String password, String userBrotherPassword)
        {
            this._userBrotherPassword = userBrotherPassword;
            this._login = login;
            this._pass = password;
        }

        /// <summary>
        /// Братский пасс, переданный через конструктор
        /// </summary>
        internal String UserBrotherPassword
        {
            get
            {
                return this._userBrotherPassword;
            }
        }

        /// <summary>
        /// логин, переданный через конструктор
        /// </summary>
        internal String Login
        {
            get
            {
                return this._login;
            }
        }

        /// <summary>
        /// пароль к декколлектору
        /// </summary>
        internal String Password
        {
            get
            {
                return this._pass;
            }
        }

        /// <summary>
        /// менеджер сундуков
        /// </summary>
        public SiteChestsManager SiteChestsManager
        {
            get
            {
                if (this._SiteChestsManager == null)
                {
                    this._SiteChestsManager = new SiteChestsManager(this);
                }

                return this._SiteChestsManager;
            }
        }

        /// <summary>
        /// менеджер дек
        /// </summary>
        public SiteDeckManager SiteDeckManager
        {
            get
            {
                if (this._SiteDeckManager == null)
                {
                    this._SiteDeckManager = new SiteDeckManager(this);
                }

                return this._SiteDeckManager;
            }
        }

        public SimFilesManager SimFilesManager
        {
            get
            {
                if (this._SimFilesManager == null)
                {
                    this._SimFilesManager = new SimFilesManager(this);
                }
                return this._SimFilesManager;
            }
        }
    }
}
