using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ordering.API.Application.Queries
{
    public interface IProductQueries
    {
        Task<Product> GetProductBySKUAsync(string sku);
    }
}
