using Hockey.Model;
using HtmlAgilityPack;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hockey.Utility;


/*
 * I'm expecting to throw Import Player Methods into the child class'.
 * */

namespace Hockey.Loaders
{
    public abstract class AHockeyLoader
    {
        protected readonly HockeyModel hockeyModel;
        public AHockeyLoader(HockeyModel hm)
        {
            hockeyModel = hm;
        }

        private static readonly ILog Log = LogManager.GetLogger(typeof(AHockeyLoader));

        public void ImportData()
        {
            Log.InfoFormat("#### Import of {0} starting #####", LeagueName);
            ImportTeams();
            ImportPlayers();
            ImportGames();
        }

        public void ImportPlayersFromRoster(HtmlDocument rosterPage, Team team)
        {
            var rosterList = rosterPage.DocumentNode.SelectSingleNode(
                "//div[@id='rosterBlock']"
                );
            
            var rosterTables = rosterList.SelectNodes(
                ".//tbody"
                );
            int i = 1;
            foreach (var tBodyNode in rosterTables)
            {
                Log.DebugFormat("----------------------{0} Players of One Position (Forward/Goalie/Defense)------------------------\n{1}", team.Name, tBodyNode.InnerHtml);

                var trNodes = tBodyNode.SelectNodes("tr");
                foreach (var trNode in trNodes)
                {
                    ImportPlayer(trNode, team);
                }
                
                if (i >= 3) break;
                i++;
            }
            
        }

        private void ImportPlayer(HtmlNode trNode, Team team)
        {

            var tdNodes = trNode.SelectNodes("td");

            Log.InfoFormat("Creating Player Object For {0}", tdNodes[1].InnerText);
            Player player = new Player()
            {
                JerseyNumber = int.Parse(tdNodes[0].InnerText),
                Name = tdNodes[1].InnerText,
                Position = tdNodes[2].InnerText,
                Handedness = tdNodes[3].InnerText[0],
                Height = Conversions.HeightMixedImperialtoInches(tdNodes[4].InnerText),
                Weight = Conversions.SafeParseInt(tdNodes[5].InnerText, 0),
                DateOfBirth = Conversions.DateStringToDateTimeMmmDYyyy(tdNodes[6].InnerText),
                BirthPlace = tdNodes[7].InnerText
            };
            hockeyModel.AddPlayer(player);
            Log.DebugFormat("player: {0}", player);

            TeamPlayer teamPlayer = new TeamPlayer()
            {
                StartDate = DateTime.Now,
                EndDate = null,
                PlayerId = player.Id,
                TeamId = team.Id
            };
            hockeyModel.AddTeamPlayer(teamPlayer);
            Log.DebugFormat("teamPlayer: {0}", teamPlayer);

        }

        protected abstract void ImportPlayers();
        protected abstract void ImportTeams();
        protected abstract void ImportGames();
        protected abstract string LeagueName{get;}

    }
}
