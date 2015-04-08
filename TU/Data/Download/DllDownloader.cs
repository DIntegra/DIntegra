using System;
using System.Collections.Generic;
using System.Text;

namespace DIntegra.TU.Download
{  
    public static partial class DllsInfo
    {
        private static String shareExample = "https://drive.google.com/file/d/0B-umPckBC-iMeDVYQmJwcGVzclE/view?usp=sharing";
        private static String linkExample = "https://drive.google.com/uc?export=download&id=0B-umPckBC-iMeDVYQmJwcGVzclE";       

        public static Dictionary<String,String> GetDonwloadDlls()
        {
            Dictionary<String, String> DLLs = new Dictionary<String, String>();
            
            DLLs.Add( "Dintegra.TU.Data.dll", "https://drive.google.com/uc?export=download&id=0B-umPckBC-iMeDVYQmJwcGVzclE");
            DLLs.Add( "Dintegra.TU.Forms.dll", "https://drive.google.com/uc?export=download&id=0B-umPckBC-iMVWw2M3ZBRnhrWGs");
            DLLs.Add( "Dintegra.TU.Engine.dll", "https://drive.google.com/uc?export=download&id=0B-umPckBC-iMRE15Q1BRWEc0c00");
            DLLs.Add("Icon.ico", "https://drive.google.com/uc?export=download&id=0B-umPckBC-iMZ0NialE5cTg1Rnc");
            DLLs.Add("Ionic.Zip.dll", "https://drive.google.com/uc?export=download&id=0B-umPckBC-iMNjZ2MnNOdUgwbXc");
            DLLs.Add("Newtonsoft.Json.dll", "https://drive.google.com/uc?export=download&id=0B-umPckBC-iMMmwxekVOZEg2Uk0");

            return DLLs;
        }
    }
}
