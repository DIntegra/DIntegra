using System;
using System.Collections.Generic;
using System.Text;

namespace DIntegra.TU.Forms
{
    internal class ChestsDownloaderSettings
    {
        private List<int> _levelFilter = null;

        internal Boolean GetAllFusesCollection { get; set; }

        internal Boolean GetAllMaxedCollection { get; set; }

        internal Boolean GetCurrentCollection { get; set; }

        internal ChestsDownloaderSettings()
        {
            this._levelFilter = new List<int>();

            this.GetAllFusesCollection = true;
            this.GetAllMaxedCollection = true;
            this.GetCurrentCollection = true;
        }

        internal void AddBlocklevel(int level)
        {
            this._levelFilter.Add(level);
        }

        internal Boolean CheckFilterCard(String cardrecord)
        {
            if (this._levelFilter.Count == 0)
            {
                return true;
            }

            foreach (int filterLevel in this._levelFilter)
            {
                if (cardrecord.Contains("-" + filterLevel))
                    return false;
            }

            return true;
        }
    }
}
