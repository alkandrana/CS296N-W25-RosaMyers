using System.ComponentModel.DataAnnotations;

namespace OnTolkien.Models
{
    public class Story
    {
        public int StoryId { get; set; }
        public string Title { get; set; }

        public Topic? Topic { get; set; }
        [StringLength(1)] public string TopicId { get; set; } = "G";

        public int StoryYear { get; set; }

        public string StoryText { get; set; }

        public AppUser? Contributor { get; set; }

        public DateTime EntryDate { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
