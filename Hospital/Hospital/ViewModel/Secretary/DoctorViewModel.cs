using Hospital.Controller;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Hospital.View.Secretary;
using Hospital.xaml_windows.Secretary;
using Xceed.Wpf.Toolkit.Core;

namespace Hospital.ViewModel.Secretary
{
    public class DoctorViewModel : BindableBase
    {
        private Window thisWindow;
        public ObservableCollection<Model.Doctor> doctors { get; set; }
        public Model.Doctor selectedtDoctor { get; set; }

        private DoctorController doctorController = new DoctorController();

        

        private UserController userController = new UserController();
        private EmployeeController employeeController = new EmployeeController();

        private SpecializationContoller specializationContoller = new SpecializationContoller();
        private string specialization;
        private RoomController roomController = new RoomController();
        private int room_id;

        private int current_doctor_id;

        public MyICommand addDoctorCommand { get; set; }
        public MyICommand openDoctorCommand { get; set; }


        #region NotifyProperties

        public Model.Doctor SelectedDoctor
        {
            get { return selectedtDoctor; }
            set
            {
                selectedtDoctor = value;
                openDoctorCommand.RaiseCanExecuteChanged();
            }
        }

        #endregion
        #region PropertyChangedNotifier
        #endregion

        public DoctorViewModel()
        {
            this.doctors = this.doctorController.GetAllDoctors();
            this.addDoctorCommand = new MyICommand(Add_user);
            this.openDoctorCommand = new MyICommand(Open_doctor, Can_open);
            
        }

        private void Add_user()
        {
            Window s = new DoctorProfileView(null);
            s.Show();
        }

        private bool Can_open()
        {
            return this.selectedtDoctor != null;
        }

        private void Open_doctor()
        {
            Window s = new DoctorProfileView(selectedtDoctor);
            s.Show();
        }

    }
}
