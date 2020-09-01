using Project.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Project.Model
{
    [KnownType(typeof(VehicleModel))]

    public class VehicleModel : IVehicleModel
    {
        public int Id { get; set; }
        public int MakeId { get; set; }
        public virtual IVehicleMake VehicleMake { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
    }
}
