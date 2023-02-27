using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DataAccess.Model;
using PlannerApp.View;

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
        private StorageLocation selectedStorageLocation { get; set; }
        public StorageLocation SelectedStorageLocation
        {
            get { return selectedStorageLocation; }
            set
            {
                selectedStorageLocation = value;
                OnPropertyChanged(nameof(SelectedStorageLocation));
                SelectedContainer = GetContainer(value.Id);
                GoTo();
            }
        }
        private async Task GoTo()
        {
            await Shell.Current.GoToAsync(nameof(GenerateTO));
        }

        public OrdersViewModel()
        {
            StorageTypes = GetStorageTypes("Production");
        }
    }
}
