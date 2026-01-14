using DataAccess.EfCore;
using DataAccess.Repositories.Abstracts;
using DataAccess.Repositories.Concretes.EFCore;
using DataAccess.UnitOfWork.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.UnitOfWork.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private readonly IProductRepository _productRepository;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public IProductRepository ProductRepository => _productRepository ?? new EFProductRepository(_context);

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
