using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hockey.Model
{
    class GamePlayer
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public int PlayerId { get; set; }
        public int TeamId { get; set; }
        public int Goals { get; set; }
        public int Assists { get; set; }
        public int PIM { get; set; }
        public int TOIInSec { get; set; }
    }
}
