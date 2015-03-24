using System;
using System.Collections.Generic;
using System.Text;

namespace DIntegra.TU
{
    /// <summary>
    /// Базовый класс для всяких модификаторов
    /// </summary>
    public abstract class EObject
    {
        private Engine _engine = null;

        public Engine Engine
        {
            get
            {
                return this._engine;
            }
        }

        /// <summary>
        /// конструктор и в африке конструктор
        /// </summary>
        /// <param name="engine"></param>
        internal EObject(Engine engine)
        {
            this._engine = engine;
        }
    }
}
