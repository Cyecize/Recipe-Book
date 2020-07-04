using System.Collections.Generic;
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
            using (RecipeBookDbContext context = this._factory.CreateDbContext())
            {
                return await context.Set<TEntity>().ToListAsync();
            }
        }

        public async Task<TEntity> Find(TId id)
        {
            using (RecipeBookDbContext context = this._factory.CreateDbContext())
            {
                return await context.Set<TEntity>().FindAsync(id);
            }
        }

        public async Task<TEntity> Create(TEntity entity)
        {
            using (RecipeBookDbContext context = this._factory.CreateDbContext())
            {
                var newEntry = await context.Set<TEntity>().AddAsync(entity);
                await context.SaveChangesAsync();

                return newEntry.Entity;
            }
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            using (RecipeBookDbContext context = this._factory.CreateDbContext())
            {
                context.Set<TEntity>().Update(entity);
                await context.SaveChangesAsync();
                return entity;
            }
        }

        public async Task<bool> Delete(TEntity entity)
        {
            using (RecipeBookDbContext context = this._factory.CreateDbContext())
            {
                context.Set<TEntity>().Remove(entity);
                await context.SaveChangesAsync();
                return true;
            }
        }
    }
}
