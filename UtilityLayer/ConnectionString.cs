using System;

namespace UtilityLayer
{
    public class ConnectionString
    {
        private static string _CName = "Data Source=RAJUDUBEY\\MSSQLSERVER01;Initial Catalog=smart;Integrated Security=True";
        public static string CName
        {
            get { return _CName; }
        }
    }
}
