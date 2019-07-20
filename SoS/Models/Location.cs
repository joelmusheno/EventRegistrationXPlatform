using System;
using System.Collections.Generic;

namespace SoS.Models
{
    public class Location : IBaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public IList<Seat> Seats { get; set; }
    }
}
