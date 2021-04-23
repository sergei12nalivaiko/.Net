using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FuelProject.Models
{
    public class Tank
    {
        public int ID { get; set; }
        public int TankNumber { get; set; }
        public int LevelSM { get; set; }
        public double Capacity { get; set; }
        public double CoefCapacity { get; set; }
    }
}