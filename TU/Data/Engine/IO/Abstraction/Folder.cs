using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace DIntegra.TU
{
    public class FSFolder:FSComponent
    {
        internal FSFolder(String directoryName)
            : base(directoryName)
        {
        }

        internal FSFolder(String directoryName, FSFolder parentFolder)
            : base(directoryName, parentFolder)
        {
        }

        public override void ValidateOrCreate()
        {
            DirectoryInfo dirInfo = new DirectoryInfo(this.Path);

            if(!dirInfo.Exists){
                dirInfo.Create();
            }
        }
    }
}
