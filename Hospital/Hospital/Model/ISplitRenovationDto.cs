using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Model
{
    public interface ISplitRenovationDto : IRenovationDto
    {
        uint NewArea { get; set; }

    }
}
