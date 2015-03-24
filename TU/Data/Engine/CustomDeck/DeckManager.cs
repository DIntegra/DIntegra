using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace DIntegra.TU
{
    /// <summary>
    /// Управляет файлом кастомдекс
    /// </summary>
    public class DeckManager : EObject
    {
        internal DeckManager(Engine engine)
            : base(engine)
        {
        }

        /// <summary>
        /// Открывает (создает) файл кастомдек на запись
        /// </summary>
        /// <returns></returns>
        public FileStream OpenForWrite()
        {
            var customdeck = this.Engine.IOWorker.CustomDecksFile;

            FileInfo finfo = new FileInfo(customdeck.Path);

            var stream = finfo.OpenWrite();

            return stream;
        }

        /// <summary>
        /// Открывает файл на чтение как текст
        /// </summary>
        /// <returns></returns>
        public StreamReader OpenForRead()
        {
            var customdeck = this.Engine.IOWorker.CustomDecksFile;

            FileInfo finfo = new FileInfo(customdeck.Path);

            var stream = finfo.OpenText();

            return stream;
        }
    }
}
