using DataAccess.Model;
using GalaSoft.MvvmLight.Command;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using System.Windows.Input;

namespace PickerApp.ViewModel
{
    public class MainWindowViewModel : BaseViewModel
    {
        //Storage Types
        private List<StorageType> warehouseStorageTypes { get; set; }
        public List<StorageType> WarehouseStorageTypes
        {
            get { return warehouseStorageTypes; }
            set
            {
                warehouseStorageTypes = value;
                OnPropertyChanged(nameof(WarehouseStorageTypes));
            }
        }
        private List<StorageType> productionStorageTypes { get; set; }
        public List<StorageType> ProductionStorageTypes
        {
            get { return productionStorageTypes; }
            set
            {
                productionStorageTypes = value;
                OnPropertyChanged(nameof(ProductionStorageTypes));
            }
        }
        private StorageType selectedWarehouse { get; set; }
        public StorageType SelectedWarehouse
        {
            get { return selectedWarehouse; }
            set
            {
                selectedWarehouse = value;
                OnPropertyChanged(nameof(SelectedWarehouse));
                WarehouseStorageLocations = GetStorageLocations(value.Id).Result;
            }
        }
        private StorageType selectedProduction { get; set; }
        public StorageType SelectedProduction
        {
            get { return selectedProduction; }
            set
            {
                selectedProduction = value;
                OnPropertyChanged(nameof(SelectedProduction));
                ProductionStorageLocations = GetStorageLocations(value.Id).Result;
            }
        }
        //Storage Location
        private List<StorageLocation> warehouseStorageLocations { get; set; }
        public List<StorageLocation> WarehouseStorageLocations
        {
            get { return warehouseStorageLocations; }
            set
            {
                warehouseStorageLocations = value;
                OnPropertyChanged(nameof(WarehouseStorageLocations));
            }
        }
        private List<StorageLocation> productionStorageLocations { get; set; }
        public List<StorageLocation> ProductionStorageLocations
        {
            get { return productionStorageLocations; }
            set
            {
                productionStorageLocations = value;
                OnPropertyChanged(nameof(productionStorageLocations));
            }
        }

        public MainWindowViewModel()
        {
            WarehouseStorageTypes = GetStorageType("Warehouse").Result;
            ProductionStorageTypes = GetStorageType("Production").Result;
        }
    }
}
