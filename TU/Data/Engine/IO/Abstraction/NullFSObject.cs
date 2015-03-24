using System;
using System.Collections.Generic;
using System.Text;

namespace DIntegra.TU
{
    /// <summary>
    /// Класс заглушка
    /// </summary>
    public class NullFSObject : IFSComponent
    {
        internal NullFSObject()
        {
            //
        }

        public void ValidateOrCreate()
        {
            
        }

        public IFSComponent Parent
        {
            get
            {
                return this;
            }
        }


        public string Path
        {
            get { return ""; }
        }
    }
}
