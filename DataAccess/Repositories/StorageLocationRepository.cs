using DataAccess.DataContext;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class StorageLocationRepository:BaseRepository
    {
        public StorageLocationRepository(Context context) : base(context)
        {
        }

        public List<StorageLocation> GetStorageLocations(int storageTypeId)
        {
            return _context.StorageLocations.Where(location => location.StorageTypeId == storageTypeId).ToList();
        }
    }
}
