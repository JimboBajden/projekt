using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekt
{
    internal class Wyswietl
    {
        public Wyswietl(SQLiteConnection connection) 
        {
            SQLiteCommand command1 = connection.CreateCommand();
            command1.CommandText = "select * from osoby";
            var reader1 = command1.ExecuteReader();
            Console.WriteLine("tabela osoby");
            while (reader1.Read())
            {
                Console.WriteLine(reader1.GetDecimal(0) + " " + reader1.GetString(1) + " " + reader1.GetString(2) + " " 
                + reader1.GetString(3) + " " + reader1.GetString(4));
            }
        }
    }
}
