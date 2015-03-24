using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DIntegra.TU.Data;
using System.IO;
using System.Windows.Forms;

namespace DIntegra.TU.Test
{
    class Program
    {
        static string foldername = "chests";
        static string folderDataName = "data";
        
        static void CreateFSystemobjects()
        {
            if (!Directory.Exists(foldername))
            {
                Directory.CreateDirectory(foldername);
            }

            if (!Directory.Exists(folderDataName))
            {
                Directory.CreateDirectory(folderDataName);
            }  
        }

        static String MakeSafeName(String name)
        {
            name = name.Replace("/", "_").Replace("\\", "_").Replace("<", "_").Replace(">", "_").Replace("?", "_").Replace("!", "_");

            return name;
        }

        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Создаем файловую структуру");
                CreateFSystemobjects();

                SiteDataManager manager = new SiteDataManager("russia", "mother", "cea5049c4d475516e27028e25646f2ab");
                if (MessageBox.Show("Качать кастом декс?", "это долго", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {



                    Console.WriteLine("Получаем коллекцию страниц с деками");
                    var pages = manager.SiteDeckManager.getDeckPages(25);


                    using (var f = File.CreateText(folderDataName + "\\customdecks.txt"))
                    {
                        foreach (String page in pages)
                        {
                            Console.WriteLine(page);

                            var decks = manager.SiteDeckManager.GetDecksListFromPage(page);
                            foreach (String deck in decks)
                            {
                                f.WriteLine(deck);
                            }
                            f.Flush();
                        }
                    }
                }

                Console.WriteLine("Получаем коллекцию пользователей");
                var chests = manager.SiteChestsManager.UserChestsDescriptions;

                foreach (UserChestDescription chestDescription in chests)
                {
                    int tries = 10;
                    while (tries-- > 0)
                    {

                        try
                        {
                            Console.WriteLine("Обрабатываем: " + chestDescription.Name);
                            var chest = manager.SiteChestsManager.FillChest(chestDescription);

                            var guild = manager.SiteDeckManager.GetGuildByPlayer(chestDescription.Name);

                            var fname = MakeSafeName(guild + "." + chestDescription.Name);

                            using (var f = File.CreateText(foldername + "\\" + fname + "_a.txt"))
                            {
                                foreach (String card in chest.IOwnerCards)
                                {
                                    f.WriteLine(card);
                                }
                            }

                            using (var f = File.CreateText(foldername + "\\" + fname + "_m.txt"))
                            {
                                foreach (String card in chest.IOwnerCardsMaxed)
                                {
                                    f.WriteLine(card);
                                }
                            }

                            using (var f = File.CreateText(foldername + "\\" + fname + "_f.txt"))
                            {
                                foreach (String card in chest.IPossibleCard)
                                {
                                    f.WriteLine(card);
                                }
                            }
                            tries = 0;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex);
                            Console.WriteLine("осталось попыток: {0}", tries);
                        }
                    }

                }

                Console.WriteLine("Done");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.ReadKey();
            }
        }
        
    }
}
