namespace OnTolkien.Models
{
    public class Story
    {
        public int StoryId { get; set; }
        public string Title { get; set; }

        public string Topic { get; set; }

        public int StoryYear { get; set; }

        public string StoryText { get; set; }

        public AppUser? Contributor { get; set; }

        public DateTime EntryDate { get; set; }
    }
}
