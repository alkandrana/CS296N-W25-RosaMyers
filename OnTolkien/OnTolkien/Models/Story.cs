using System.ComponentModel.DataAnnotations;

namespace OnTolkien.Models
{
    public class Story
    {
        public int StoryId { get; set; }
        
        [Required(ErrorMessage = "Story must have a title for reference.")]
        [StringLength(100)]
        public string Title { get; set; }
        
        [StringLength(1)]
        [Display(Name = "Topic")]
        public string TopicId { get; set; } = "G";
        
        public Topic? Topic { get; set; }
        
        [RegularExpression(@"^(\d{4})$", ErrorMessage = "The Year of the Event must be a four digit year.")]
        [Display(Name = "Year of the Event")]
        [Range(1000, 2999, ErrorMessage = "The Year of the Event must be between the year 1000 AD and 2999 AD.")]
        public int StoryYear { get; set; }

        [Required(ErrorMessage = "Please enter a story.")]
        public string StoryText { get; set; }

        public AppUser? Contributor { get; set; }

        public DateTime EntryDate { get; set; }
        public ICollection<Comment>? Comments { get; set; }
    }
}
