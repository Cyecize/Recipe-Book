using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecipeBook.Domain.Services
{
    public interface IDataService<TE, TId>
    {
        Task<List<TE>> GetAll();

        Task<TE> Find(TId id);

        Task<TE> Create(TE entity);

        Task<TE> Update(TE entity);

        Task<bool> Delete(TE entity);
    }
}
