using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Repository;

namespace Hospital.Model
{
    class RegularRenovationEnding : RenovationEnding
    {
        protected override void RoomsUpdate(Renovation renovation, RoomRepository repo){}
    }
}
