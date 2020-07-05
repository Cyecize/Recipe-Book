using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecipeBook.Domain.Services
{
    public interface IDataService<TEntity, TId> where TEntity : class
    {
        Task<List<TEntity>> GetAll();

        Task<TEntity> Find(TId id);

        Task<TEntity> FindOneBy(Func<TEntity, bool> predicate);

        Task<List<TEntity>> FindBy(Func<TEntity, bool> predicate);

        Task<TEntity> Create(TEntity entity);

        Task<TEntity> Update(TEntity entity);

        Task<bool> Delete(TEntity entity);
    }
}
