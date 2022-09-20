using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex2
{
    class Program
    {
        public class Car : IEquatable<Car>
        {
            public string Name;
            public string Engine;
            public int MaxSpeed;

            public Car(string _name, string _engine, int _speed)
            {
                Name = _name;
                Engine = _engine;
                MaxSpeed = _speed;
            }

            public bool Equals(Car car)
            {
                return (this.Name, this.Engine, this.MaxSpeed) == (car.Name, car.Engine, car.MaxSpeed);
            }

            public override string ToString()
            {
                return Name;
            }
        }

        public class CarsCatalog
        {
            Car[] carsCollection;

            public CarsCatalog(params Car[] _car)
            {
                carsCollection = _car;
            }

            public string this[int index]
            {
                get
                {
                    return $"{carsCollection[index].Name} | {carsCollection[index].Engine}";
                }
            }

            static void Main(string[] args)
            {
                Car Zhiguli = new Car("Zhiguli", "Шеснарь", 150);
                Car LandCruiser = new Car("Land Cruiser 300", "V 35F FTS", 220);
                Car Nissan = new Car("Skyline", "RB", 220);

                CarsCatalog myCars = new CarsCatalog(Zhiguli, LandCruiser, Nissan);

                for (int i = 0; i < 3; ++i)
                {
                    Console.WriteLine(myCars[i] + "\n");
                }

                string carName = Zhiguli.ToString();
                Console.WriteLine(carName);

                Console.WriteLine(Equals(Zhiguli, Nissan));

                Console.WriteLine(Equals(Zhiguli, Zhiguli));

            }
        }
    }
}
