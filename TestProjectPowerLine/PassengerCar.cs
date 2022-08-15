using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectPowerLine
{
    public class PassengerCar : CommonCar, ITransportCar
    {
        public int MaxPassengers { get; private set; }

        private int curPassengers = 0;

        public int CurPassengers
        {

            get => curPassengers;

            set
            {
                if (value > MaxPassengers || value < 0) throw new Exception("Неверное число пассажиров");

                else curPassengers = value;
            }
        }

        public PassengerCar(CarType carType, float avarageFuelConsumption, float fuelTankCapacity, float currentSpeed, int maxPassengers)
            : base(carType, avarageFuelConsumption, fuelTankCapacity, currentSpeed)
        {
            this.MaxPassengers = maxPassengers;
        }

        // Возвращает запас хода с учётом числа пассажиров
        public float GetMaxDistanceConsideringCargo(float currentVolumeFuel)
        {
            return currentVolumeFuel / AvarageFuelConsumption * 100 * (1 - 0.06f * curPassengers);
        }

        // Возвращает время необходимое на преодоление указанного расстояния с учётом груза.
        public override float TryGetTimeDriven(float currentVolumeFuel, float distance)
        {
            float maxDistance = GetMaxDistanceConsideringCargo(currentVolumeFuel);

            if (maxDistance < distance) return -1f; // Возвращаем -1, если топлива не хватит.

            return distance / CurrentSpeed; // Возвращаем число часов необходимых на преодоление указанного расстояния.
        }
    }
}
