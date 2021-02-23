using API_Tugas_Transaction.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Tugas_Transaction.Repositories.Interfaces
{
    interface IAccountRepository
    {
        int Update(int id, Account account);
    }
}
