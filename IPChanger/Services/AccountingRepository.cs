using IPChanger.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPChanger.Services
{
    public class AccountingRepository : IAccountingRepository
    {
        public bool UserValidation(string userName, string passWord)
        {
            string hashpassword = PasswordHelper.EncodePasswordMd5(passWord);
            string query ="select * from users where userName = '"+userName+ "' and Password ='"+ hashpassword+"'";
            SqlConnection Connection = new SqlConnection(PublicVariabl.Pap_ConnectionString);
            SqlDataAdapter adapter = new SqlDataAdapter(query, Connection);
            adapter.TableMappings.Add("Table", "users");
            DataTable datatable = new DataTable();
            DataSet ds = new DataSet();
            adapter.Fill(ds, "users");
            int c = ds.Tables["users"].Rows.Count;
            var a = ds.Tables["users"].Columns["userName"].ToString();
            if (c==1)
                return true;
            else
               return false;
        }
    }
}
