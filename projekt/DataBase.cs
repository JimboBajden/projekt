using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekt
{
    internal class DataBase
    {
        public DataBase() 
        {
            //SQLiteConnection conn = new SQLiteConnection("data source=C:\\Users\\Przemek Curzydło4tp\\Desktop\\rzecz.db; version=3");
            SQLiteConnection conn = new SQLiteConnection("data source=C:\\Users\\jimbo\\Desktop\\rzecz.db; version=3");
            conn.Open();
            SQLiteCommand cmd = conn.CreateCommand();
            cmd.CommandText = $"select * from osoby where 1;";
            try { cmd.ExecuteNonQuery(); } catch(Exception) 
            { 
                cmd.CommandText = $"CREATE TABLE \"osoby\" (\r\n\t\"id\"\tINTEGER,\r\n\t\"imie\"\tTEXT,\r\n\t\"nazwisko\"\tTEXT,\r\n\t\"numerTelefonu\"\tTEXT,\r\n\t\"adres\"\tTEXT,\r\n\tPRIMARY KEY(\"id\" AUTOINCREMENT)\r\n);";
                cmd.ExecuteNonQuery();
            }
            conn.Close();
        }
        

    }
}
