using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPChanger.Repository
{
   public interface IPezeshkiRepository
    {
        DataTable SelectAll();
        DataTable SelectOwner3();
        DataTable SelectOwner1();
        DataTable SelectOwner2();
    }
}
