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
        public MainWindowViewModel()
        {
            WarehouseStorageTypes = GetStorageType("Warehouse").Result;
        }
    }
}
