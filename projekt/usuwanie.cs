using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekt
{
    internal class Usuwanie
    {
        SQLiteConnection conn;

        public Usuwanie(SQLiteConnection connection) 
        {
            this.conn = connection;
            PoCzym();
        }

        private void PoCzym()
        {
            Console.WriteLine("po czym chcesz usunac");
            Console.WriteLine("1: id");
            Console.WriteLine("2: imie");
            Console.WriteLine("3: nazwisko");
            Console.WriteLine("4: numer telefonu");
            Console.WriteLine("5: adres");
            string option = Console.ReadLine();

            switch (option) {
                case "1":
                    id();
                break;
                case "2":
                    imie();
                break;
                case "3":
                    nazwisko();
                break;
                case "4":
                    numer();
                break;
                case "5":
                    adres();
                break;
            }
            
        }
        private void id()
        {
            Console.WriteLine("podaj id: "); string id = Console.ReadLine();
            SQLiteCommand command3 = conn.CreateCommand();
            command3.CommandText = $"DELETE FROM osoby WHERE id = {id}";
            command3.ExecuteNonQuery();
        }
        private void imie()
        {
            Console.WriteLine("podaj imie: "); string id = Console.ReadLine();
            SQLiteCommand command3 = conn.CreateCommand();
            command3.CommandText = $"DELETE FROM osoby WHERE imie = '{id}'";
            command3.ExecuteNonQuery();
        }

        private void nazwisko()
        {
            Console.WriteLine("podaj nazwisko: "); string id = Console.ReadLine();
            SQLiteCommand command3 = conn.CreateCommand();
            command3.CommandText = $"DELETE FROM osoby WHERE nazwisko = '{id}'";
            command3.ExecuteNonQuery();
        }
        private void numer()
        {
            Console.WriteLine("podaj numer tefonu: "); string id = Console.ReadLine();
            SQLiteCommand command3 = conn.CreateCommand();
            command3.CommandText = $"DELETE FROM osoby WHERE numerTelefonu = '{id}'";
            command3.ExecuteNonQuery();
        }
        private void adres()
        {
            Console.WriteLine("podaj numer tefonu: "); string id = Console.ReadLine();
            SQLiteCommand command3 = conn.CreateCommand();
            command3.CommandText = $"DELETE FROM osoby WHERE adres = '{id}'";
            command3.ExecuteNonQuery();
        }
    }
}
