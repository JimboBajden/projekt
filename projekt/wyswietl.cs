using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
            int i = 0;
            int j = 0;
            bool check = true;
            SQLiteCommand Count = connection.CreateCommand();
            Count.CommandText = "SELECT COUNT(*) FROM osoby";
            SQLiteDataReader Reader = Count.ExecuteReader(); Reader.Read();
            int size = Reader.GetInt32(0); Reader.Close();
            SQLiteCommand command1 = connection.CreateCommand();
            while (check)
            {
                //SELECT * FROM osoby LIMIT 3 OFFSET 0; 

                command1.CommandText = $"SELECT * FROM osoby LIMIT 10 OFFSET {i}";
                SQLiteDataReader reader1 = command1.ExecuteReader();
                while (reader1.Read())
                {
                    i++;
                    Console.WriteLine(j + "| " + reader1.GetInt32(0) + " " + reader1.GetString(1) + " " + reader1.GetString(2) + " " + reader1.GetString(3) + " " + reader1.GetString(4));
                    j++;
                }
                reader1.Close();
                if (i > 10) { Console.WriteLine("poprzednie(7) "); };
                Console.WriteLine("8: wyjdź");
                Console.WriteLine("następne(9) ");
                bool check2 = true;
                while (check2)
                {
                    string input;
                    {
                        input = Console.ReadLine();
                        switch (input)
                        {
                            case "9":
                                j = 0;
                                Console.Clear();
                                check2 = false;
                                break;
                            case "8":
                                reader1.Close();
                                check2 = false;
                                Console.Clear();
                                return;
                            case "7":
                                if (i > 10)
                                {
                                    i = i - (i - 10) - 10;
                                }
                                j = 0;
                                Console.Clear();
                                check2 = false;
                                break;
                        }
                    }
                }

                if (i >= size || size < 10) { check = false; }
            }
        }
    }
}
