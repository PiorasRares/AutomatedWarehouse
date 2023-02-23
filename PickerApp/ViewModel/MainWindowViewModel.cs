using DataAccess.Model;
using GalaSoft.MvvmLight.Command;
using Microsoft.Identity.Client;
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
        private StorageLocation selectedWarehouseStorageLocation { get; set; }
        public StorageLocation SelectedWarehouseStorageLocation
        {
            get { return selectedWarehouseStorageLocation; }
            set
            {
                selectedWarehouseStorageLocation = value;
                OnPropertyChanged(nameof(SelectedWarehouseStorageLocation));
                if(value!= null)
                {
                    Matt = new Material { Name = "N/a", Quantity = 0 };
                    Containers = GetContainer(value.Id).Result;
                }
                else
                {
                    Containers = new List<DataAccess.Model.Container>();
                }
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
        //Container
        private List<DataAccess.Model.Container> containers { get; set; }
        public List<DataAccess.Model.Container> Containers
        {
            get { return containers; }
            set
            {
                containers = value;
                OnPropertyChanged(nameof(Containers));
                if (value != null)
                {
                    value.ForEach(container =>
                    {
                        var materials = GetMaterials(container.Id).Result;
                        if (materials.Count > 0)
                        {
                            Matt.Name = materials[0].Name;
                            materials.ForEach(m =>
                            {
                                if (m != null)
                                    Matt.Quantity += m.Quantity;
                            });
                        }
                    });
                    OnPropertyChanged(nameof(Matt));
                }
            }
        }
        //Materials
        private Material material { get; set; }
        public Material Matt
        {
            get { return material; }
            set
            {
                material = value;
            }
        }
        //Transfer Orders
        private List<TransferOrder> transferOrders { get; set; }
        public List<TransferOrder> TransferOrders
        {
            get { return transferOrders;}
            set
            {
                transferOrders = value;
                OnPropertyChanged(nameof(TransferOrders));
            }
        }

        public MainWindowViewModel()
        {
            WarehouseStorageTypes = GetStorageType("Warehouse").Result;
            ProductionStorageTypes = GetStorageType("Production").Result;
        }
    }
}
