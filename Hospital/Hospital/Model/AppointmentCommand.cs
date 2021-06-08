using System;


namespace Hospital.Model
{
    public class AppointmentCommand : ICommand
    {
        private Appointment _appointment;
        private AppointmentAction _appointmentAction;
        private DateTime _newStartTime;

        public event EventHandler CanExecuteChanged;

        public AppointmentCommand(Appointment appointment,AppointmentAction appointmentAction)
        {
            _appointment = appointment;
            _appointmentAction = appointmentAction;
            ExecuteAction();
        }
        public AppointmentCommand(Appointment appointment, AppointmentAction appointmentAction,DateTime startTime)
        {
            _appointment = appointment;
            _appointmentAction = appointmentAction;
            _newStartTime = startTime;
            ExecuteAction();
        }

        public void ExecuteAction()
        {
            switch (_appointmentAction)
            {
                case AppointmentAction.ADD:
                    _appointment.CreateNewAppointment();
                    break;
                case AppointmentAction.DELETE:
                    _appointment.DeleteAppointment();
                    break;
                case AppointmentAction.UPDATE:
                    _appointment.UpdateAppointmentStartTime(_newStartTime);
                    break;
            }
        }


    }
}
