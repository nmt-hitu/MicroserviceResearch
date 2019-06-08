using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Ordering.API.Application.Queries
{
    public class ProductQueries : IProductQueries
    {
        private string _connectionString = string.Empty;

        public ProductQueries(string constr)
        {
            _connectionString = !string.IsNullOrWhiteSpace(constr) ? constr : throw new ArgumentNullException(nameof(constr));
        }

        public async Task<Product> GetProductBySKUAsync(string sku)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                return await connection.QueryFirstOrDefaultAsync<Product>(
                   @"select P.Id, P.SKU, P.Price as UnitPrice, p.ProductName
                        FROM Product P
                        WHERE P.SKU = @sku"
                        , new { sku }
                    );
            }
        }
    }
}
