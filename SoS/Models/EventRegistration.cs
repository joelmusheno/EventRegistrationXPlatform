using System;


namespace SoS.Models
{
    public class EventRegistration : IBaseEvent
    {
        public int Id { get; set; }
        public IBaseEvent Event { get; set; }
        public string Name { get; set; }
        public Seat Seat { get; set; }
        public int CustomerId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
