using System;
using System.Collections.Generic;
using System.Text;

namespace DIntegra.TU
{
    public interface IFSComponent
    {
        void ValidateOrCreate();

        IFSComponent Parent { get; }

        String Path { get; }
    }
}
