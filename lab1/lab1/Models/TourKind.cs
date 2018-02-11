using System;
using System.Collections.Generic;
using System.Text;

namespace lab1.Models
{
    public class TourKind
    {
        public TourKind()
        {
            Tours = new List<Tour>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Constraints { get; set; }

        public virtual ICollection<Tour> Tours { get; set; }

        public override string ToString()
        {
            return "{ Id = " + Id +
                   ", Name = " + Name +
                   ", Description = " + Description +
                   ", Constraints = " + Constraints + " }";
        }
    }
}
