using System.ComponentModel.DataAnnotations;
namespace OnTolkien.Models.ViewModels;

public class CommentVM
{
    public int StoryId { get; set; }
    [Required(ErrorMessage = "Please enter a comment.")]
    [StringLength(500)]
    public string CommentText { get; set; } = "";
}