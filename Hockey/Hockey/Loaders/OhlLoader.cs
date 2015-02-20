using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hockey.Utility;
using log4net;
using Hockey.Model;
using HtmlAgilityPack;

namespace Hockey.Loaders
{
    public class OhlLoader : AHockeyLoader
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(OhlLoader));

        protected override string LeagueName { get { return "OHL"; } }

        public OhlLoader(HockeyModel hm) : base(hm) { }


        protected override void ImportPlayers()
        {
            Log.InfoFormat("#### Loading {0} Players. ####", LeagueName);

            string homePageLink = "http://www.ontariohockeyleague.com/";
            var homePage = HtmlLoader.LoadPage(homePageLink);

            var teamList = homePage.DocumentNode.SelectSingleNode(
                "//li[@class='toplevel toplevel_6']"
                );

            var closerRosterList = teamList.SelectSingleNode(
                ".//ul"
                );

            foreach (var childNode in closerRosterList.ChildNodes)
            {
                var aNode = childNode.SelectSingleNode(".//a");
                if (aNode != null)
                {
                    Team team = hockeyModel.GetTeam(aNode.InnerText);
                    String rosterLink = aNode.GetAttributeValue("href", null);
                    rosterLink = homePageLink + rosterLink;

                    Log.InfoFormat("Loading {0} players.\nWebPageUrl: {1}", aNode.InnerText, rosterLink);

                    ImportPlayersFromRoster(HtmlLoader.LoadPage(rosterLink), team);
                }
            }
            Log.InfoFormat("Finished Loading {0} Players", LeagueName);
        }

        protected override void ImportTeams()
        {
            string standingsPageString = "http://www.ontariohockeyleague.com/standings/show/ls_season/51/subtype/0";
            Log.InfoFormat("#### Loading {0} teams. ####\nWebPageUrl: {1}", LeagueName, standingsPageString);

            var standingsPage = HtmlLoader.LoadPage(standingsPageString);
            var standingsTable = standingsPage.DocumentNode.SelectSingleNode(
              "//table[@class='statsTable']"
            );
            string division = "";
            foreach (var childNode in standingsTable.ChildNodes)
            {
                var thNodes = childNode.SelectNodes("th");
                var aNode = childNode.SelectSingleNode("td/a");

                if(thNodes != null && thNodes[0].InnerText == "Rank") 
                {
                    Log.InfoFormat("{0}", thNodes[1].InnerText);
                    division = thNodes[1].InnerText;
                    division = division.Replace(" Division", "");
                }

                if(aNode != null )
                {
                    Log.InfoFormat("Creating Team Object For {0}", aNode.InnerText);
                    
                    Team team = new Team()
                    {
                        Name = aNode.InnerText,
                        Abbreviation = null,
                        League = LeagueName,
                        Division = division
                    };
                    hockeyModel.AddTeam(team);
                    Log.DebugFormat("team: {0}", team);
                }
            }

            Log.InfoFormat("Finished Loading {0} teams", LeagueName);
        }

        protected override void ImportGames()
        {
            string gamesListPageString = "http://www.ontariohockeyleague.com/schedule/list/time_zone/0";
            var gamesListPage = HtmlLoader.LoadPage(gamesListPageString);

            Log.InfoFormat("#### Loading {0} Games ####\nWebPageUrl: {1}", LeagueName, gamesListPageString);

            var schedTable = gamesListPage.DocumentNode.SelectSingleNode(
                ".//div[@class='sked_tbl']/table"///tbody
                );
            List<HtmlNode> gameRows = new List<HtmlNode>();
            foreach(var rowNode in schedTable.ChildNodes)
            {
                Log.DebugFormat("{0}", rowNode.InnerHtml);
                
                if (rowNode.SelectSingleNode("td/a") != null)
                {
                    var rowElements = rowNode.SelectNodes("td");

                    var dateNode = rowElements[0].SelectSingleNode("a");
                    string gameSummaryLink = dateNode.GetAttributeValue("href", null);
                    string date = gameSummaryLink.Substring(gameSummaryLink.LastIndexOf('/') + 1);

                    Game game = new Game()
                    {

                        HomeTeamId = hockeyModel.GetTeamIdFromPartialName(rowElements[3].InnerText),
                        AwayTeamId = hockeyModel.GetTeamIdFromPartialName(rowElements[1].InnerText),
                        Season = "14-15",     // TODO
                        SeasonType = "REG",   // TODO
                        GameDate = DateTime.ParseExact(date, "yyyy-MM-d", null),
                        HomeScore = int.Parse(rowElements[4].InnerText),
                        AwayScore = int.Parse(rowElements[2].InnerText)
                    };
                    hockeyModel.AddGame(game);
                    Log.DebugFormat("Game: {0}", game);

                }
                else
                {
                    //Not a Game Row.
                }
            }

            Log.InfoFormat("Finished Loading {0} Games", LeagueName);
        }
    }
}
