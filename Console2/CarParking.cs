using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class CarParking
{
    private List<Car> Parking;

    public class Car
    {
        public string carnumber;
        public string owner;
        public string color;
        public string model;
        public bool present;

        public Car(string carnumber, string owner, string color, string model, bool present)
        {
            this.carnumber = carnumber;
            this.owner = owner;
            this.color = color;
            this.model = model;
            this.present = present;
        }
    }

    public CarParking(List<Car> parking)
    {
        this.Parking = parking;
    }

    public Car FindCarNumber(string number)
    {
        foreach (Car a in this.Parking)
        {
            if (a.carnumber == number) return a;
        }

        return null;
    }

    public Car FindOwner(string owner)
    {
        foreach (Car a in this.Parking)
        {
            if (a.owner == owner) return a;
        }
        return null;
    }

    public List<Car> PresentCars()
    {
        List<Car> a = new List<Car>();

        foreach (Car x in this.Parking)
        {
            if (x.present == true) a.Add(x);
        }
        return a;
    }

    public List<Car> AbsentCars()
    {
        List<Car> a = new List<Car>();

        foreach (Car x in this.Parking)
        {
            if (x.present == false) a.Add(x);
        }
        return a;
    }

    public Car this[int i]
    {
        get { return this.Parking[i]; }
        set { this.Parking[i] = value; }
    }

}