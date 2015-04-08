using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DIntegra.TU.Communicate
{
    /// <summary>
    /// пара значений
    /// </summary>
    public class DataValue
    {
        public String Title { get; set; }

        public String Value { get; set; }


        internal DataValue()
        {
            this.Title = "Не указан";
            this.Value = "Нет значения";
        }

        internal DataValue(KeyValuePair<Object, Object> dataPair)
        {
            this.Title = dataPair.Key + "";
            this.Value = dataPair.Value + "";
        }
    }
}
