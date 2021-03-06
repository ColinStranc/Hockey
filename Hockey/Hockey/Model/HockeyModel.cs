﻿using System;
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

        public void AddTeamPlayer(TeamPlayer teamPlayer)
        {
            teamPlayer.Id = teamPlayers.Count + 1;
            teamPlayers.Add(teamPlayer);
        }

        public void AddGame(Game game)
        {
            game.Id = games.Count + 1;
            games.Add(game);
        }

        public Team GetTeam(string teamName)
        {
            foreach (Team team in teams) 
            {
                if (team.Name == teamName)
                {
                    return team;
                }
            }
            throw new Exception("Team name does not match any teams: " + teamName);
        }
        
        /* GetTeamIdFromPartialName and GetTeam to be merged */

        public int GetTeamIdFromPartialName(string partialTeamName)
        {
            foreach(Team team in teams)
            {
                
                bool isTeam = true;

                if (partialTeamName.Length > team.Name.Length)
                {
                    isTeam = false;
                }
                else
                {
                    for (int i = 0; i < partialTeamName.Length; i++)
                    {
                        if (team.Name[i] != partialTeamName[i])
                        {
                            isTeam = false;
                            break;
                        }
                    }
                }

                if (isTeam == true)
                {
                    return team.Id;
                }
                
            }
            throw new Exception("Team name does not match any teams: " + partialTeamName);
        }
        public IEnumerable<Team> Teams { get { return teams; } }
        public IEnumerable<Player> Players { get { return players; } }
        public IEnumerable<TeamPlayer> TeamPlayers { get { return teamPlayers; } }
        public IEnumerable<Game> Games { get { return games; } }

    }
}
