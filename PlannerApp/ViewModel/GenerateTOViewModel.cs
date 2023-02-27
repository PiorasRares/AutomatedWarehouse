using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PlannerApp.ViewModel
{
    public class GenerateTOViewModel:BaseViewModel
    {
        private List<Material> materials { get; set; }
        public List<Material> Materials
        {
            get { return materials; }
            set
            {
                materials = value;
                OnPropertyChanged(nameof(Materials));
            }
        }
        private Material selectedMaterial { get; set; }
        public Material SelectedMaterial
        {
            get { return selectedMaterial; }
            set
            {
                selectedMaterial = value; 
                OnPropertyChanged(nameof(SelectedMaterial));
                TransferOrder.MaterialName = value.Name;
            }
        }
        private TransferOrder transferOrder { get; set; }
        public TransferOrder TransferOrder
        { 
            get { return transferOrder; } 
            set
            {
                transferOrder = value;
                OnPropertyChanged(nameof(TransferOrder));
            } 
        }
        private int quantity { get; set; }
        public int Quantity
        {
            get { return quantity; }
            set
            {
                quantity = value;
                OnPropertyChanged(nameof(Quantity));
                TransferOrder.OrderQuantity = value;
            }
        }
        public ICommand AddTo { get; private set; }
        public GenerateTOViewModel()
        {
            Materials = GetMaterials();
            TransferOrder = new TransferOrder { ToContainerId = SelectedContainer.Id, FromContainerId = 0 };
            AddTo = new Command(() =>
            {
                PostTransferOrder(TransferOrder);
                TransferOrder = new TransferOrder { ToContainerId = SelectedContainer.Id, FromContainerId = 0 };
                Quantity = 0;
                SelectedMaterial = new Material();
            });
        }

    }
}
