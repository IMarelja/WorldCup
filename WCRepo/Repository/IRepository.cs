using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCRepo.Model;
using WCRepo.Models;
using System.Text.Json;

namespace WCRepo.Repository
{
    public interface IRepository
    {
        Player GetPlayer(int PlayerID, int TeamID, Gender group);
        ISet<Player> GetPlayers(int TeamID, Gender group);
        Team GetTeam(int TeamID, Gender group);
        ISet<Team> GetTeams(Gender group);
        Match GetMatch(int TeamID, Gender group);
        ISet<Match> GetMatches(int TeamID, Gender group);

        String GetDirectory();
    }
}
