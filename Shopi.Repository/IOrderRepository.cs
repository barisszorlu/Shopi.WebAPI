using Shopi.Models;
using Shopi.Repository.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shopi.Repository
{
    public interface IOrderRepository
    {
        Task<bool> Add(List<OrderEntity> entity);

        Task<List<OrderEntity>> Search(OrderFilterModel orderFilterModel);

        int Save();
    }

}
