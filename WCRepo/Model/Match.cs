using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCRepo.Model
{
    public class Match
    {
        /*
         Create a ranking list of the number of visitors for a specific match - it is necessary to display the location, number of
visitors, the name of the host ("home_team") and the name of the guest ("away_team").
         */
        public string venue;
        public string location;
        public int numberOfVisitors;
        public string home_team_country;
        public string away_team_country;
    }
}
