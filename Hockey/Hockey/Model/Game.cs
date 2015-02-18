﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hockey.Model
{
    class Game
    {
        public int Id { get; set; }
        public int HomeTeamId { get; set; }
        public int AwayTeamId { get; set; }
        public string Season { get; set; }
        public string SeasonType { get; set; }
        public DateTime GameDate { get; set; }
        public int HomeScore { get; set; }
        public int AwayScore { get; set; }
    }
}
