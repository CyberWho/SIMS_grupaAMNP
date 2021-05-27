using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;
using static Globals;

namespace Hospital.Model
{
    class DispatcherTimerForReservedItems
    {

        private DispatcherTimer dispatcherTimer;
        Controller.ReservedItemController reservedItemController;
        public DispatcherTimerForReservedItems()
        {
            dispatcherTimer = new DispatcherTimer();
            reservedItemController = new Controller.ReservedItemController();
            dispatcherTimer.Tick += dispatherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 1, 0);
            dispatcherTimer.Start();
        }

        private void dispatherTimer_Tick(object sender, EventArgs e)
        {
            ObservableCollection<ReservedItem> ReservedItems = reservedItemController.getAllReservedItems();
            DateTime now = DateTime.Now;
            now = now.AddMilliseconds(-now.Millisecond);
            foreach (ReservedItem reservedItem in ReservedItems)
            {
                if (((DateTime)reservedItem.ReservedDate - now).Minutes == 0)
                {
                    ShowInfoBox("Upravo se premešta jedan trajni item");
                    ItemInRoom FreshlyMovedItem = reservedItemController.MoveReservedItem(reservedItem);
                    ShowInfoBox("Uspešno premešten u sobu " + FreshlyMovedItem.room.Id);
                    
                    Thread.Sleep(58000);
                }
            }
        }
    }
}
