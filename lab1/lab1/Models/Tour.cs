using System;
using System.Collections.Generic;
using System.Text;

namespace lab1.Models
{
    public class Tour
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int TourKindId { get; set; }
        public int ClientId { get; set; }


        public virtual TourKind TourKind { get; set; }
        public virtual Client Client{ get; set; }

        public override string ToString()
        {
            return "{ Id = " + Id + 
                   ", Price = " + Price + 
                   ", StartDate = " + StartDate + 
                   ", EndDate = " + EndDate +
                   ", TourKindId = " + TourKindId +
                   ", ClientId = " + ClientId + " }";
        }
    }
}
