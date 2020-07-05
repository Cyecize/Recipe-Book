using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RecipeBook.Domain.Services;

namespace RecipeBook.EntityFramework.Services
{
    public class DataService<TEntity, TId> : IDataService<TEntity, TId> where TEntity : class
    {
        private readonly RecipeBookDbContextFactory _factory;

        public DataService(RecipeBookDbContextFactory factory)
        {
            this._factory = factory;
        }

        public async Task<List<TEntity>> GetAll()
        {
            await using RecipeBookDbContext context = this._factory.CreateDbContext();
            return await context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> Find(TId id)
        {
            await using RecipeBookDbContext context = this._factory.CreateDbContext();
            return await context.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity> FindOneBy(Expression<Func<TEntity, bool>> predicate)
        {
            await using RecipeBookDbContext context = this._factory.CreateDbContext();
            return await context.Set<TEntity>().FirstOrDefaultAsync(predicate);
        }

        public async Task<List<TEntity>> FindBy(Func<TEntity, bool> predicate)
        {
            await using RecipeBookDbContext context = this._factory.CreateDbContext();
            return context.Set<TEntity>().Where(predicate).ToList();
        }

        public async Task<TEntity> Create(TEntity entity)
        {
            await using RecipeBookDbContext context = this._factory.CreateDbContext();
            var newEntry = await context.Set<TEntity>().AddAsync(entity);
            await context.SaveChangesAsync();

            return newEntry.Entity;
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            await using RecipeBookDbContext context = this._factory.CreateDbContext();
            context.Set<TEntity>().Update(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> Delete(TEntity entity)
        {
            await using RecipeBookDbContext context = this._factory.CreateDbContext();
            context.Set<TEntity>().Remove(entity);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
