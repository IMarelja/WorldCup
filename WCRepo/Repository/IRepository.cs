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
        // Players
        Player GetPlayer(int PlayerID, int TeamID, Gender group);
        ISet<Player> GetPlayers(int TeamID, Gender group);


        //Teams
        Team GetTeam(int TeamID, Gender group);
        ISet<Team> GetTeams(Gender group);


        //Matches
        Match GetMatch(string MatchID, Gender group);
        Match GetMatchByTeamID(int TeamID, Gender group);
        ISet<Match> GetMatches(Gender group);
        ISet<Match> GetMatchesByTeam(int TeamID, Gender group);
        Match GetMatchBetweenTeams(int Team1ID, int Team2ID, Gender group);


        //Results
        Result GetResult(int TeamID, Gender group);
        ISet<Result> GetResults(Gender group);


        //Other

        String GetDirectory();
        
    }
}
