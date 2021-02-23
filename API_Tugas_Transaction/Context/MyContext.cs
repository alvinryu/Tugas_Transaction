using API_Tugas_Transaction.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace API_Tugas_Transaction.Context
{
    public class MyContext : DbContext
    {
        public MyContext() : base("myConnection")
        {

        }

        public DbSet<Employee> Employees { set; get; }

        public DbSet<Account> Accounts { set; get; }
    }
}