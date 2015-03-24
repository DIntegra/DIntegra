using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace DIntegra.TU
{
    public class Credentials: EObject
    {
        String nickName = String.Empty;        
        String tulogin = String.Empty;        
        String tupassword = String.Empty;

        /// <summary>
        /// распарсивает учетку
        /// </summary>
        /// <param name="engine"></param>
        /// <param name="node"></param>
        /// <returns></returns>
        internal static Credentials ParseCredentials(Engine engine, XmlNode node)
        {
            String name = node.Attributes["name"].Value;
            String login = node.Attributes["login"].Value;
            String password = node.Attributes["password"].Value;

            Credentials cred = new Credentials(engine, name, login, password);
            return cred;
        }

        /// <summary>
        /// Возвращаетник нейм
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.NickName;
        }


        /// <summary>
        /// CTOR
        /// </summary>
        /// <param name="engine">Ядро всяких заморочек</param>
        /// <param name="name">Никнэйм пользователя</param>
        /// <param name="login">Логин пользователя</param>
        /// <param name="password">Пароль пользователя</param>
        internal Credentials(Engine engine, String name, String login, String password)
            : base(engine)
        {
            this.nickName = name;
            this.tulogin = login;
            this.tupassword = password;
        }

        /// <summary>
        /// Метка/никнейм
        /// </summary>
        public String NickName
        {
            get { return nickName; }
            set { nickName = value; }
        }
        
        /// <summary>
        /// Логин ТУ
        /// </summary>
        public String Login
        {
            get { return tulogin; }
            set { tulogin = value; }
        }

        /// <summary>
        /// пароль ТУ
        /// </summary>
        public String Password
        {
            get { return tupassword; }
            set { tupassword = value; }
        }
    }
}
