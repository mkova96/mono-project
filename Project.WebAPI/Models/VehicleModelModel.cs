﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.WebAPI.Models
{
    public class VehicleModelModel
    {
        public int Id { get; set; }
        public int MakeId { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }

    }
}