using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComputersBuildingSystem.DeviceComponents
{
    public class MotherboardComponent : IMotherboardComponent
    {
        public IMotherboard Motherboard { get; set; }
    }
}
