using System.ComponentModel.DataAnnotations;
using TaskBoardApp.Data;

namespace TaskBoardApp.Models.Task
{
    public class TaskFormModel
    {
        [Required]
        [StringLength(DataConstants.Task.TitleMaxLength, MinimumLength = DataConstants.Task.TitleMinLength,
                      ErrorMessage = "Title should be at least {2} characters long.")]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(DataConstants.Task.DescriptionMaxLength, MinimumLength = DataConstants.Task.DescriptionMinLength, ErrorMessage = "Descriptyon should be at least {2} characters long.")]
        public string Description { get; set; } = null!;

        [Display(Name = "Board")]
        public int BoardId { get; set; }

        public IEnumerable<TaskBoardModel> Boards { get; set; } = null!;
    }
}
