using Project.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Project.Model
{
    [KnownType(typeof(VehicleMake))]

    public class VehicleMake : IVehicleMake
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
        public virtual ICollection<IVehicleModel> VehicleModels { get; set; }
    }
}
