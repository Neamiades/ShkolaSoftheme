using static System.Console;

namespace ConsoleCar
{
    class Car
    {
        public string Model { get; set; }
        public string Year  { get; set; }
        public string Color { get; set; }
    }

    static class TuningAtelier
    {
        public static void TuneCar(Car car) => car.Color = "Red";
    }

    class Program
    {
        static void Main()
        {
            var car = new Car {Model = "BMV", Year = "2016", Color = "Black"};
            WriteLine($"Car has a {car.Color} color before tuning");
            TuningAtelier.TuneCar(car);
            WriteLine($"Car has a {car.Color} color after tuning");
        }
    }
}
