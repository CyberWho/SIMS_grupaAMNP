using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Model
{
    public abstract class RenovationEnding
    {
        public Renovation EndRenovation(Renovation renovation, Repository.RenovationRepository repo)
        {
            renovation = ModifyEndedField(renovation);
            RoomsUpdate(renovation, new Repository.RoomRepository());
            return RenovationUpdate(renovation, repo);
        }

        protected Renovation ModifyEndedField(Renovation renovation)
        {
            renovation.Ended = true;
            return renovation;
        }

        protected abstract void RoomsUpdate(Renovation renovation, Repository.RoomRepository repo);

        protected Renovation RenovationUpdate(Renovation renovation, Repository.RenovationRepository repo)
        {
            return repo.UpdateRenovation(renovation);
        }
    }
}
