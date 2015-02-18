using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hockey.Model
{
    public class TeamPlayer
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int PlayerId { get; set; }
        public int TeamId { get; set; }
    }
}
