using DataAccess.DataContext;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class StorageTypeRepository
    {
        private readonly Context _context;
        public StorageTypeRepository(Context context)
        {
            _context = context;
        }
        public List<StorageType> GetStorageTypes(string description)
        {
            return _context.StorageTypes.Where(type => type.Description == description).ToList();
        }

    }
}
