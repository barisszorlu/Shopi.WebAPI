using Microsoft.EntityFrameworkCore.Storage;
using Shopi.Models;
using Shopi.Repository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Shopi.Repository
{
    public class OrderRepository : IOrderRepository, IUnitOfWork
    {
        protected readonly MemoryDBContext _context;
        IDbContextTransaction _transaction = null;
        public OrderRepository(MemoryDBContext context)
        {
            _context = context;
            _transaction = _context.Database.BeginTransaction();
        }

        public async Task<bool> Add(List<OrderEntity> entity)
        {
            try
            {
                _context.Order.AddRange(entity);
                Commit();
                return true;
            }
            catch (Exception ex)
            {
                Commit(false);
                throw new Exception("Ekleme işlemi sırasında bir hata oluştu. " + ex.Message);
            }
        }

        public Task<List<OrderEntity>> Search(OrderFilterModel orderFilterModel)
        {
            try
            {
                var pageSize = 25;
                var list = _context.Order.Skip((orderFilterModel.PageNumber - 1) * pageSize).Take(orderFilterModel.PageSize).ToList();

                if (list.Count > 0)
                {
                    if (!String.IsNullOrEmpty(orderFilterModel.SearchText))
                    {
                        list = list.Where(x => x.StoreName.Contains(orderFilterModel.SearchText) || x.CustomerName.Contains(orderFilterModel.SearchText)).ToList();
                    }

                    if (orderFilterModel.StartDate != null)
                    {
                        list = list.Where(x => x.CreatedOn >= orderFilterModel.StartDate).ToList();
                    }

                    if (orderFilterModel.EndDate != null)
                    {
                        list = list.Where(x => x.CreatedOn <= orderFilterModel.EndDate).ToList();
                    }

                    if (orderFilterModel.Statuses.Count > 0)
                    {
                        var filterEnumValues = orderFilterModel.Statuses.Cast<int>().ToList();
                        list = list.Where(x => filterEnumValues.Contains(x.Status)).ToList();
                    }
                }
                return Task.FromResult<List<OrderEntity>>(list);
            }
            catch (Exception ex)
            {
                throw new Exception("Filtreme işlemi sırasında bir hata oluştu. " + ex.Message);
            }

        }

        public int Save() { return _context.SaveChanges(); }

        public bool Commit(bool state = true)
        {

            if (state)
            {
                Save();
                _transaction.Commit();
            }
            else
                _transaction.Rollback();

            Dispose();
            return true;

        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}

