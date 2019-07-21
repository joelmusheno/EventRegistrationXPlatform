using System;
using System.Collections.Generic;
using SoS.Models;

namespace SoS.Services
{
    public class MockDatabase : IDatabase
    {
        private readonly IList<InstructorLedEvent> events;
        private readonly IList<Session> sessions;
        private readonly IList<Location> locations;
        private readonly IList<EventRegistration> eventRegistrations;
        private readonly IList<Instructor> instructors;
        private readonly IList<Seat> seats;

        public IList<InstructorLedEvent> Events { get => events; }
        public IList<Session> Sessions { get => sessions; }
        public IList<Location> Locations { get => locations; }
        public IList<EventRegistration> EventRegistrations { get => eventRegistrations; }
        public IList<Instructor> Instructors { get => instructors; }
        public IList<Seat> Seats { get => seats; }

        public MockDatabase()
        {

            var clockedSession = new Session { Id = 1, Name = "Clocked" };
            var itmSession = new Session { Id = 2, Name = "In the Mix" };
            var controlSession = new Session { Id = 3, Name = "Control" };
            var efSession = new Session { Id = 4, Name = "Ebb and Flow" };
            sessions = new List<Session>()
            {
                clockedSession,
                itmSession,
                controlSession,
                efSession,
            };

            var seat1 = new Seat { Id = 1, Name = "Seat 1" };
            var seat2 = new Seat { Id = 2, Name = "Seat 2" };
            var seat3 = new Seat { Id = 3, Name = "Seat 3" };
            var seat4 = new Seat { Id = 4, Name = "Seat 4" };
            var seat5 = new Seat { Id = 5, Name = "Seat 5" };
            var seat6 = new Seat { Id = 6, Name = "Seat 6" };
            seats = new List<Seat> { seat1, seat2, seat3, seat4, seat5, seat6 };

            var location1 = new Location
            {
                Id = 1,
                Name = "Location 1",
                AddressLine1 = "1234 Any Street",
                City = "Columbus",
                State = "OH",
                Zip = "43214",
                Seats = new List<Seat>
                {
                    seat1,
                    seat2,
                    seat3
                }
            };
            var location2 = new Location
            {
                Id = 2,
                Name = "Location 2",
                AddressLine1 = "9876 Any Street",
                City = "Columbus",
                State = "OH",
                Zip = "43214",
                Seats = new List<Seat>
                {
                    seat4,
                    seat5,
                    seat6
                }
            };
            locations = new List<Location>
            {
                location1,
                location2
            };

            var instructor1 = new Instructor
            {
                Id = 1,
                Name = "Instructor 1"
            };
            var instructor2 = new Instructor
            {
                Id = 2,
                Name = "Instructor 2"
            };
            var instructor3 = new Instructor
            {
                Id = 3,
                Name = "Instructor 3"
            };
            var instructor4 = new Instructor
            {
                Id = 4,
                Name = "Instructor 4"
            };
            instructors = new List<Instructor> { instructor1, instructor2, instructor3, instructor4 };

            var event1 = new InstructorLedEvent
            {
                Id = 1,
                StartDate = DateTime.Now.AddDays(1),
                EndDate = DateTime.Now.AddDays(1).AddHours(1),
                Location = location1,
                Instructor = instructor1,
                Session = itmSession
            };
            var event2 = new InstructorLedEvent
            {
                Id = 2,
                StartDate = DateTime.Now.AddDays(1),
                EndDate = DateTime.Now.AddDays(1).AddHours(1),
                Location = location2,
                Instructor = instructor2,
                Session = efSession
            };
            var event3 = new InstructorLedEvent
            {
                Id = 3,
                StartDate = DateTime.Now.AddDays(1),
                EndDate = DateTime.Now.AddDays(1).AddHours(1),
                Location = location1,
                Instructor = instructor3,
                Session = itmSession
            };
            var event4 = new InstructorLedEvent
            {
                Id = 4,
                StartDate = DateTime.Now.AddDays(1),
                EndDate = DateTime.Now.AddDays(1).AddHours(1),
                Location = location2,
                Instructor = instructor3,
                Session = clockedSession
            };
            var event5 = new InstructorLedEvent
            {
                Id = 5,
                StartDate = DateTime.Now.AddDays(2),
                EndDate = DateTime.Now.AddDays(2).AddHours(1),
                Location = location1,
                Instructor = instructor1,
                Session = itmSession
            };
            var event6 = new InstructorLedEvent
            {
                Id = 6,
                StartDate = DateTime.Now.AddDays(2),
                EndDate = DateTime.Now.AddDays(2).AddHours(1),
                Location = location2,
                Instructor = instructor2,
                Session = efSession
            };
            var event7 = new InstructorLedEvent
            {
                Id = 7,
                StartDate = DateTime.Now.AddDays(2),
                EndDate = DateTime.Now.AddDays(2).AddHours(1),
                Location = location1,
                Instructor = instructor3,
                Session = itmSession
            };
            var event8 = new InstructorLedEvent
            {
                Id = 8,
                StartDate = DateTime.Now.AddDays(2),
                EndDate = DateTime.Now.AddDays(2).AddHours(1),
                Location = location2,
                Instructor = instructor3,
                Session = clockedSession
            };
            events = new List<InstructorLedEvent>() { event1, event2, event3, event4,
                event5, event6, event7, event8 };

            eventRegistrations = new List<EventRegistration>
            {
                new EventRegistration
                {   Id = 1,
                    Event = event5,
                    Name = "First item",
                    StartDate = DateTime.Now.AddHours(1),
                    EndDate = DateTime.Now.AddHours(2),
                    Seat = event5.Location.Seats[1]
                },
                new EventRegistration
                {   Id = 2,
                    Name = "Second item",
                    Event = event6,
                    StartDate = DateTime.Now.AddDays(1).AddHours(1),
                    EndDate = DateTime.Now.AddDays(1).AddHours(2),
                    Seat = event6.Location.Seats[1]
                },
            };
        }

        public IList<T> GetBaseModelTable<T>() where T : IBaseModel
        {
            if (typeof(T) == typeof(InstructorLedEvent))
                return (IList<T>)events;
            if (typeof(T) == typeof(Session))
                return (IList<T>)sessions;
            if (typeof(T) == typeof(Location))
                return (IList<T>)locations;
            if (typeof(T) == typeof(EventRegistration))
                return (IList<T>)eventRegistrations;
            if (typeof(T) == typeof(Instructor))
                return (IList<T>)instructors;
            if (typeof(T) == typeof(Seat))
                return (IList<T>)seats;

            throw new Exception("Could not find.");
        }
    }
}