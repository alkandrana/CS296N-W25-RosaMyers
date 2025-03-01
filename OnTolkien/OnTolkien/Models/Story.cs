using System.ComponentModel.DataAnnotations;

namespace OnTolkien.Models
{
    public class Story
    {
        public int StoryId { get; set; }
        
        [StringLength(100)]
        public string Title { get; set; }
        
        [StringLength(1)] 
        public string TopicId { get; set; } = "G";
        
        public Topic? Topic { get; set; }
        
        [RegularExpression(@"^(\d{4})$", ErrorMessage = "Story Year must be a four digit year.")]
        [Display(Name = "Story Year")]
        [Range(1000, 3000, ErrorMessage = "Story Year must be between the year 1000 AD and 3000 AD.")]
        public int StoryYear { get; set; }

        public string StoryText { get; set; }

        public AppUser? Contributor { get; set; }

        public DateTime EntryDate { get; set; }
        public ICollection<Comment>? Comments { get; set; }
    }
}
