using System.Collections.Generic;
using gymtest.Models;

namespace gymtest.Services
{
    public interface IGroupingEventsService
    {
        IEnumerable<DayGroupedEventList> GetDayGroupings(IEnumerable<IBaseEvent> events);
    }
}