using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Hospital.Model
{
    class ModifyAppointment
    {
        private ICommand _command;

        public ModifyAppointment()
        {
        }
        public void SetCommand(ICommand command) => _command = command;
        public void Invoke()
        {
            _command.ExecuteAction();
        }

    }
}
