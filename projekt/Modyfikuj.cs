using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace projekt
{
    internal class Modyfikuj
    {
        SQLiteConnection conn;
        SQLiteCommand cmd = null;
        List<int> ids = new List<int>();
        List<string> content = new List<string>();
        int id;
        string osoba;
        public Modyfikuj(SQLiteConnection con)
        {
            conn = con;
            if(Co() == false) { return; }
            
            Console.Clear();
            Read();
            //Console.WriteLine();
            OCo();
            Console.Clear();
        }
        private void OCo() 
        {
            Console.Clear();
            SQLiteCommand GetOsoba = conn.CreateCommand();
            GetOsoba.CommandText = $"SELECT * FROM `osoby`  WHERE id = {id}";
            SQLiteDataReader reader = GetOsoba.ExecuteReader(); reader.Read();
            osoba = reader.GetInt32(0) + " " + reader.GetString(1) + " " + reader.GetString(2) + " " + reader.GetString(3) + " " + reader.GetString(4);
            reader.Close();
            Console.WriteLine(osoba);
            Console.WriteLine("______________________");
            Console.WriteLine("co chcesz zmienić");
            Console.WriteLine("1: imie");
            Console.WriteLine("2: nazwisko");
            Console.WriteLine("3: numer telefonu");
            Console.WriteLine("4: adres");
            Console.WriteLine("5: nic :)");
            Console.WriteLine(",: usun :)");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    Console.WriteLine("podaj nowe imie");
                    string name = Console.ReadLine();
                    SQLiteCommand cmd = new SQLiteCommand();
                    cmd = conn.CreateCommand();
                    cmd.CommandText = $"UPDATE osoby SET imie = '{name}' WHERE id = {id}";
                    Console.WriteLine(cmd.CommandText);
                    cmd.ExecuteNonQuery();
                    break;
                case "2":
                    Console.WriteLine("podaj nowe nazwisko");
                    string Lname = Console.ReadLine();
                    SQLiteCommand cmd2 = new SQLiteCommand();
                    cmd2 = conn.CreateCommand();
                    cmd2.CommandText = $"UPDATE osoby SET nazwisko = '{Lname}' WHERE id = {id}";
                    Console.WriteLine(cmd2.CommandText);
                    cmd2.ExecuteNonQuery();
                    break;
                case "3":
                    Console.WriteLine("podaj nowy numer telefonu");
                    string numer = Console.ReadLine();
                    if (numer.Length > 9) { numer = numer.Substring(0, 9); }
                    SQLiteCommand cmd3 = new SQLiteCommand();
                    cmd3 = conn.CreateCommand();
                    cmd3.CommandText = $"UPDATE osoby SET numerTelefonu = '{numer}' WHERE id = {id}";
                    Console.WriteLine(cmd3.CommandText);
                    cmd3.ExecuteNonQuery();
                    break;
                case "4":
                    Console.WriteLine("podaj nowy adres");
                    string adres = Console.ReadLine();
                    SQLiteCommand cmd4 = new SQLiteCommand();
                    cmd4 = conn.CreateCommand();
                    cmd4.CommandText = $"UPDATE osoby SET adres = '{adres}' WHERE id = {id}";
                    Console.WriteLine(cmd4.CommandText);
                    cmd4.ExecuteNonQuery();
                    break;
                case "5":
                    return;
                case ",":
                    SQLiteCommand cmd6 = new SQLiteCommand();
                    cmd6 = conn.CreateCommand();
                    cmd6.CommandText = $"DELETE FROM osoby WHERE id = {id}";
                    Console.WriteLine(cmd6.CommandText);
                    cmd6.ExecuteNonQuery();
                    return;
            }
        }

    
        private bool Co()
        {
            Wyszukaj wyszukaj = new Wyszukaj(conn);
            try
            {
                cmd = wyszukaj.GiveCommand();
            }catch(Exception ex) { return false; }
            
            return true;

        }
        private void Read()
        {
            int i = 0;
            int j = 0;
            bool check = true;
            SQLiteCommand Count = conn.CreateCommand();
            Count.CommandText = cmd.CommandText;
            int size = 0;
            SQLiteDataReader Reader = Count.ExecuteReader(); while (Reader.Read()) { size++; };
            Reader.Close();
            SQLiteCommand command1 = conn.CreateCommand();
            while (check)
            {
                //SELECT * FROM osoby LIMIT 3 OFFSET 0; 

                command1.CommandText = cmd.CommandText + $" LIMIT 5 OFFSET {i}";
                SQLiteDataReader reader1 = command1.ExecuteReader();

                while (reader1.Read())
                {
                    i++;
                    Console.WriteLine(j + "| " + reader1.GetInt32(0) + " " + reader1.GetString(1) + " " + reader1.GetString(2) + " " + reader1.GetString(3) + " " + reader1.GetString(4));
                    j++;
                    ids.Add(reader1.GetInt32(0));
                }
                reader1.Close();
                if (i > 5) { Console.WriteLine("poprzednie(7) "); };
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
                                if (i > 5)
                                {
                                    i = i - (i - 5) - 5;
                                }
                                j = 0;
                                Console.Clear();
                                check2 = false;
                                break;
                        }
                        try
                        {
                            int tmp = System.Convert.ToInt32(input);
                            if (tmp > -1 && tmp < 5)
                            {
                                id = ids[tmp];
                                check2 = false;
                                check = false;
                                reader1.Close();
                            }
                        }
                        catch (Exception e) { }
                    }
                }

                if (i >= size || size < 5) { check = false; }
            }
        }
        
    }
}
