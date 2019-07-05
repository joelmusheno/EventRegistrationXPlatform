using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SoS.Models
{
    public class DayGroupedEventList : List<IBaseEvent>
    {
        public DateTime GroupingDate { get; set; }
        public string GroupingShortDate
        {
            get
            {
                return GroupingDate.ToShortDateString();
            }
        }

        public string GroupingShorterDate
        {
            get
            {
                return GroupingDate.ToString("MM/dd");
            }
        }

        public DayGroupedEventList(DateTime groupingDate, IEnumerable<IBaseEvent> events)
        {
            GroupingDate = groupingDate;
            AddRange(events);
        }
    }
}
