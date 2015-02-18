using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hockey.Utility;
using log4net;
using Hockey.Model;

namespace Hockey.Loaders
{
    public class OhlLoader : AHockeyLoader
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(OhlLoader));

        protected override string LeagueName { get { return "OHL"; } }

        public OhlLoader(HockeyModel hm) : base(hm) { }


        protected override void ImportPlayers()
        {
            string homePageLink = "http://www.ontariohockeyleague.com/";
            var homePage = HtmlLoader.LoadPage(homePageLink);

            var teamList = homePage.DocumentNode.SelectSingleNode(
                "//li[@class='toplevel toplevel_6']"
                );

            Log.Debug("##### Roster List HTML #####");
            Log.Debug(teamList.InnerHtml);

            var closerRosterList = teamList.SelectSingleNode(
                ".//ul"
                );

            foreach (var childNode in closerRosterList.ChildNodes)
            {
                var aNode = childNode.SelectSingleNode(".//a");
                if (aNode != null)
                {
                    Team team = hockeyModel.GetTeam(aNode.InnerText);
                    Log.DebugFormat("\n#######################\nSelected Node: {0}", aNode.InnerHtml);
                    String rosterLink = aNode.GetAttributeValue("href", null);
                    rosterLink = homePageLink + rosterLink;
                    Log.DebugFormat("link: {0}", rosterLink);
                    ImportPlayersFromRoster(HtmlLoader.LoadPage(rosterLink), team);
                    Log.Debug("###############");

                }
            }  
        }

        protected override void ImportTeams()
        {
            var standingsPage = HtmlLoader.LoadPage("http://www.ontariohockeyleague.com/standings/show/ls_season/51/subtype/0");

            var standingsTable = standingsPage.DocumentNode.SelectSingleNode(
              "//table[@class='statsTable']"
            );
            string division = "";
            foreach (var childNode in standingsTable.ChildNodes)
            {
                
                //Log.Debug("####### Child Node of Standings #######");
                //Log.Debug(childNode.InnerHtml);

                var thNodes = childNode.SelectNodes("th");
                var aNode = childNode.SelectSingleNode("td/a");

                if(thNodes != null && thNodes[0].InnerText == "Rank") 
                {
                    Log.DebugFormat("{0}", thNodes[1].InnerText);
                    division = thNodes[1].InnerText;
                    division = division.Replace(" Division", "");
                }

                if(aNode != null )
                {
                    //Log.DebugFormat("aNode InnerHtml\n{0}\n", aNode.InnerHtml);
                    Log.DebugFormat("Team: {0}, Division: {1}", aNode.InnerText, division);
                    
                    
                    Team team = new Team()
                    {
                        Name = aNode.InnerText,
                        Abbreviation = null,
                        League = LeagueName,
                        Division = division
                    };
                    hockeyModel.AddTeam(team);
                }
            }
        }
    }
}
