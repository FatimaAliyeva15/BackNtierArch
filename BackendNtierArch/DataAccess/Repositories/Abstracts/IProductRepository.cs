using Core.DataAccess.Repositories.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repositories.Abstracts
{
    public interface IProductRepository: IBaseRepository<Product>
    {
    }
}
