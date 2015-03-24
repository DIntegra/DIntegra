using System;
using System.Collections.Generic;
using System.Text;

namespace DIntegra.TU
{
    public class ChestsManager: EObject
    {
        internal ChestsManager(Engine engine)
            : base(engine)
        {
        }

        public String GetCurrentCardsFolderpath()
        {
            return this.Engine.IOWorker.CurrentCardsFolder.Path;
        }

        public String GetMaxedCardsFolderpath()
        {
            return this.Engine.IOWorker.MaxedCardsFolder.Path;
        }

        public String GetAllFusesCardsFolderpath()
        {
            return this.Engine.IOWorker.AllfusesCardsFolder.Path;
        }
    }
}
