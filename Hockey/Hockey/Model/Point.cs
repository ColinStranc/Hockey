using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hockey.Model
{
    class Point
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public int PlayerId { get; set; }
        public int TeamId { get; set; }
        public int OppTeamId { get; set; }
        public string TypeOfPoint { get; set; }
        public int TeamScore { get; set; }
        public int OppTeamScore { get; set; }
        public string Situation { get; set; }
        public int Period { get; set; }
        public int SecondsIn { get; set; }
    }
}
