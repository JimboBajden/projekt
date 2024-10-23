using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekt
{
    internal class Menu
    {
        public Menu()
        {
            new DataBase();
            //SQLiteConnection connection = new SQLiteConnection("data source=C:\\Users\\przemyslaw.curzydlo\\Desktop\\rzecz.db; version=3");
            //SQLiteConnection connection = new SQLiteConnection("data source=C:\\Users\\Przemek Curzydło4tp\\Desktop\\rzecz.db; version=3");
            SQLiteConnection connection = new SQLiteConnection("data source=C:\\Users\\jimbo\\Desktop\\rzecz.db; version=3");
            try
            {
                connection.Open();
            }
            catch (Exception ex) { Console.WriteLine("nie ma takiej bazy :(");return; }
            
            while (true)
            {
                Console.WriteLine("opcje: ");
                Console.WriteLine("1: zobacz osoby");
                Console.WriteLine("2: dodaj osoby");
                Console.WriteLine("3: usuń osoby");
                Console.WriteLine("4: wyszukaj osoby");
                Console.WriteLine("5: modyfikuj rekord");
                string option = Console.ReadLine();
                Console.Clear();

                switch (option)
                {
                    case "1":
                        Wyswietl wyswietl = new Wyswietl(connection);
                        break;
                    case "2":
                        Dodaj dodaj = new Dodaj(connection);
                        break;
                    case "3":
                        Usuwanie usuwanie = new Usuwanie(connection);
                        break;
                    case "4":
                        Wyszukaj wyszukaj = new Wyszukaj(connection);
                    break;
                    case "5":
                        Modyfikuj modyfikuj = new Modyfikuj(connection);
                    break;
                }
                Console.WriteLine();
            }
        }
    }
}
