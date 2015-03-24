using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using DIntegra.TU.Data;

namespace DIntegra.TU
{

    public class SimFilesManager 
    {
        private SiteDataConnector _connector = null;
        private SiteDataManager _manager = null;

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
                    this._connector = new SiteDataConnector(this.SiteDataManager.Login, this.SiteDataManager.Password, this.SiteDataManager.UserBrotherPassword);
                }
                return this._connector;
            }
        }


        internal SimFilesManager(SiteDataManager manager)
        {
            this._manager = manager;
        }

        public void UpdateSimFiles(String tempFolder, String simTempFolder, String currentfolder)
        {
            String lastArchiveUrl = this.SiteDataConnector.DownloadString("http://tyrant.webdever.ru/getlatestsim.php");
            using (WebClient Client = new WebClient())
            {

                String zipfilename = tempFolder + "\\downoaldedTyrantSim.zip";

                Client.DownloadFile(lastArchiveUrl, zipfilename);

                if (!File.Exists(zipfilename))
                    throw new FileNotFoundException();

                Ionic.Zip.ZipFile zipfile = new Ionic.Zip.ZipFile(zipfilename);

                zipfile.ExtractAll(simTempFolder);


                DirectoryInfo tempDir = new DirectoryInfo(simTempFolder);

                var exes = tempDir.GetFiles("*.exe");

                foreach (FileInfo fInfo in exes)
                {
                    fInfo.CopyTo(currentfolder + "\\" + fInfo.Name, true);
                }
            }
        }
    }
}
