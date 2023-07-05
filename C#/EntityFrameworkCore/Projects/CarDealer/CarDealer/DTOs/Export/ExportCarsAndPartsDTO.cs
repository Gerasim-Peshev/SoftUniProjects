using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarDealer.Models;
using Newtonsoft.Json;

namespace CarDealer.DTOs.Export
{
    public class ExportCarsAndPartsDTO
    {
        [JsonProperty("car")]
        public ExportCarDTO Car { get; set; }

        [JsonProperty("parts")]
        public ICollection<ExportPartsDTO> Parts { get; set; }
    }
}
