using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPChanger.Repository
{
   public interface IAccountingRepository
    {
        bool UserValidation(string userName, string passWord);
    }
}
