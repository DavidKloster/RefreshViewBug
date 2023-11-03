
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RefreshViewBug
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public bool IsRefreshing { get; set; }

        public DemoDataSet[] DemoData {get; set; }

        public ICommand RefreshCommand => new Command(execute: async () =>
     {
         IsRefreshing = true;
         await Task.Delay(1000);
         DemoData = new DemoDataSet[]{new DemoDataSet(){ Data = "demo"},new DemoDataSet(){ Data = "demo"},new DemoDataSet(){ Data = "demo"},new DemoDataSet(){ Data = "demo"} };
         IsRefreshing = false;
         this.OnPropertyChanged(nameof(IsRefreshing));
           this.OnPropertyChanged(nameof(DemoData));

     }, canExecute: () =>
     {
         return !IsRefreshing;
     });
    }

    public class DemoDataSet
    {
        public string? Data{get;set; }
    }
}
