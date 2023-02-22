using DataAccess.DataContext;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class StorageTypeRepository: BaseRepository
    {
        public StorageTypeRepository(Context context) : base(context)
        {
        }

        public List<StorageType> GetStorageTypes(string description)
        {
            return _context.StorageTypes.Where(type => type.Description == description).ToList();
        }

    }
}
