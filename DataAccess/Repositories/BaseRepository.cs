using DataAccess.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class BaseRepository
    {
        public Context _context;
        public BaseRepository(Context context)
        {
            _context= context;
        }
    }
}
