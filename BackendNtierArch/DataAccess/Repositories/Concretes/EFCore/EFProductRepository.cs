using Core.DataAccess.Repositories.Concrete.EFCore;
using DataAccess.EfCore;
using DataAccess.Repositories.Abstracts;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repositories.Concretes.EFCore
{
    public class EFProductRepository : EFBaseRepository<Product, AppDbContext>, IProductRepository
    {
        public EFProductRepository(AppDbContext context) : base(context)
        {
        }
    }
}
