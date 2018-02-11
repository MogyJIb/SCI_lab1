using System;
using System.Collections.Generic;
using System.Text;

namespace lab1.Models
{
    public class Client
    {
        public Client()
        {
            Tours = new List<Tour>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<Tour> Tours { get; set; }

        public override string ToString()
        {
            return "{ Id = "+Id + 
                   ", Name = " + Name + 
                   ", Birthday = " + Birthday + 
                   ", Phone = " + Phone + " }";
        }
    }
}
