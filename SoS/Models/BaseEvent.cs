using System;

namespace gymtest.Models
{
    public class BaseEvent : IBaseEvent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get;  set; }
    }
}
