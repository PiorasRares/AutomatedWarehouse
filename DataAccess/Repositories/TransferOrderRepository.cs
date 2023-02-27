using DataAccess.DataContext;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class TransferOrderRepository
    {
        private readonly Context _context;
        public TransferOrderRepository(Context context)
        {
            _context= context;
        }

        public List<TransferOrder> GetTransferOrders(int containerId)
        {
            return _context.TransferOrders.Where(to => to.ToContainerId == containerId).ToList();
        }
        public void AddTransferOrder(TransferOrder item)
        {
            _context.TransferOrders.Add(item);
            var container = _context.Containers.Where(container=>container.Id==item.ToContainerId).First();
            var storageLocation = _context.StorageLocations.Where(location=>location.Id == container.StorageLocationId).First();
            storageLocation.TOToCount++;
            _context.StorageLocations.Update(storageLocation);
            _context.SaveChanges();
        }
    }
}
