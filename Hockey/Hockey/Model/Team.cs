using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hockey.Model
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public string League { get; set; }
        public string Division { get; set; }

        public override string ToString()
        {
            return string.Format("Id: {0}, Name: {1}, Abbreviation: {2}, League: {3}, Division: {4}",
                Id, Name, Abbreviation, League, Division);
        }
    }
}
