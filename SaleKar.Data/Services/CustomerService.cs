using Dapper;
using SaleKar.Core.Interfaces;
using SaleKar.Core.Models;
using SaleKar.Data.Db;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleKar.Data.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public CustomerService(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            using IDbConnection conn = _connectionFactory.CreateConnection();
            // Example: call proc
            return await conn.QueryAsync<Customer>(
                "GetAllCustomers", commandType: CommandType.StoredProcedure);
        }

        public async Task<Customer?> GetByIdAsync(int id)
        {
            using IDbConnection conn = _connectionFactory.CreateConnection();
            string sql = "SELECT Id, Name, Email FROM Customers WHERE Id = @Id";
            return await conn.QueryFirstOrDefaultAsync<Customer>(sql, new { Id = id });
        }

        public async Task AddAsync(Customer customer)
        {
            using IDbConnection conn = _connectionFactory.CreateConnection();
            string sql = "INSERT INTO Customers (Name, Email) VALUES (@Name, @Email)";
            await conn.ExecuteAsync(sql, customer);
        }
    }
}
