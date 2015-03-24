using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace DIntegra.TU
{
    public class FSFile:FSComponent
    {
        private IFSComponent parent;

        internal FSFile(String directoryName)
            : base(directoryName)
        {
        }

        internal FSFile(String directoryName, FSFolder parentFolder)
            : base(directoryName, parentFolder)
        {
        }

        public override void ValidateOrCreate()
        {
            FileInfo fileInfo = new FileInfo(this.Path);

            if (!fileInfo.Exists)
            {
                fileInfo.Create();
            }
        }
    }
}
