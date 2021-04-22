using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Model
{
    class ItemInRoomDTO
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public uint Quantity { get; set; }

        public uint Price { get; set; }

        public string Unit { get; set; }

        public string Type { get; set; }

        public ItemInRoomDTO() { }

    }
}
