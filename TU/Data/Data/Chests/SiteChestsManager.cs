using System;
using System.Collections.Generic;
using System.Text;

namespace DIntegra.TU.Data
{
    public class SiteChestsManager
    {
        private String _chestsUrl = "http://tyrant.webdever.ru/tuclient/chest.php";

        private SiteDataManager _manger;

        private SiteDataConnector _connector = null;
        private DateTime _lastAuth = DateTime.MinValue;

        private List<UserChestDescription> _userChestsDescriptions = null;

        internal SiteChestsManager(SiteDataManager manager)
        {
            this._manger = manager;

            // Подключаемся к сайту.            
            this.Connect();
        }

        /// <summary>
        /// Получает коллекцию пользователей, сундуки которых имеются на сайте
        /// </summary>
        public List<UserChestDescription> UserChestsDescriptions
        {
            get
            {
                if (this._userChestsDescriptions == null)
                {
                    this._userChestsDescriptions = new List<UserChestDescription>();

                    this.Connect();

                    var pageContent = this.SiteDataConnector.GetPageData(this._chestsUrl);

                    var parts = pageContent.Split(new String[] { "<a", "</a>" }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (String part in parts)
                    {
                        if (!part.Contains("chest.php?m="))
                            continue;

                        var chestLinkParts = part.Split(new String[] { "href=\"","\">" }, StringSplitOptions.RemoveEmptyEntries);

                        if (chestLinkParts.Length > 1)
                        {
                            var id = chestLinkParts[1].Split('=')[1];
                            var name = chestLinkParts[2].Replace(id, "").Replace("(", "").Replace(")", "").Trim();

                            UserChestDescription chest = new UserChestDescription(name, id, chestLinkParts[1]);
                            this._userChestsDescriptions.Add(chest);
                        }
                    }
                }
                return this._userChestsDescriptions;
            }
        }

        private List<String> ParseCardsBlock(String block)
        {
            List<String> cardsList = new List<string>();
                        
            var parts = block.Split(new String[] { "<br/>", "<BR/>", "<br>", "<BR>", "<br />", "<BR />", "<br >", "<BR >", ">", "</div>" }, StringSplitOptions.RemoveEmptyEntries);

            foreach (String part in parts)
            {
                if (part.Contains("<"))
                    continue;

                cardsList.Add(part);
            }

            return cardsList;
        }

        /// <summary>
        /// Возвращает содержимое сундука пользователя
        /// </summary>
        /// <param name="description"></param>
        /// <returns></returns>
        public UserChest FillChest(UserChestDescription description)
        {
            UserChest chest = new UserChest(description, this);

            String requestUrl = this._chestsUrl + "?m=" + description.Id;

            var pageContent = this.SiteDataConnector.GetPageData(requestUrl);

            var parts = pageContent.Split(new String[] { "<h2>","<H2>"}, StringSplitOptions.RemoveEmptyEntries);

            foreach (String part in parts)
            {
                if (part.Contains("Current Cards List"))
                {
                    chest.OwnerCards.AddRange( this.ParseCardsBlock(part));
                }

                if (part.Contains("Current Maxed Cards List"))
                {
                    chest.OwnerCardsMaxed.AddRange(this.ParseCardsBlock(part));
                }

                if (part.Contains("Possible fusions"))
                {
                    chest.PossibleCard.AddRange(this.ParseCardsBlock(part));
                }
            }

            return chest;
        }

        /// <summary>
        /// Подключение если нужно с авторизацией.
        /// </summary>
        private void Connect()
        {
            var sessionlastTime = DateTime.Now - this._lastAuth;

            if (sessionlastTime.TotalMinutes > 10)
            {
                this.SiteDataConnector.Authentificate();
                this._lastAuth = DateTime.Now;
            }
        }

        /// <summary>
        /// Ссылка на главного манагера всей байды.
        /// </summary>
        private SiteDataManager SiteDataManager
        {
            get
            {
                return this._manger;
            }
        }

        /// <summary>
        /// даталичер.
        /// </summary>
        private SiteDataConnector SiteDataConnector
        {
            get
            {
                if (this._connector == null)
                {
                    this._connector = new SiteDataConnector(this.SiteDataManager.Login, this.SiteDataManager.Password, this.SiteDataManager.UserBrotherPassword);
                }
                return this._connector;
            }
        }
    }
}
