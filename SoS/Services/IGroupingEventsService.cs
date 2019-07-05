using System.Collections.Generic;
using SoS.Models;

namespace SoS.Services
{
    public interface IGroupingEventsService
    {
        IEnumerable<DayGroupedEventList> GetDayGroupings(IEnumerable<IBaseEvent> events);
    }
}