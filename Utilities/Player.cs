using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Utilities
{
    public class Player
    {

        private int ID;
        public string Name { get; set; }
        public bool Captain { get; set; }
        public int ShirtNumber { get; set; }
        public string Position { get; set; }
        public bool Favorite { get; set; }

        public Player(string name, bool captain, int shirtNumber, string position)
        {
            Name = name;
            Captain = captain;
            ShirtNumber = shirtNumber;
            Position = position;
        }
    }
}
