using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hockey.Model
{
    public class HockeyModel
    {
        private List<Team> teams = new List<Team>();
        private List<Player> players = new List<Player>();
        private List<TeamPlayer> teamPlayers = new List<TeamPlayer>();
        private List<DraftPosition> draftPositions = new List<DraftPosition>();
        private List<Point> points = new List<Point>();
        private List<Game> games = new List<Game>();
        private List<GamePlayer> gamePlayers = new List<GamePlayer>();

        public void AddTeam(Team team)
        {
            team.Id = teams.Count + 1;
            teams.Add(team);
        }

        public void AddPlayer(Player player)
        {
            player.Id = players.Count + 1;
            players.Add(player);
        }

        public IEnumerable<Team> Teams { get { return teams; } }
        public IEnumerable<Player> Players { get { return players; } }
    }
}
