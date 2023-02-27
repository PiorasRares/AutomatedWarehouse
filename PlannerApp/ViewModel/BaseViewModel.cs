using DataAccess.Model;
using PlannerApp.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlannerApp.ViewModel
{
    public class BaseViewModel : Adapter,INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public static DataAccess.Model.Container SelectedContainer { get; set; }
    }
}
