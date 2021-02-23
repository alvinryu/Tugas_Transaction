using API_Tugas_Transaction.Models;
using API_Tugas_Transaction.Repositories.Interfaces;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace API_Tugas_Transaction.Repositories
{

    public class AccountRepository : IAccountRepository
    {
        readonly DynamicParameters parameters = new DynamicParameters();
        readonly SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString);

        public int Update(int id, Account account)
        {
            var spName = "SP_UpdatePassword";
            parameters.Add("@Id", id);
            parameters.Add("@Password", account.Password);

            var result = connection.Execute(spName, parameters, commandType: CommandType.StoredProcedure);

            return result;
        }
    }
}