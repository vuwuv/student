using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    class Airport
    {
        public class Flight
        {
            public string Destination;
            public string Number;
            public DateTime Departure;

            public Flight(string Destination, string Number, DateTime Departure)
            {
                this.Destination = Destination;
                this.Number = Number;
                this.Departure = Departure;
            }

            public static bool operator ==(Flight a, Flight b)
            {
                if (a == b) return true;
                else return false;
            }

            public static bool operator !=(Flight a, Flight b)
            {
                if (a != b) return true;
                else return false;
            }
        }

        private List<Flight> Schedule;

        public Airport(IEnumerable<Flight> schedule)
        {
            this.Schedule = schedule.ToList();
        }



        public Flight this[int i]
        {
            get { return this.Schedule[i]; }
            set { this.Schedule[i] = value; }
        }

        public Flight this[string number]
        {
            get
            {
                return this.Schedule.Find(flight => flight.Number == number);
                /* var flights = from flight in this.Schedule
                               where flight.Number == number
                               select flight; */
            }
        }

        public List<Flight> ByDestination(string destination)
        {
            return this.Schedule.FindAll(flight => flight.Destination == destination);

            /* List<Flight> result = new List<Flight>();
             foreach (Flight x in this.Schedule)
             {
                 if (x.Destination == destination) result.Add(x);
             }
             return result; */
        }

        public List<Flight> ByTime(DateTime time)
        {
            return this.Schedule.FindAll(flight => flight.Departure > time &&
            flight.Departure < time + new TimeSpan(1, 0, 0));
        }

    }