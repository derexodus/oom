using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public interface Vehicle
    {
        void Print();
    } 

    public class Car : Vehicle
    {
        public Car(int s, string t)
        {
            if (s <= 0) throw new ArgumentException("Speed must be greater than 0.", nameof(s));
            if (string.IsNullOrWhiteSpace(t)) throw new ArgumentException("Type must be given.", nameof(t));

            setTopSpeed(s);
            setType(t);
        }

        public void Print()
        {
            Console.WriteLine("This is a car with top speed: {0} and type of {1}\n", TopSpeed, Type);
        }

        int TopSpeed;

        void setTopSpeed(int v) { TopSpeed = v; }
        int getTopSpeed() { return TopSpeed; }

        string Type;

        void setType(string v) { Type = v; }
        string getType() { return Type; }
    }

    public class Truck : Vehicle
    {
        public Truck(int s, double c)
        {
            if (s <= 0) throw new ArgumentException("Speed must be greater than 0.", nameof(s));
            if (c <= 0) throw new ArgumentException("Capacity must be greater than 0.", nameof(c));

            setTopSpeed(s);
            setCapacity(c);
        }

        public void Print()
        {
           Console.WriteLine("This is a truck with top speed: {0} and capacity of {1} CT\n", TopSpeed, Capacity);
        }

        int TopSpeed;

        void setTopSpeed(int v) { TopSpeed = v; }
        int getTopSpeed() { return TopSpeed; }

        double Capacity;

        void setCapacity(double v) { Capacity = v; }
        double getCapacity() { return Capacity; }
    }

        class Program
    {
        static void Main(string[] args)
        {
            var VehArr = new Vehicle[]
            { 
                new Car(230, "Sport"),
                new Truck(160, 2.5),
                new Truck(130, 4),
                new Car(185, "Family"),
                new Truck(170, 1.5),
                new Car(170, "Limousine"),
                new Truck(156, 2.3),
                new Truck(163, 3),
                new Car(170, "Standard"),
                new Car(190, "Limousine"),
            };

            foreach(var x in VehArr)
            {
                x.Print();
            }
        }
    }
}
