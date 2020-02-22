using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPChanger.Services
{
    public class PublicVariabl
    {
        public static string strUserName;
        public static string strPassWord;
        public static string ConnectionString;
        public static string spBody;
        public static string Olap_ConnectionString = @"Data Source=192.168.7.200;Initial Catalog= Olap_Personnel;Persist Security Info=True;User ID=hrsystem;Password=BlueDi@mond";
        public static string Pap_ConnectionString = "Data Source=GIG001P10226\\askari;Initial Catalog= PapDB;Persist Security Info=True;User ID=sa;Password=Admin120";
        public static string PEzeshki_ConnectionString = "Data Source=GIG001P10345;Initial Catalog= ServersInfoDB;Persist Security Info=True;User ID=sa;Password=1";
        public static string PersonelId;
        public static string PersonelQuery;
        public static IEnumerable<DataRow> datatable;
    }
}
