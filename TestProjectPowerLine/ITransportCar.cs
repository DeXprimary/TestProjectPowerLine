using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectPowerLine
{
    internal interface ITransportCar
    {
        public float GetMaxDistanceConsideringCargo(float currentVolumeFuel);
    }
}
