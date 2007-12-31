using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    class TrainStation
    {
        public class Train
        {
            public string Destination;
            public string Number;
            public DateTime Departure;

            public Train(string Destination, string Number, DateTime Departure)
            {
                this.Destination = Destination;
                this.Number = Number;
                this.Departure = Departure;
            }

            public static bool operator ==(Train train1, Train train2)
            {
                if (train1.Departure != train2.Departure) return false;
                else return true;
            }

            public static bool operator !=(Train train1, Train train2)
            {
                if (train1.Departure == train2.Departure) return false;
                else return true;
            }

        }

        private Train[] Schedule;

        public TrainStation(int size)
        {
            this.Schedule = new Train[size];
        }

        public Train this[int i]
        {
            get { return this.Schedule[i]; }
            set { this.Schedule[i] = value; }
        }

        public Train[] AfterTime()
        {
            DateTime time = DateTime.Parse(Console.ReadLine());
            List<Train> trains = new List<Train>();
            trains = this.Schedule.ToList();

            foreach (Train train in this.Schedule)
            {
                if (train.Departure < time) continue;
                else trains.Add(train);
            }

            return trains.ToArray();
        }

        public Train[] ByDestination(string destination)
        {
            return this.Schedule.Where(train => train.Destination == destination).ToArray();
        }

        public void SortByDeparture()
        {
            this.Schedule = this.Schedule.OrderBy(train => train.Departure).ToArray();
        }
    }