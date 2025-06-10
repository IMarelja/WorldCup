using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moduls
{
    public class Result
    {
        public int id {  get; set; }
        public int wins { get; set; }
        public int draws { get; set; }
        public int losses { get; set; }
        public int games_player { get; set; }
        public int points { get; set; }
        public int goals_for {  get; set; }
        public int goals_against { get; set; }
        public int goal_differential {  get; set; }
    }
}
