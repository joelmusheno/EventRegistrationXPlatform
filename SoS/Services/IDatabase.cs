using System.Collections.Generic;
using SoS.Models;

namespace SoS.Services
{
    public interface IDatabase
    {
        IList<InstructorLedEvent> Events { get; }
        IList<Session> Sessions { get; }
        IList<Location> Locations { get; }
        IList<EventRegistration> EventRegistrations { get; }
        IList<Instructor> Instructors { get; }
        IList<Seat> Seats { get; }

        IList<T> GetBaseModelTable<T>() where T : IBaseModel;
    }
}