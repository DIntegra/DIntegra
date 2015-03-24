using System;
using System.Collections.Generic;
using System.Text;

namespace DIntegra.TU.SimShell
{
    /// <summary>
    /// Используется в событии окончания расчета одного прогона
    /// </summary>
    class CalculatedEventArgs
    {
        public CalculatedEventArgs(String result) 
        {
            this.SimResult = result;         
        }

        public string SimResult { get; private set; } 
    }
}
