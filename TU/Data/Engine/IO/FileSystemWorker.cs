using System;
using System.Collections.Generic;
using System.Text;

namespace DIntegra.TU
{
    public class FileSystemWorker: EObject
    {
        public FileSystemWorker(Engine engine)
            : base(engine)
        {
        }


        private FSFolder _settingsFolder = null;
        
        private FSFolder _chestsFolder = null;
        private FSFolder _currentCardsFolder = null;
        private FSFolder _maxedCardsFolder = null;
        private FSFolder _allfusesCardsFolder = null;
        private FSFolder _tempFolder = null;
        private FSFolder _tempFolderForSim;

        private FSFolder _dllFolder = null;
        private FSFolder _dataFolder = null;

        private FSFile _credentialsFile = null;
        private FSFile _customdecksFile = null;

        /// <summary>
        /// Временная папка
        /// </summary>
        internal FSFolder TempFolderForSim
        {
            get
            {
                if (this._tempFolderForSim == null)
                {
                    this._tempFolderForSim = new FSFolder("tyrantsim", this.TempFolder);
                }
                return this._tempFolderForSim;
            }
        }

        /// <summary>
        /// Временная папка
        /// </summary>
        internal FSFolder TempFolder
        {
            get
            {
                if (this._tempFolder == null)
                {
                    String tempPath = System.IO.Path.GetTempPath();

                    this._tempFolder = new FSFolder(tempPath);
                }
                return this._tempFolder;
            }
        }

        /// <summary>
        /// Тут лежат нужные для работы сима файлы
        /// </summary>
        internal FSFolder DataFolder
        {
            get
            {
                if (this._dataFolder == null)
                {
                    this._dataFolder = new FSFolder("data");
                }
                return this._dataFolder;
            }
        }

        /// <summary>
        /// Тут лежат дллки
        /// </summary>
        internal FSFolder DLLFolder
        {
            get
            {
                if (this._dllFolder == null)
                {
                    this._dllFolder = new FSFolder("DLL");
                }
                return this._dllFolder;
            }
        }

        /// <summary>
        /// папка где лежат запасы
        /// </summary>
        private FSFolder ChestsFolder
        {
            get
            {
                if (this._chestsFolder == null)
                {
                    this._chestsFolder = new FSFolder("chests");
                }
                return this._chestsFolder;
            }
        }

        internal FSFolder CurrentCardsFolder
        {
            get
            {
                if (this._currentCardsFolder == null)
                {
                    this._currentCardsFolder = new FSFolder("cur", this.ChestsFolder);
                }
                return this._currentCardsFolder;
            }
        }

        internal FSFolder MaxedCardsFolder
        {
            get
            {
                if (this._maxedCardsFolder == null)
                {
                    this._maxedCardsFolder = new FSFolder("max", this.ChestsFolder);
                }
                return this._maxedCardsFolder;
            }
        }

        internal FSFolder AllfusesCardsFolder
        {
            get
            {
                if (this._allfusesCardsFolder == null)
                {
                    this._allfusesCardsFolder = new FSFolder("fuse", this.ChestsFolder);
                }
                return this._allfusesCardsFolder;
            }
        }


        /// <summary>
        /// папка настроек
        /// </summary>
        internal FSFolder SettingsFolder
        {
            get
            {
                if (this._settingsFolder == null)
                {
                    var x = Environment.GetFolderPath( Environment.SpecialFolder.ApplicationData);

                    this._settingsFolder = new FSFolder(x + "\\DIntegra");
                }
                return this._settingsFolder;
            }
        }

        /// <summary>
        /// Файл с настройками доступа
        /// </summary>
        public IFSComponent Creadentials
        {
            get
            {
                if (this._credentialsFile == null)
                {
                    this._credentialsFile = new FSFile("access.bin", this.SettingsFolder);
                }
                return this._credentialsFile;
            }
        }

        /// <summary>
        /// Файл customdecks.txt
        /// </summary>
        public IFSComponent CustomDecksFile
        {
            get
            {
                if (this._customdecksFile == null)
                {
                    this._customdecksFile = new FSFile("customdecks.txt", this.DataFolder);
                }
                return this._customdecksFile;
            }
        }
    }
}
