using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boardgames.Data.Models;
using Newtonsoft.Json;

namespace Boardgames.DataProcessor.ImportDto
{
    public class ImportSellerDTO
    {
        [JsonProperty("Name")]
        [Required]
        [MinLength(5)]
        [MaxLength(20)]
        public string Name { get; set; }

        [JsonProperty("Address")]
        [Required]
        [MinLength(2)]
        [MaxLength(30)]
        public string Address { get; set; }

        [JsonProperty("Country")]
        [Required]
        public string Country { get; set; }

        [JsonProperty("Website")]
        [Required]
        [RegularExpression(@"www.[\w\d-]*.com")]
        public string Website { get; set; }

        [JsonProperty("Boardgames")]
        public ICollection<int> Boardgames { get; set; }
    }
}
