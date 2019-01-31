using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.Infrastructure.InMemory.Repositories
{
    public class BaseRepository
    {
        protected readonly Context _context;

        protected BaseRepository()
        {
            
        }
        public BaseRepository(Context context)
        {
            _context = context;
        }
    }
}
