using System.Collections.Generic;
using System.Threading.Tasks;

namespace TodoApp.Application.CommonInterfaces
{
    public interface IListable<TEntity>
    {
        Task<ICollection<TEntity>> ListAll();
    }
}