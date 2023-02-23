using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Model;

namespace PlannerApp.ViewModel
{
    public class OrdersViewModel:BaseViewModel
    {
        private List<StorageType> storageTypes { get; set; }
        public List<StorageType> StorageTypes
        {
            get { return storageTypes; }
            set
            {
                storageTypes = value;
                OnPropertyChanged(nameof(StorageTypes));
            }
        }
        private StorageType selectedStorageType { get; set; }
        public StorageType SelectedStorageType
        {
            get { return selectedStorageType; }
            set
            {
                selectedStorageType = value;
                OnPropertyChanged(nameof(SelectedStorageType));
                StorageLocations = GetStorageLocations(value.Id);
            }
        }
        private List<StorageLocation> storageLocations { get; set; }
        public List<StorageLocation> StorageLocations
        {
            get { return storageLocations; }
            set
            {
                storageLocations = value;
                OnPropertyChanged(nameof(StorageLocations));
            }
        }
        public OrdersViewModel()
        {
            StorageTypes = GetStorageTypes("Production");
        }
    }
}
