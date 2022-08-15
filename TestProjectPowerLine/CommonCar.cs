using System;

namespace TestProjectPowerLine
{
    public abstract class CommonCar
    {
        // Тип автомобиля
        public virtual CarType CarType { get; private set; }

        // Средний расход топлива (ед.изм: литр/100*км)
        public virtual float AvarageFuelConsumption { get; private set; }

        // Объём топливного бака (ед.изм: литр)
        public virtual float FuelTankCapacity { get; private set; }

        // Текущая скорость авто (ед.изм: км/ч)
        public virtual float CurrentSpeed { get; private set; }

        protected CommonCar(CarType carType, float avarageFuelConsumption, float fuelTankCapacity, float currentSpeed)
        {
            this.CarType = carType;

            this.AvarageFuelConsumption = avarageFuelConsumption;

            this.FuelTankCapacity = fuelTankCapacity;

            this.CurrentSpeed = currentSpeed;
        }

        // Метод возвращает расстояние которое автомобиль может проехать на конкретном уровне топлива в баке.
        public virtual float GetMaxDistance(float currentVolumeFuel)
        {
            return currentVolumeFuel / AvarageFuelConsumption * 100;
        }

        // Метод возвращает расстояние которое автомобиль может проехать на полном баке топлива.
        public virtual float GetMaxDistance()
        {
            return GetMaxDistance(FuelTankCapacity);
        }
                
        // Метод возвращает за какое время автомобиль преодолеет указанное растояние, если хватит топлива.
        public abstract float TryGetTimeDriven(float currentVolumeFuel, float distance);

    }

    public enum CarType
    {
        minivan,
        hatchback,
        sedan,
        sport,
        cargo
    }
}
