using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace DIntegra.TU.Data
{
    /// <summary>
    /// Содержимое сундуля игрока
    /// </summary>
    public class UserChest
    {
        private UserChestDescription _description = null;
        private SiteChestsManager _manager = null;

        private List<String> _ownerCards = null;
        private List<String> _ownerCardsMaxed = null;
        private List<String> _possibleCard = null;

        internal UserChest(UserChestDescription desc,SiteChestsManager manager)
        {
            this._description = desc;
            this._manager = manager;


            this._ownerCards = new List<string>();
            this._ownerCardsMaxed = new List<string>();
            this._possibleCard = new List<string>();
        }

        public IEnumerable IOwnerCards
        {
            get
            {
                return this._ownerCards;
            }
        }
        public IEnumerable IOwnerCardsMaxed
        {
            get
            {
                return this._ownerCardsMaxed;
            }
        }
        public IEnumerable IPossibleCard
        {
            get
            {
                return this._possibleCard;
            }
        }

        internal List<String> OwnerCards
        {
            get
            {
                return this._ownerCards;
            }
        }
        internal List<String> OwnerCardsMaxed
        {
            get
            {
                return this._ownerCardsMaxed;
            }
        }
        internal List<String> PossibleCard
        {
            get
            {
                return this._possibleCard;
            }
        }
    }
}
