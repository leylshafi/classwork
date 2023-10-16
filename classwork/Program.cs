using classwork.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace classwork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var info = TakeInfo();
            Car car = new Car(info.fuel,info.usage,info.capacity);

            Menu(ref car);
        }

        public static (double fuel,double capacity, double usage) TakeInfo()
        {
            Colored.Write("How many fuel does it have?", ConsoleColor.Blue);
            double.TryParse(Console.ReadLine(), out double fuel);
            fuel = CheckInfo(fuel);
            Colored.Write("How much is capacity?", ConsoleColor.Blue);
            double.TryParse(Console.ReadLine(), out double capacity);
            capacity = CheckInfo(capacity);
            Colored.Write("How much does the car use for 100km?", ConsoleColor.Blue);
            double.TryParse(Console.ReadLine(), out double usage);
            usage = CheckInfo(usage);

            return (fuel,capacity,usage);
        }

        public static double CheckInfo(double info)
        {
            if (info <= 0)
            {
                Colored.Write("Wrong input", ConsoleColor.Red);
                Colored.Write("Enter again", ConsoleColor.Blue);
                double.TryParse(Console.ReadLine(), out info);
                CheckInfo(info);
            }
            return info;
        }

        public static void Menu(ref Car car)
        {
            Colored.Write(@"[1] Drive
[2] Go fuel station
[3] Show fuel
[4] Show way", ConsoleColor.Blue);
            int.TryParse(Console.ReadLine(), out int choose);
            Choose(ref car,choose);
        }


        public static void Choose(ref Car car,int choose)
        {
            switch (choose)
            {
                case 1:
                    Colored.Write("How much you will go? ", ConsoleColor.Blue);
                    double.TryParse(Console.ReadLine(), out double mile);
                    if(mile>0)
                    {
                        car.Drive(mile);
                    }
                    else Colored.Write("Wrong input", ConsoleColor.Red);
                    break;
                case 2:
                    Colored.Write("How much will you take? ", ConsoleColor.Blue);
                    double.TryParse(Console.ReadLine(), out double fuel);
                    if(fuel > 0)
                    {
                        if (!car.Refuel(fuel))
                            Colored.Write($"Filled. Fuel: {car.Fuel}L", ConsoleColor.Green);
                        else Colored.Write($"Filled. Fuel: {car.Fuel}L", ConsoleColor.Green);
                    }
                    else Colored.Write("Wrong input", ConsoleColor.Red);
                    break;
                case 3:
                    Colored.Write($"Fuel: {car.Fuel}", ConsoleColor.Green);
                    break;
                case 4:
                    Colored.Write($@"Way: {car.MileAge}", ConsoleColor.Green);
                    break;
                default:
                    Colored.Write("Wring input", ConsoleColor.Red);
                    Menu(ref car);
                    break;
            }

            Menu(ref car);
        }

    }
}