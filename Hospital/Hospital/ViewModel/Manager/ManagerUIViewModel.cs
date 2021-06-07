using Hospital.ViewModel.Patient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Hospital.ViewModel.Manager
{
    class ManagerUIViewModel : BindableBase
    {
        Window currentWindow { get; set; }
        public MyICommand Rooms { get; set; }
        public MyICommand Drugs { get; set; }
        public MyICommand InventorySearch { get; set; }
        public MyICommand Renovations { get; set; }
        public MyICommand Report { get; set; }
        public MyICommand LogOut { get; set; }
        public MyICommand Help { get; set; }
        private BindableBase currentViewModel;
        public BindableBase CurrenctViewModel
        {
            get { return currentViewModel; }
            set { SetProperty(ref currentViewModel, value); }
        }
        public ManagerUIViewModel() { }
        public ManagerUIViewModel(Window window)
        {
            currentWindow = window;
            InstanceMyCommands();
        }

        private void InstanceMyCommands()
        {
            Rooms = new MyICommand(OnRooms);
            Drugs = new MyICommand(OnDrugs);
            InventorySearch = new MyICommand(OnInventorySearch);
            Renovations = new MyICommand(OnRenovations);
            Report = new MyICommand(OnReport);
            LogOut = new MyICommand(OnLogOut);
            Help = new MyICommand(OnHelp);
        }

        private void OnRooms()
        {
            Window newWindow = new View.Manager.RoomsCRUDView();
            newWindow.Show();
            currentWindow.Close();
        }
        private void OnDrugs()
        {
            Window newWindow = new xaml_windows.Manager.ManagerDrugs();
            newWindow.Show();
            currentWindow.Close();
        }
        private void OnInventorySearch()
        {
            Window newWindow = new xaml_windows.Manager.ManagerInventorySearch();
            newWindow.Show();
            currentWindow.Close();
        }
        private void OnRenovations()
        {
            Window newWindow = new xaml_windows.Manager.ManagerRenovations();
            newWindow.Show();
            currentWindow.Close();
        }
        private void OnReport()
        {
            Window newWindow = new xaml_windows.Manager.Report();
            newWindow.Show();
            currentWindow.Close();
        }
        private void OnLogOut()
        {
            Window newWindow = new MainWindow();
            newWindow.Show();
            currentWindow.Close();
        }
        private void OnHelp()
        {
            string str = "ManagerUIHelp";
            System.Diagnostics.Process.Start("C:/Users/Pedja/source/repos/SIMS_grupaAMNP/Hospital/Hospital/Help/ManagerUIHelp.html");
        }
    }
}
