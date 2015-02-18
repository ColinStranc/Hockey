using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hockey.Model
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public int JerseyNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string BirthPlace { get; set; }
        public char Handedness { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }

        public override string ToString()
        {
            return String.Format("Id: {0}, Name: {1}, Position: {2}, JerseyNumber: {3}, DateOfBirth: {4}, BirthPlace {5}, Handedness: {6}, Height: {7}, Weight {8}",
                Id, Name, Position, JerseyNumber, DateOfBirth, BirthPlace, Handedness, Height, Weight);
        }
    }
}
