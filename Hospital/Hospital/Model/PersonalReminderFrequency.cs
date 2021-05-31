using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Model
{
    public enum PersonalReminderFrequency
    {
        [Description("Samo jednom")]
        ONLY_ONCE,
        [Description("Svaki dan")]
        DAILY,
        [Description("Jednom nedeljno")]
        WEEKLY
    }
}
