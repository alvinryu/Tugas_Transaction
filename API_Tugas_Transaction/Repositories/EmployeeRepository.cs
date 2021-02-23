using API_Tugas_Transaction.Models;
using API_Tugas_Transaction.Repositories.Interfaces;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace API_Tugas_Transaction.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        readonly DynamicParameters parameters = new DynamicParameters();
        readonly SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString);

        public int Create(RegisterViewModel registerVM)
        {
            var spName = "SP_insertEmployee";
            parameters.Add("@FullName", registerVM.FullName);
            parameters.Add("@BirthDate", registerVM.BirthDate);
            parameters.Add("@Phone", registerVM.Phone);
            parameters.Add("@Address", registerVM.Address);
            parameters.Add("@Email", registerVM.Email);
            parameters.Add("@Password", registerVM.Password);

            var result = connection.Execute(spName, parameters, commandType: CommandType.StoredProcedure);

            return result;
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RegisterViewModel> Get()
        {
            var spName = "SP_RetrieveAllEmployee";
            var result = connection.Query<RegisterViewModel>(spName, commandType: CommandType.StoredProcedure);

            return result;
        }

        public async Task<Employee> Get(int id)
        {
            var spName = "SP_RetriveEmployeeById";
            parameters.Add("@Id", id);
            var result = await connection.QueryAsync<Employee>(spName, parameters, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }

        public int Update(int id, Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}