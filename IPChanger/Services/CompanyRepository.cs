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
    class CompanyRepository : ICompanyRepository
    {
        public DataTable FillJob(string linkServerName, string dataBaseName)
        {
        string query = " SELECT name FROM " + linkServerName +"."+ dataBaseName + ".sys.all_objects WHERE type LIKE 'p' AND name LIKE '%sp_Trans%'";
                        
            SqlConnection Connection = new SqlConnection(PublicVariabl.Olap_ConnectionString);
            SqlDataAdapter adapter = new SqlDataAdapter(query, Connection);
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }

        public DataTable FillSpBody(string serverIp, string dataBaseName, string SpName)
        {
            string ConnectionString = @"Data Source="+ serverIp + ";Initial Catalog=" +dataBaseName+";Persist Security Info=True;User ID=hrsystem;Password=BlueDi@mond";
            //string query = " USE "+ dataBaseName + ";  EXEC sp_helptext " + SpName;
            string query =    "sp_helptext" + SpName;

            SqlConnection Connection = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand("sp_helptext ", Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@objname", SqlDbType.NVarChar, 4000).Value = SpName;

            SqlDataAdapter adapter = new SqlDataAdapter(query, Connection);
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }

        public DataTable SearchCompany(string cName)
        {
            string query = "SELECT        B_ID, B_Name, B_DBName , B_Abrev, B_IP_Server, B_DBName_Server, B_LinkServerName, B_CompanyID, B_Parentid, B_TBizID, B_IsEbus, IsPaymankar," +
                         " B_IsActive " +
                         " FROM            Branches" +
                         " WHERE(B_IsActive = 1) AND(B_IsEbus = 0) AND (B_Name LIKE '%" + cName + "%' or B_IP_Server LIKE '%" + cName + "%') and (B_IP_Server Is Not Null Or B_IP_Server<>'') ";
            SqlConnection Connection = new SqlConnection(PublicVariabl.Olap_ConnectionString);
            SqlDataAdapter adapter = new SqlDataAdapter(query, Connection);
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }

        public DataTable SelectAll()
        {
            string query = "SELECT         B_Name, B_DBName , B_Abrev, B_IP_Server, B_DBName_Server, B_LinkServerName " +
                           " FROM            Branches" +
                           " WHERE(B_IsActive = 1) AND(B_IsEbus = 0) and (B_IP_Server Is Not Null Or B_IP_Server<>'')";
            SqlConnection Connection = new SqlConnection(PublicVariabl.Olap_ConnectionString);
            SqlDataAdapter adapter = new SqlDataAdapter(query, Connection);
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }
    }
}