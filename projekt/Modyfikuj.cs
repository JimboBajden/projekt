using System;
using System.Collections.Generic;
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
        SQLiteDataReader cmd = null;
        List<int> ids = new List<int>();
        List<string> content = new List<string>();
        public Modyfikuj(SQLiteConnection con)
        {
            conn = con;
            Co();
            Console.Clear();
            Read();
            //Console.WriteLine();
            Write();
            Console.ReadKey();
        }

        private void Co()
        {
            Wyszukaj wyszukaj = new Wyszukaj(conn);
            cmd = wyszukaj.GiveReader();
        }
        private void Read()
        {
            while (cmd.Read())
            {
                content.Add(cmd.GetInt32(0) + " " + cmd.GetString(1) + " " + cmd.GetString(2) + " " + cmd.GetString(3) + " " + cmd.GetString(4));
                ids.Add(cmd.GetInt32(0));
            }
        }
        private void Write()
        {
            int i = 1;
            while (i-1 < content.Count/5)
            {
                int j = 0;
                while (j < 6 && j < content.Count)
                {
                    Console.WriteLine(j + "| " +content[j]);
                    j++;
                    
                }
                i++;
            }
        }
    }
}
