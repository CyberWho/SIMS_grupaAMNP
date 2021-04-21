using Hospital.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Hospital.Controller;
using System.Collections.ObjectModel;
using Hospital.Model;

namespace Hospital.xaml_windows.Doctor
{
    /// <summary>
    /// Interaction logic for Schedule.xaml
    /// </summary>
    public partial class Schedule : Window
    {
        private int id { set; get; }
        private int id_doc { set; get; }
        private AppointmentController appointmentContoller = new AppointmentController();
        private PatientController patientController = new PatientController();
        private ObservableCollection<Appointment> appointments;

        public Schedule(int id, int id_doc)
        {
            InitializeComponent();
            this.id = id;
            this.id_doc = id_doc;
            appointments = appointmentContoller.GetAllAppointmentsByDoctorId(this.id_doc);
            foreach (Appointment ap in appointments)
            {
               // MessageBox.Show(ap.Patient_Id.ToString());
                ListBoxItem itm = new ListBoxItem();
                ap.patient = patientController.GetPatientById(ap.Patient_Id);

                itm.Content = ap.Id.ToString() + "/" + ap.Patient_Id.ToString() + " " + ap.patient.User.Name + " " + ap.StartTime;

                lb_appointments.Items.Add(itm);

               

            }

        }


        void PrintText(object sender, SelectionChangedEventArgs args)
        {
            more_info.Text = "";
            ListBoxItem lbi = ((sender as ListBox).SelectedItem as ListBoxItem);
            if (lbi != null)
            {
                int id_patient_split = int.Parse((lbi.Content.ToString().Split(' '))[0].Split('/')[1]);
                //more_info.Text += id_pat.ToString();
                foreach(Appointment ap in appointments)
                    if(ap.Patient_Id == id_patient_split)
                    {
                        more_info.Text += ap.patient.User.Name + " " +
                                          ap.patient.User.Surname + "\n" +
                                          ap.patient.JMBG + "\n" +
                                          ap.patient.DateOfBirth + "\n" +
                                          ap.patient.User.PhoneNumber + "\n" +
                                          ap.patient.User.EMail;
                        break;
                    }
            }
            else
            {
                more_info.Text = "";
            }
        }


        private void ReturnOption(object sender, RoutedEventArgs e)
        {
            Window s = new DoctorUI(this.id);
            s.Show();
            this.Close();
        }
    }
}
