using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Data.SqlClient;

namespace ExportarDoBanco
{
    class Conn
    {
        private static string server = @"DESKTOP-7L8R5NK";
        private static string dataBase = "SUCOS_VENDAS";


        public static string StrCon
        {
            get { return $"Data Source={server}; Integrated Security=True; Initial Catalog={dataBase};"; }
        }
    }
}
