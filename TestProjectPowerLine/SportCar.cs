using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectPowerLine
{
    internal class SportCar : CommonCar
    {
        public SportCar(CarType carType, float avarageFuelConsumption, float fuelTankCapacity, float currentSpeed)
            : base(carType, avarageFuelConsumption, fuelTankCapacity, currentSpeed)
        {
        }

        // Возвращает время необходимое на преодоление указанного расстояния.
        // По ТЗ для спортивного авто дополнительный груз не учитываем.
        public override float TryGetTimeDriven(float currentVolumeFuel, float distance)
        {
            float maxDistance = GetMaxDistance(currentVolumeFuel);

            if (maxDistance < distance) return -1f; // Возвращаем -1, если топлива не хватит.

            return distance / CurrentSpeed; // Возвращаем число часов необходимых на преодоление указанного расстояния.
        }
    }
}
