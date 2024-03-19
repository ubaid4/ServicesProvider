using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServicesProvider.Core.Domain.RepositoryInterfaces;
using ServicesProvider.Infrastructure.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesProvider.Infrastructure.Repositories
{
    public class GenericRepository<TEntity> : IGeneric<TEntity> where TEntity : class
    {
        private readonly AppDbContext _context;
        public GenericRepository(AppDbContext context) 
        {
        _context = context;
        }
        public virtual async Task<TEntity> Add(TEntity entity)
        {
            var res=(await  _context.Set<TEntity>().AddAsync(entity)).Entity;
            await _context.SaveChangesAsync();
            return res;
           
        }

        public virtual async Task<TEntity> Delete(TEntity Entity)
        {
           TEntity deletedItem=_context.Set<TEntity>().Remove(Entity).Entity;
            int count=await _context.SaveChangesAsync();
            return deletedItem;

        }

        public virtual async Task<List<TEntity>> GetAll()
        {
           return await _context.Set<TEntity>().ToListAsync();
        }

        public virtual async Task<TEntity> GetById(Guid Id)
        {
            return await _context.Set<TEntity>().FindAsync(Id);
        }


        public async virtual Task<TEntity> Update(TEntity entity)
        {
            //_context.Entry(entity).State = EntityState.Modified;
            TEntity UpdatedEntity = _context.Set<TEntity>().Update(entity).Entity;
            _context.SaveChanges();
            return UpdatedEntity;

        }
    }
}
