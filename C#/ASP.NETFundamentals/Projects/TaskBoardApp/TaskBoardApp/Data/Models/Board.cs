﻿using System.ComponentModel.DataAnnotations;

namespace TaskBoardApp.Data.Models
{
    public class Board
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(DataConstants.Board.NameMaxLength, MinimumLength = DataConstants.Board.NameMinLength)]
        public string Name { get; set; } = null!;

        public IEnumerable<Task> Tasks { get; set; } = new List<Task>();
    }
}
