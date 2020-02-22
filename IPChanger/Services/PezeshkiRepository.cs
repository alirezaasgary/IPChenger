using IPChanger.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace IPChanger.Services
{
    public class PezeshkiRepository : IPezeshkiRepository
    {
        public DataTable SelectAll()
        {
            string query = "SELECT ID,ServerIP,ServerName,Company,CompanyName,Domain,Owner,Version,IctOwner,IctOwnerTel,Note FROM dbo.ServerInfo ";
          
            SqlConnection Connection = new SqlConnection(PublicVariabl.PEzeshki_ConnectionString);
            SqlDataAdapter adapter = new SqlDataAdapter(query, Connection);
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }

        public DataTable SelectOwner1()
        {
            string query = "SELECT ID,ServerIP,ServerName,Company,CompanyName,Domain,Owner,Version,IctOwner,IctOwnerTel,Note FROM dbo.ServerInfo  where Owner=1";

            SqlConnection Connection = new SqlConnection(PublicVariabl.PEzeshki_ConnectionString);
            SqlDataAdapter adapter = new SqlDataAdapter(query, Connection);
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }

        public DataTable SelectOwner2()
        {
            string query = "SELECT ID,ServerIP,ServerName,Company,CompanyName,Domain,Owner,Version,IctOwner,IctOwnerTel,Note FROM dbo.ServerInfo where Owner=2 ";

            SqlConnection Connection = new SqlConnection(PublicVariabl.PEzeshki_ConnectionString);
            SqlDataAdapter adapter = new SqlDataAdapter(query, Connection);
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }

        public DataTable SelectOwner3()
        {
            string query = "SELECT ID,ServerIP,ServerName,Company,CompanyName,Domain,Owner,Version,IctOwner,IctOwnerTel,Note FROM dbo.ServerInfo where Owner=3 ";

            SqlConnection Connection = new SqlConnection(PublicVariabl.PEzeshki_ConnectionString);
            SqlDataAdapter adapter = new SqlDataAdapter(query, Connection);
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }
    }
}
