﻿using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekt
{
    internal class Wyszukaj
    {
        SQLiteConnection conn;
        SQLiteCommand command;
        bool check = false;
        public Wyszukaj(SQLiteConnection connection)
        {
            this.conn = connection;
            command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM osoby WHERE ";
            PoCzym();
            
        }
        private void PoCzym()
        {
            Console.WriteLine(command.CommandText);
            Console.WriteLine("po czym szukać: ");
            Console.WriteLine("1: id");
            Console.WriteLine("2: imie");
            Console.WriteLine("3: nazwiko");
            Console.WriteLine("4: numer telefonu");
            Console.WriteLine("5: adres");
            Console.WriteLine("6: Wyszukaj");
            string opcja = Console.ReadLine();

            switch (opcja)
            {
                case "1":
                    Id();
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
                case "6":
                    var reader1 = command.ExecuteReader();
                    Console.WriteLine("tabela osoby");
                    while (reader1.Read())
                    {
                        Console.WriteLine(reader1.GetInt32(0) + " " + reader1.GetString(1) + " " + reader1.GetString(2) + " "
                        + reader1.GetString(3) + " " + reader1.GetString(4));
                    }
                    reader1.Close();
                    Console.WriteLine("naciśny coś aby kontynuować");
                    Console.ReadKey();
                    break;
            }

        }

        public SQLiteDataReader GiveReader()
        {
            return command.ExecuteReader();
        }

        private void Id()
        {
            if(check == true)
            {
                command.CommandText += " AND  ";
            }
            Console.WriteLine("podaj id: ");string id = Console.ReadLine();
            command.CommandText += $" id = {id} ";
            check = true;
            command.ExecuteNonQuery();
        }

        private void imie()
        {
            if (check == true)
            {
                command.CommandText += " AND  ";
            }
            Console.WriteLine("podaj imie (albo fragment + '%'): "); string imie = Console.ReadLine();
            command.CommandText += $" imie LIKE('{imie}') ";
            check = true;
            PoCzym();
        }
        private void nazwisko()
        {
            if (check == true)
            {
                command.CommandText += " AND  ";
            }
            Console.WriteLine("podaj nazwisko (albo fragment + '%'): "); string nazwisko = Console.ReadLine();
            command.CommandText += $" nazwisko LIKE ('{nazwisko}') ";
            check = true;
            PoCzym();
        }
        private void numer()
        {
            if (check == true)
            {
                command.CommandText += " AND  ";
            }
            Console.WriteLine("podaj numer (albo fragment + '%'): "); string numer = Console.ReadLine();
            command.CommandText += $" numerTelefonu LIKE('{numer}') ";
            check = true;
            PoCzym();
        }
        private void adres()
        {
            if (check == true)
            {
                command.CommandText += " AND  ";
            }
            Console.WriteLine("podaj adres (albo fragment + '%'): "); string adres = Console.ReadLine();
            command.CommandText += $" adres LIKE('{adres}') ";
            check = true;
            PoCzym();
        }
    }
}