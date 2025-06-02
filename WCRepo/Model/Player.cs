using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCRepo.Models
{
    public class Player
    {
        // All players can be retrieved from the data on the first played match as a union of the "starting_eleven" and "substitutes" sets.
         
        /*json*/
        public string name { get; set; }
        public bool captain { get; set; }
        public int shirt_number { get; set; }
        public string position { get; set; }

        /*memory*/
        public int id { get; set; }
        public bool favorite { get; set; }
        public string picturePath { get; set; }

        /*match*/
        public int goalsInMatch { get; set; }
        public int yellowCardsInMatch { get; set; }

        /*all*/

        public int goalsInAll {  get; set; }
        public int yellowCardsInAll { get; set ; }
    }
}
