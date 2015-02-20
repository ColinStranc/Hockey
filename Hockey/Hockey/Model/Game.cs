using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hockey.Model
{
    public class Game
    {
        public int Id { get; set; }
        public int HomeTeamId { get; set; }
        public int AwayTeamId { get; set; }
        public string Season { get; set; }
        public string SeasonType { get; set; }
        public DateTime GameDate { get; set; }
        public int HomeScore { get; set; }
        public int AwayScore { get; set; }

        public override string ToString()
        {
            return string.Format("Id: {0}, HomeTeamId: {1}, AwayteamId: {2}, Season: {3}, SeasonType: {4}, GameDate: {5}, HomeScore: {6}, AwayScore: {7}",
                Id, HomeTeamId, AwayTeamId, Season, SeasonType, GameDate, HomeScore, AwayScore);
        }
    }
}
