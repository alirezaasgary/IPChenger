using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPChanger.Repository
{
    interface ICompanyRepository
    {
        DataTable SelectAll();
        DataTable SearchCompany(string cName);
        DataTable FillJob(string linkServerName, string dataBaseName);
        DataTable FillSpBody(string serverIp, string dataBaseName,string SpName);
    }
}
