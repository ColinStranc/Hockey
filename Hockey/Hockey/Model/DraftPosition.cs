using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hockey.Model
{
    class DraftPosition
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public int JuniorTeamId { get; set; }
        public int DraftingTeamId { get; set; }
        public int DraftYear { get; set; }
        public int PickNumber { get; set; }
    }
}
