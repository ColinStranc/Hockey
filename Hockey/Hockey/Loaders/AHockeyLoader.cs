using Hockey.Model;
using HtmlAgilityPack;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hockey.Utility;

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
            ImportPlayers();
            ImportTeams();
            //ImportTeamPlayers();
        }

        public void ImportPlayersFromRoster(HtmlDocument rosterPage)
        {
            var rosterList = rosterPage.DocumentNode.SelectSingleNode(
                "//div[@id='rosterBlock']"
                );
            Log.Debug("----- RosterBlock -----");
            //Log.Debug(rosterList.InnerHtml);

            var rosterTables = rosterList.SelectNodes(
                ".//tbody"
                );
            int i = 1;
            foreach (var tBodyNode in rosterTables)
            {
                Log.Debug("--##--##--##--##--##--##--##--##--##--##--##--##--##--##--##--##--##--");
                Log.Debug(tBodyNode.InnerHtml);
                Log.Debug("--##--##--##--##--##--##--##--##--##--##--##--##--##--##--##--##--##--");

                var trNodes = tBodyNode.SelectNodes("tr");
                foreach (var trNode in trNodes)
                {
                    ImportPlayer(trNode);
                }
                
                if (i >= 3) break;
                i++;
            }
            
        }

        private void ImportPlayer(HtmlNode trNode)
        {

            var tdNodes = trNode.SelectNodes("td");
            
            Player player = new Player()
            {
                JerseyNumber = int.Parse(tdNodes[0].InnerText),
                Name = tdNodes[1].InnerText,
                Position = tdNodes[2].InnerText,
                Handedness = tdNodes[3].InnerText[0],
                Height = Conversions.HeightMixedImperialtoInches(tdNodes[4].InnerText),
                Weight = Conversions.SafeParseInt(tdNodes[5].InnerText, 0),
                DateOfBirth = Conversions.DateStringToDateTime(tdNodes[6].InnerText),
                BirthPlace = tdNodes[7].InnerText
            };
            hockeyModel.AddPlayer(player);
            Log.DebugFormat("player1: {0}", player);
        }

        protected abstract void ImportPlayers();
        protected abstract void ImportTeams();
        protected abstract void ImportTeamPlayers();
        protected abstract string LeagueName{get;}

    }
}
