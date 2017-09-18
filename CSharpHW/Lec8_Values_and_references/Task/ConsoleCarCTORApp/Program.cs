using static System.Console;

namespace ConsoleCarCTORApp
{
    class Engine
    {
        public string Type  { get; set; }
        public string Brand { get; set; }
    }


    class Color
    {
        public string Name { get; set; }
    }

    class Transmission
    {
        public string Type { get; set; }
    }

    class Car
    {
        public Engine       Engine       { get; set; }
        public Color        Color        { get; set; }
        public Transmission Transmission { get; set; }

        public void PrintInfo()
        {
            WriteLine("The car have:");
            WriteLine($"Engine: {Engine.Brand} {Engine.Type}");
            WriteLine($"Transmission: {Transmission.Type}");
            WriteLine($"Color: {Color.Name}");
        }
    }

    static class CarConstructor
    {
        private static readonly Engine _bestEngine = new Engine { Type = "Electro", Brand = "BMV" };

        public static Car Construct(Engine e, Color c, Transmission t) => new Car {Engine = e, Color = c, Transmission = t};
        public static Car Reconstruct(Car car, Engine engine = null)
        {
            car.Engine = engine ?? _bestEngine;
            return car;
        }
    }
    class Program
    {
        static void Main()
        {
            var car = CarConstructor.Construct(
                new Engine{Type = "Gasoline", Brand = "Audi"},
                new Color{Name = "Black"},
                new Transmission{Type = "Mechanic"});
            car.PrintInfo();
            CarConstructor.Reconstruct(car);
            car.PrintInfo();
        }
    }
}
