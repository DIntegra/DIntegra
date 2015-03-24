using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;

namespace DIntegra.TU
{
    public class CredentialManager:EObject
    {
        internal CredentialManager(Engine engine)
            : base(engine)
        {
        }

        public void AddCredentialRecord(String name, String login, String password)
        {
            Credentials nCred = new Credentials(this.Engine, name, login, password);

            this.StoreCredentials(nCred);
        }

        public List<Credentials> GetAllCredentials()
        {
            List<Credentials> creds = new List<Credentials>();

            String credFilePath = this.Engine.IOWorker.Creadentials.Path;

            FileInfo credFileInfo = new FileInfo(credFilePath);

            if (credFileInfo.Exists)
            {
                String xmldata = String.Empty;
                using (StreamReader stream = credFileInfo.OpenText())
                {
                    xmldata = stream.ReadToEnd();

                    stream.Close();
                }

                XmlDocument doc = new XmlDocument();
                doc.LoadXml("<root>"+ xmldata + "</root>");

                var elements = doc.GetElementsByTagName(Constants.XMLConvertion.CredNodeName);

                foreach (XmlNode node in elements)
                {
                    try
                    {
                        var nickname = node.Attributes[Constants.XMLConvertion.NickNameAttributename].Value;
                        var login = node.Attributes[Constants.XMLConvertion.LoginAttributename].Value;
                        var password = node.Attributes[Constants.XMLConvertion.PasswordAttributename].Value;

                        Credentials cred = new Credentials(this.Engine, nickname, login, password);
                        creds.Add(cred);
                    }
                    catch
                    {
                        // по хорошему бы эвент тут
                    }
                }
            }

            //creds.Add( new Credentials(this.Engine, "deathintegra", "3215692", "cea5049c4d475516e27028e25646f2ab"));
            //creds.Add(new Credentials(this.Engine, "Dezintegra", "3840857", "41a4f7c1f497f257fed1e4dbe16ab887"));

            return creds;
        }

        /// <summary>
        /// Добавляет учетную запись в общий перечень и сохраняет
        /// </summary>
        /// <param name="nCred"></param>
        public void StoreCredentials(Credentials nCred)
        {
            var existed = this.GetAllCredentials();

            List<Credentials> nCredColl = new List<Credentials>();

            nCredColl.Add(nCred);

            foreach (Credentials cred in existed)
            {
                if (cred.Password != nCred.Password)
                {
                    nCredColl.Add(cred);
                }                
            }

            this.SaveCredentials(nCredColl);
        }

        /// <summary>
        /// Сохраняет коллекцию данных об учетных записях
        /// </summary>
        /// <param name="credentials">Колллекция учеток</param>
        private void SaveCredentials(List<Credentials> credentials)
        {
            String dataStr = ConvertToXMLString(credentials);

            String credFilePath = this.Engine.IOWorker.Creadentials.Path;

            FileInfo credFileInfo = new FileInfo(credFilePath);

            using (StreamWriter writer = File.CreateText(credFilePath))
            {
                writer.Write(dataStr);

                writer.Flush();

                writer.Close();
            }

        }

        /// <summary>
        /// Преобразует колллекцию данных о учетных записях в строку, имеющую хмл формат. (не валидно)
        /// </summary>
        /// <param name="credColl"></param>
        /// <returns></returns>
        private static String ConvertToXMLString(List<Credentials> credColl)
        {
            XmlDocument doc = new XmlDocument();

            var rootNode = doc.CreateElement(Constants.XMLConvertion.RootNodeName);
            doc.AppendChild(rootNode);

            foreach (Credentials cred in credColl)
            {
                var credNode = doc.CreateElement(Constants.XMLConvertion.CredNodeName);

                var nickNameAttr = doc.CreateAttribute(Constants.XMLConvertion.NickNameAttributename);
                nickNameAttr.Value = cred.NickName;
                credNode.Attributes.Append(nickNameAttr);

                var loginAttr = doc.CreateAttribute(Constants.XMLConvertion.LoginAttributename);
                loginAttr.Value = cred.Login;
                credNode.Attributes.Append(loginAttr);

                var passAttr = doc.CreateAttribute(Constants.XMLConvertion.PasswordAttributename);
                passAttr.Value = cred.Password;
                credNode.Attributes.Append(passAttr);

                rootNode.AppendChild(credNode);
            }

            return rootNode.InnerXml;
        }        
    }
}
