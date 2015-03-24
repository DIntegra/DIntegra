using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace DIntegra.TU.Data
{
    /// <summary>
    /// тырит деки
    /// </summary>
    public class SiteDeckManager
    {
        private const String russiaMember = "http://tyrant.webdever.ru/russia.php";
        private const String deorumMember = "http://tyrant.webdever.ru/deorum.php";
        private const String pkMember = "";
        private const String swgMember = "";
        private const String brawlmembers = "http://tyrant.webdever.ru/brawlstop100.php";
        private const String commonpage = "http://tyrant.webdever.ru/deckcollector.php";

        private SiteDataManager _manager;
        private SiteDataConnector _connector = null;

        private List<String> _guilds = null;

        internal SiteDeckManager(SiteDataManager manager)
        {
            this._manager = manager;
        }

        public String GetGuildByPlayer(String playername)
        {
            String guildName = String.Empty;

            String searchPattern = "." + playername + ":";

            if (this._guilds == null)
            {
                // нам результат не интересен. нам интересно что функция внутри себя инициализирует коллекцию
                this.getDeckPages(0);
            }

            foreach (String guild in this._guilds)
            {
                var decks = this.GetDecksListFromPage(guild);

                foreach (String deck in decks)
                {
                    if (deck.Contains(searchPattern))
                    {
                        var parts = deck.Split(new String[] { "." }, StringSplitOptions.RemoveEmptyEntries);

                        guildName = parts[0];
                        return guildName;
                    }
                }
            }

            return guildName;
        }


        /// <summary>
        /// Возвращает коллекцию найденных интересных страничек с деками
        /// </summary>
        /// <returns></returns>
        public IEnumerable getDeckPages(int maxcount)
        {
            this._guilds = new List<String>();
            
            this._guilds.Add(russiaMember);
            this._guilds.Add(deorumMember);
            this._guilds.Add(brawlmembers);

            var mainDeckPageContent = this.SiteDataConnector.GetPageData(commonpage);

            var links = mainDeckPageContent.Split(new String[] { "<a", ">" }, StringSplitOptions.RemoveEmptyEntries);

            int counted = 0;
            foreach (String link in links)
            {
                if (counted > maxcount)
                    break;

                if (!link.Contains("href")) continue;

                if (!link.Contains("?clanid=")) continue;

                var parts = link.Split(new String[] {"?clanid="}, StringSplitOptions.RemoveEmptyEntries);

                var id = parts[1].Replace("\"", "");

                var resultLink = commonpage + "?clanid=" + id;

                this._guilds.Add(resultLink);
                counted++;
            }


            return this._guilds;
        }

        /// <summary>
        /// Возвращает деки. найденные на страничке сайта
        /// </summary>
        /// <param name="deckPage">адрес сайта</param>
        /// <returns></returns>
        public List<String> GetDecksListFromPage(String deckPage)
        {
            List<String> decks = new List<String>();

            var content = this.SiteDataConnector.GetPageData(deckPage);
            var decksPart = content.Split(new String[] { "<h2>Optimizer list</h2>" }, StringSplitOptions.RemoveEmptyEntries)[1];

            var possibleDecks = decksPart.Split(new String[]{"<br/>", "<BR/>", "<br>", "<BR>", "<br />", "<BR />", "<br >", "<BR >","</p>", "</p >"}, StringSplitOptions.RemoveEmptyEntries);

            foreach (String deck in possibleDecks)
            {
                if (deck.Contains("<form"))
                    break;

                if (deck.Contains("<div"))
                    break;

                if (deck.Contains("<"))
                    continue;

                decks.Add(deck);
            }

            return decks;
        }

        /// <summary>
        /// Возвращает массив дек со всех источников
        /// </summary>
        /// <returns></returns>
        public List<String> GetAllDecks(int maxGuildCount)
        {
            List<String> decks = new List<string>();

            var deckPagesColl = this.getDeckPages(maxGuildCount);
            
            foreach (String deckPage in deckPagesColl)
            {                
                var result = this.GetDecksListFromPage(deckPage);
                if (result != null)
                {
                    decks.AddRange(result);
                }
            }

            return decks;            
        }

        /// <summary>
        /// Ссылка на главного манагера всей байды.
        /// </summary>
        private SiteDataManager SiteDataManager
        {
            get
            {
                return this._manager;
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
                    this._connector = new SiteDataConnector(this.SiteDataManager.Login, this.SiteDataManager.Password,  this.SiteDataManager.UserBrotherPassword);
                }
                return this._connector;
            }
        }
    }
}
