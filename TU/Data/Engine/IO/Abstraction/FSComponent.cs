using System;
using System.Collections.Generic;
using System.Text;

namespace DIntegra.TU
{
    public abstract class FSComponent : IFSComponent
    {
        private String _name;
        private IFSComponent _parent;

        internal FSComponent(String name)
        {
            this._name = name;
            this._parent = new NullFSObject();

            this.ValidateOrCreate();
        }

        internal FSComponent(String name, FSFolder parent)
        {
            this._name = name;
            this._parent = parent;

            this.ValidateOrCreate();
        }

        public virtual void ValidateOrCreate()
        {
            
        }

        public virtual IFSComponent Parent
        {
            get 
            {
                return this._parent;
            }
        }

        public virtual string Path
        {
            get
            {
                String result = "";

                String parentPath = this.Parent.Path;
                if (!String.IsNullOrEmpty(parentPath))
                {
                    result = parentPath + "\\";
                }

                result = result + this._name;

                return result;
            }
        }
    }
}
