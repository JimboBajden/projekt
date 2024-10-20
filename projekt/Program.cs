using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace projekt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();
        }
    }
}

/*
            var connection = new SQLiteConnection("data source=C:\\Users\\Przemek Curzydło4tp\\Desktop\\rzecz.db; version=3");
            connection.Open();  
            SQLiteCommand command1 = connection.CreateCommand();
            command1.CommandText = "select * from osoby";
            var reader1 = command1.ExecuteReader();/*
            //comenda do wybierania osób + wyświetlanie 
            Console.WriteLine("tabela osoby");
            while (reader1.Read())
            {
                Console.WriteLine(reader1.GetDecimal(0) + " " + reader1.GetString(1) + " " + reader1.GetString(2) + " " + reader1.GetString(3));
            }
            
            SQLiteCommand command2 = connection.CreateCommand();

            command2.CommandText = "insert into osoby (imie , nazwisko , numerTelefonu , adres) values ('test2' , 'testowiec2' , '152353453' , 'miejsce2')";

            var numberOfRows = command2.ExecuteNonQuery();
            var newId = connection.LastInsertRowId;

            //reader1 = command1.ExecuteReader();
            
           
            SQLiteCommand command3 = connection.CreateCommand();
            command3.CommandText = "DELETE FROM osoby WHERE id = 11";
            command3.ExecuteNonQuery();
            while (reader1.Read())
            {
                Console.WriteLine(reader1.GetDecimal(0) + " " + reader1.GetString(1) + " " + reader1.GetString(2) + " " + reader1.GetString(3));
            }
            */