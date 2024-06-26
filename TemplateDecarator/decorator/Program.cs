﻿namespace decorator
{
    public interface ICar
    {
        ICar ManufactureCar();
    }
    public class BMWCar : ICar
    {
        private string CarName = "BMW";
        public string CarBody { get; set; }
        public string CarDoor { get; set; }
        public string CarWheels { get; set; }
        public string CarGlass { get; set; }
        public string Engine { get; set; }
        public override string ToString()
        {
            return "BMWCar [CarName=" + CarName + ", CarBody=" + CarBody + ", CarDoor=" + CarDoor + ", CarWheels="
                            + CarWheels + ", CarGlass=" + CarGlass + ", Engine=" + Engine + "]";
        }
        public ICar ManufactureCar()
        {
            CarBody = "carbon fiber material";
            CarDoor = "4 car doors";
            CarWheels = "6 car glasses";
            CarGlass = "4 MRF wheels";
            return this;
        }
    }
    public abstract class CarDecorator : ICar
    {
        protected ICar car;
        public CarDecorator(ICar car)
        {
            this.car = car;
        }
        public virtual ICar ManufactureCar()
        {
            
            return car.ManufactureCar();
        }
    }
    class PetrolCarDecorator : CarDecorator
    {
        public PetrolCarDecorator(ICar car) : base(car)
        {
        }
        public override ICar ManufactureCar()
        {
            car.ManufactureCar();
            AddEngine(car);
            return car;
        }
        public void AddEngine(ICar car)
        {
            if (car is BMWCar BMWCar)
            {
                BMWCar.Engine = "Petrol Engine";
                Console.WriteLine("PetrolCarDecorator added Petrol Engine to the Car : " + car);
            }
        }
    }

    internal class Program
    {

        static void Main(string[] args)
        {
            ICar bmwCar1 = new BMWCar();
            bmwCar1.ManufactureCar();
            Console.WriteLine(bmwCar1 + "\n");
            
            
            Console.WriteLine();
            ICar bmwCar2 = new BMWCar();
            PetrolCarDecorator carWithPetrolEngine = new PetrolCarDecorator(bmwCar2);
            carWithPetrolEngine.ManufactureCar();
            Console.ReadKey();
        }
    }
}
