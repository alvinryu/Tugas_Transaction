using API_Tugas_Transaction.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Tugas_Transaction.Repositories.Interfaces
{
    interface IEmployeeRepository
    {
        IEnumerable<RegisterViewModel> Get();

        Task<Employee> Get(int id);

        int Create(RegisterViewModel registerVM);

        int Update(int id, Employee employee);

        int Delete(int id);
    }
}
