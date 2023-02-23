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

        public List<TransferOrder> GetTransferOrders(int storageLocationId)
        {
            return _context.TransferOrders.Where(to => to.ToContainerId == storageLocationId).ToList();
        }
    }
}
