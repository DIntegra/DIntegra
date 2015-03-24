using System;
using System.Collections.Generic;
using System.Text;

namespace DIntegra.TU
{
    /// <summary>
    /// Куча всякой движухи. ПРактически любой процесс происходит тут
    /// </summary>
    public class Engine
    {
        private FileSystemWorker _ioWorker = null;
        private CredentialManager _credmanager = null;
        private DeckManager _deckmanger = null;
        private ChestsManager _ChestsManager = null;
        

        public ChestsManager ChestsManager
        {
            get
            {
                if (this._ChestsManager == null)
                {
                    this._ChestsManager = new ChestsManager(this);
                }
                return this._ChestsManager;
            }
        }

        public DeckManager DeckManager
        {
            get
            {
                if (this._deckmanger == null)
                {
                    this._deckmanger = new DeckManager(this);
                }
                return this._deckmanger;
            }
        }


        internal FileSystemWorker IOWorker
        {
            get
            {
                if (this._ioWorker == null)
                {
                    this._ioWorker = new FileSystemWorker(this);
                }
                return this._ioWorker;
            }
        }

        /// <summary>
        /// Управленец учетными данными
        /// </summary>
        public CredentialManager CredentialManager
        {
            get
            {
                if (this._credmanager == null)
                {
                    this._credmanager = new CredentialManager(this);
                }
                return this._credmanager;
            }
        }


        public void UpdateSimFiles(Credentials current, String targetFolder)
        {
             var manager = new DIntegra.TU.Data.SiteDataManager("russia", "mother", current.Password);

             manager.SimFilesManager.UpdateSimFiles(
                 this.IOWorker.TempFolder.Path,
                 this.IOWorker.TempFolderForSim.Path,
                 targetFolder
                 );
        }
    }
}
