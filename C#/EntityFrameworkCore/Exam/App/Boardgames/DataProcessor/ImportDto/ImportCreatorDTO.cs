﻿using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using Boardgames.Data.Models;

namespace Boardgames.DataProcessor.ImportDto
{
    [XmlType("Creator")]
    public class ImportCreatorDTO
    {
        [XmlElement("FirstName")]
        [Required]
        [MinLength(2)]
        [MaxLength(7)]
        public string FirstName { get; set; } = null!;

        [XmlElement("LastName")]
        [Required]
        [MinLength(2)]
        [MaxLength(7)]
        public string LastName { get; set; } = null!;

        [XmlArray("Boardgames")] 
        public ImportBoarderGameDTO[] Boardgames { get; set; } = null!;
    }
}
