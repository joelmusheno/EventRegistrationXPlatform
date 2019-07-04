using System;
using System.Collections.Generic;
using System.Linq;
using gymtest.Models;

namespace gymtest.Services
{
    public class GroupingEventsService : IGroupingEventsService
    {
        public IEnumerable<DayGroupedEventList> GetDayGroupings(IEnumerable<IBaseEvent> events)
        {
            var dayGroupedList = events.GroupBy(x => x.StartDate.ToShortDateString(),
                (key, list) =>
                {
                    DateTime.TryParse(key, out DateTime dateWithoutTime);
                    return new DayGroupedEventList(dateWithoutTime, list);
                });

            return dayGroupedList;
        }
    }
}
