using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Model
{
    public class Executer
    {
        private IEntity _iEntity;
        private Modify _modify;
        private ICommand _iCommand;

        public Executer(IEntity iEntity, Modify modify, ICommand iCommand)
        {
            modify.SetCommand(iCommand);
            modify.Invoke();
        }
    }
}
