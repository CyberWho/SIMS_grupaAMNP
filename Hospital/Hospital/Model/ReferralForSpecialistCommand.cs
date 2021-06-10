using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Model
{
    class ReferralForSpecialistCommand : ICommand
    {
        private ReferralForSpecialist _referralForSpecialist;
        private Action _action;

        public ReferralForSpecialistCommand(ReferralForSpecialist referralForSpecialist, Action action)
        {
            this._referralForSpecialist = referralForSpecialist;
            this._action = action;
            ExecuteAction();
        }
        public void ExecuteAction()
        {
            switch (_action)
            {
                case Action.ADD:
                    _referralForSpecialist.CreateReferral();
                    break;
                case Action.DELETE:
                    _referralForSpecialist.DeleteReferral();
                    break;
                case Action.UPDATE:
                    _referralForSpecialist.Update();
                    break;
            }
        }
    }
}
