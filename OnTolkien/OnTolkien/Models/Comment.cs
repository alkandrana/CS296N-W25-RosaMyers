using System.ComponentModel.DataAnnotations;

namespace OnTolkien.Models;

public class Comment
{
    public int CommentId { get; set; }
    [Required(ErrorMessage = "Please enter a comment.")]
    [StringLength(500)]
    public string CommentText { get; set; } = string.Empty;
    public DateTime CommentDate { get; set; }
    public int StoryId { get; set; }
    public AppUser? Commenter { get; set; }
}