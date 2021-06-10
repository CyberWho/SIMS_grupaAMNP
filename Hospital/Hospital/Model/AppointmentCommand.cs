using System;
using Hospital.Controller;


namespace Hospital.Model
{
    public class AppointmentCommand : ICommand
    {
        private Appointment _appointment;
        private Action _action;
        private DateTime _newStartTime;

        public AppointmentCommand(Appointment appointment,Action action)
        {
            _appointment = appointment;
            _action = action;
            ExecuteAction();
        }
        public AppointmentCommand(Appointment appointment, Action action,DateTime startTime)
        {
            _appointment = appointment;
            _action = action;
            _newStartTime = startTime;
            ExecuteAction();
        }

        public void ExecuteAction()
        {
            switch (_action)
            {
                case Action.ADD:
                    _appointment.CreateNewAppointment();
                    break;
                case Action.DELETE:
                    _appointment.DeleteAppointment();
                    break;
                case Action.UPDATE:
                    _appointment.UpdateAppointmentStartTime(_newStartTime);
                    break;
            }

        }
    }
}
