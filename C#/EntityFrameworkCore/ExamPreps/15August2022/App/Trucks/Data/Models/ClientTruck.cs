﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trucks.Data.Models
{
    public class ClientTruck
    {
        [ForeignKey(nameof(Client))]
        public int ClientId { get; set; }
        public Client Client { get; set; } = null!;

        [ForeignKey(nameof(Truck))]
        public int TruckId { get; set; }
        public Truck Truck { get; set; } = null!;

    }
}
