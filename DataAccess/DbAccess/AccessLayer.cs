using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DbAccess
{
    public class AccessLayer
    {
        private Context db { get; set; }
        public AccessLayer()
        {
            db = new Context();
            db.Database.EnsureCreated();
        }
        public List<StorageType> GetStorageTypes(string description)
        {
            return db.StorageTypes.Where(type=>type.Description == description).ToList();
        }
        public List<StorageLocation> GetStorageLocations(int storageTypeId)
        {
            return db.StorageLocations.Where(location=>location.StorageTypeId == storageTypeId).ToList();
        }
        public List<Container> GetContainers(int storageLocationId)
        {
            return db.Containers.Where(container=>container.StorageLocationId == storageLocationId).ToList();
        }
        public List<Material> GetMaterials(int containerId)
        {
            return db.Materials.Where(material=>material.ContainerId== containerId).ToList();
        }
        public List<TransferOrder> GetTransferOrders(int storageLocationId)
        {
            return db.TransferOrders.Where(to=>to.ToContainerId == storageLocationId).ToList();
        }
    }
}
