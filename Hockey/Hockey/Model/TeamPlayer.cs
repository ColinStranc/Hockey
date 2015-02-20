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

        public override string ToString()
        {
            return String.Format("Id: {0}, StartDate: {1}, EndDate: {2}, PlayerId: {3}, TeamId: {4}",
                Id, StartDate, EndDate, PlayerId, TeamId);
        }
    }

   
}
