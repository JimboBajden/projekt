using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekt
{
    internal class Dodaj
    {
        public Dodaj(SQLiteConnection connection) 
        {
            SQLiteCommand command2 = connection.CreateCommand();

            Console.Write("imie: "); string imie = Console.ReadLine();
            Console.WriteLine("nazwisko: "); string nazwisko = Console.ReadLine();
            Console.WriteLine("numer telefonu: "); string numer = Console.ReadLine();
            Console.WriteLine("adres: "); string adres = Console.ReadLine();

            command2.CommandText = $"insert into osoby (imie , nazwisko , numerTelefonu , adres) values ('{imie}' , '{nazwisko}' , '{numer}' , '{adres}')";

            var numberOfRows = command2.ExecuteNonQuery();
            var newId = connection.LastInsertRowId;

        }
    }
}
