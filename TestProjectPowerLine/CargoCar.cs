using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectPowerLine
{
    public class CargoCar : CommonCar
    {
        public int MaxCargo { get; private set; }

        private int curCargo = 0;

        public int CurCargo
        {

            get => curCargo;

            set
            {
                if (value > MaxCargo || value < 0) throw new Exception("Неверная масса груза");

                else curCargo = value;
            }
        }

        public CargoCar(CarType carType, float avarageFuelConsumption, float fuelTankCapacity, float currentSpeed, int maxCargo) 
            : base(carType, avarageFuelConsumption, fuelTankCapacity, currentSpeed) 
        {
            this.MaxCargo = maxCargo;
        }

        // Возвращает запас хода с учётом массы груза
        public override float GetMaxDistanceConsideringCargo(float currentVolumeFuel)
        {
            return currentVolumeFuel / AvarageFuelConsumption * 100 * (1 - 0.04f * (curCargo / 200));
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
