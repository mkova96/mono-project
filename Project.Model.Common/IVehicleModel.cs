using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Model.Common
{
    public interface IVehicleModel
    {
        int Id { get; set; }
        int MakeId { get; set; }
        IVehicleMake VehicleMake { get; set; }
        string Name { get; set; }
        string Abrv { get; set; }
    }
}
