using classwork.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace classwork.Models
{
    internal class Car:IVehicle
    {
        public Car(double fuel=20, double fuelConsumtion=10, double tankCapacity=40)
        {
            Fuel = fuel;
            FuelConsumtion = fuelConsumtion;
            TankCapacity = tankCapacity;
            MileAge = 0;
        }

        public double MileAge { get; private set; }
        public double Fuel { get; private set; }
        public double FuelConsumtion { get; private set; }
        public double TankCapacity { get; private set; }

        public bool Drive(double mile)
        {

            
            if (Fuel - mile * FuelConsumtion / 100 < 0)
            {
                Colored.Write("No enough fuel", ConsoleColor.Red);
                return false;
            }
            else
            {
				Fuel -= mile * FuelConsumtion / 100;
				MileAge += mile;
                Console.WriteLine(@$"Fuel: {Fuel}
Mile: {MileAge}");
                return true;
            }
        }

        public bool Refuel(double fuel)
        {
            if (Fuel + fuel > TankCapacity)
            {
                Fuel = TankCapacity;
                return false;
            }
            else
            {
               Fuel += fuel;
               return true;
            }
        }
    }
}
