using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Hospital.Model;

namespace Hospital.xaml_windows.Doctor
{
    /// <summary>
    /// Interaction logic for Report.xaml
    /// </summary>
    public partial class Report : Window
    {
        private HealthRecord _healthRecord;
        private ObservableCollection<Appointment> _appointments;
        private Model.Patient _patient;
        private int margin_a = 30;
        public Report(HealthRecord hr, ObservableCollection<Appointment> aps, Model.Patient pt)
        {
            InitializeComponent();
            this._healthRecord = hr;
            this._appointments = aps;
            this._patient = pt;

            tb_name.Text = _patient.User.Name + " " + _patient.User.Surname;

            tb_date.Text = DateTime.Now.ToString();

            foreach (Appointment ap in _appointments)
            {
                String str = "";

                switch (ap.Type)
                {
                    case AppointmentType.EXAMINATION:
                        str = "Pregled";
                        break;
                    case AppointmentType.OPERATION:
                        str = "Operacija";
                        break;
                    case AppointmentType.REFERRAL:
                        str = "Uput";
                        break;
                }

                

                fillAppointment_lv_termini(str, ap.StartTime.ToShortDateString(), getSelectedAnamnesisDescription(ap.Id));


            }
            
            foreach (Anamnesis an in _healthRecord.anamnesis)
            {
                if (an.Perscriptions == null)
                    break;
                foreach (Perscription pe in an.Perscriptions)
                {
                    fillDrug_lv_lekovi(pe.Drug.Name.ToString(), pe.Description);
                }
            }

        }

        public void fillDrug_lv_lekovi(string s1, string s2)
        {

            Grid newGrid = new Grid();
            newGrid.Margin = new Thickness(10, 0, 10, 0);
            newGrid.HorizontalAlignment = HorizontalAlignment.Stretch;
            newGrid.Width = 420;

            ColumnDefinition c1 = new ColumnDefinition();
            c1.Width = new GridLength(1, GridUnitType.Star);
            newGrid.ColumnDefinitions.Add(c1);

            ColumnDefinition c2 = new ColumnDefinition();
            c2.Width = new GridLength(1, GridUnitType.Star);
            newGrid.ColumnDefinitions.Add(c2);


            RowDefinition gridRow1 = new RowDefinition();

            TextBlock t1 = new TextBlock();
            t1.Text = s1;
            t1.FontSize = 15;
            Grid.SetColumn(t1, 0);
            Grid.SetRow(t1, 0);

            newGrid.Children.Add(t1);

            int a = 15;
            string tmp = "";
            for (int i = 0; i < s2.Length; i++)
            {
                a--;
                if (s2[i].Equals(' ') && a < 0)
                {
                    tmp += '\n';
                    a = 15;
                }
                else
                {
                    tmp += s2[i];
                }
            }

            TextBlock t2 = new TextBlock();
            t2.Text = tmp;
            t2.FontSize = 15;
            Grid.SetColumn(t2, 1);
            Grid.SetRow(t2, 0);

            newGrid.Children.Add(t2);

            ListViewItem lvi = new ListViewItem();
            lvi.Width = 440;
            lvi.Content = newGrid;
            lv_lekovi.Items.Add(lvi);


        }

        public void fillAppointment_lv_termini(string s1, string s2, string s3)
        {
            Grid newGrid = new Grid();
            newGrid.Margin = new Thickness(10, 0, 10, 0);
            newGrid.HorizontalAlignment = HorizontalAlignment.Stretch;
            newGrid.Width = 420;

            ColumnDefinition c1 = new ColumnDefinition();
            c1.Width = new GridLength(1, GridUnitType.Star);
            newGrid.ColumnDefinitions.Add(c1);

            ColumnDefinition c2 = new ColumnDefinition();
            c2.Width = new GridLength(1, GridUnitType.Star);
            newGrid.ColumnDefinitions.Add(c2);

            ColumnDefinition c3 = new ColumnDefinition();
            c3.Width = new GridLength(2, GridUnitType.Star);
            newGrid.ColumnDefinitions.Add(c3);

            RowDefinition gridRow1 = new RowDefinition();

            TextBlock t1 = new TextBlock();
            t1.Text = s1;
            t1.FontSize = 15;
            Grid.SetColumn(t1, 0);
            Grid.SetRow(t1, 0);

            newGrid.Children.Add(t1);

            TextBlock t2 = new TextBlock();
            t2.Text = s2;
            t2.FontSize = 15;
            Grid.SetColumn(t2, 1);
            Grid.SetRow(t2, 0);

            newGrid.Children.Add(t2);
            int a = 15;
            string tmp = "";
            for (int i = 0; i < s3.Length; i++)
            {
                a--;
                if (s3[i].Equals(' ') && a < 0)
                {
                    tmp += '\n';
                    a = 15;
                }
                else
                {
                    tmp += s3[i];
                }


            }


            TextBlock t3 = new TextBlock();
            t3.Text = tmp;
            t3.FontSize = 15;
            Grid.SetColumn(t3, 2);
            Grid.SetRow(t3, 0);

            newGrid.Children.Add(t3);

            ListViewItem lvi = new ListViewItem();
            lvi.Width = 440;
            lvi.Content = newGrid;
            lv_termini.Items.Add(lvi);
        }

        private String getSelectedAnamnesisDescription(int selected_appointment_id)
        {
            Anamnesis selected_anamensis = null;
            foreach (Anamnesis anamnesis in _healthRecord.anamnesis)
                if (anamnesis.appointment.Id == selected_appointment_id)
                {
                    selected_anamensis = anamnesis;
                    return anamnesis.Description;
                }

            return "Nema anamneze";
        }

    }


}
