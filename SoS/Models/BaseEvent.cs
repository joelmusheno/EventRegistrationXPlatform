using System;

namespace SoS.Models
{
    public class BaseEvent : IBaseEvent
    {
        private string _name;

        public int Id { get; set; }
        public string Name
        {
            get
            {
                if (string.IsNullOrEmpty(_name))
                    return Session.Name;
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        public Session Session { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get;  set; }
        public Location Location { get; set; }
    }
}
