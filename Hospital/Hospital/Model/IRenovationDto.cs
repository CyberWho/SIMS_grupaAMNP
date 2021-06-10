using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Model
{
    public interface IRenovationDto
    {
        int Id { get; set; }
        Renovation renovation { get; set; }
        string Type { get; set; }

        string Rooms { get; set; }
        string Ended { get; set; }
    }
}
