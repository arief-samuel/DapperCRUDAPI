using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;

namespace DapperCRUDAPI.Models
{
    public class ProductRepository
    {
        private string connectionString;

        public ProductRepository()
        {
            connectionString= @"Data Source=DESKTOP-AG0G4RK\SQLEXPRESS;Initial Catalog=DAPPERDB;Integrated Security=True";
        }
        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(connectionString);
            }
        }
        public void Add(Product prod)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"INSERT INTO Products (Name,Quantity,Price) VALUES (@Name,@Quantity,@Price)";
                dbConnection.Open();
                dbConnection.Execute(sQuery, prod);
            }
        }

        public IEnumerable<Product> GetALL()
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"Select * FROM Products";
                dbConnection.Open();
                return dbConnection.Query<Product>(sQuery);
            }
        }
        public Product GetById(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"Select * FROM Products WHERE ProductId=@Id";
                dbConnection.Open();
                return dbConnection.Query<Product>(sQuery, new { Id = id }).FirstOrDefault();
            }
        }
        public void Delete (int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"DELETE * FROM Products WHERE ProductId=@Id";
                dbConnection.Open();
                dbConnection.Query<Product>(sQuery, new { Id = id });
            }
        }
        public void Update (Product prod)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"UPDATE Products SET (Name=@Name,Quantity=@Quantity,Price=@Price) WHERE ProductId=@ProductId";
                dbConnection.Open();
                dbConnection.Query(sQuery, prod);
            }
        }
    }
}
