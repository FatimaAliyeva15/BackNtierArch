using DataAccess.Repositories.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.UnitOfWork.Abstract
{
    public interface IUnitOfWork
    {
        public IProductRepository ProductRepository { get; }
        public Task<int> SaveAsync();
    }
}
