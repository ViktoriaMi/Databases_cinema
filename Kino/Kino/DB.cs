using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Kino
{
    class DB
    {
        MySqlConnection connect = new MySqlConnection("server = localhost; user id = root; password = poiu1234; database = cinema;");
    
        public void OpenConnection ()
        {
            if (connect.State == System.Data.ConnectionState.Closed)
                connect.Open();
        }
        public void CloseConnection()
        {
            if (connect.State == System.Data.ConnectionState.Open)
                connect.Close();
        }

        public MySqlConnection getConnection ()
        {
            return connect;
        }
    }
}
