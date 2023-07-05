using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace TaskBoardApp.Data.Models
{
    public class Task
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(DataConstants.Task.TitleMaxLength, MinimumLength = DataConstants.Task.TitleMinLength)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(DataConstants.Task.DescriptionMaxLength, MinimumLength = DataConstants.Task.DescriptionMinLength)]
        public string Description { get; set; } = null!;

        public DateTime CreatedOn { get; set; }

        public int BoardId { get; set; }

        [ForeignKey(nameof(BoardId))]
        public Board? Board { get; set; }

        [Required] 
        public string OwnerId { get; set; } = null!;

        [ForeignKey(nameof(OwnerId))] public IdentityUser Owner { get; set; } = null!;
    }
}
