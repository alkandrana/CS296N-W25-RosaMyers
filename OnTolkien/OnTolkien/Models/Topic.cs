using System.ComponentModel.DataAnnotations;

namespace OnTolkien.Models;

public class Topic
{
    [StringLength(1)] 
    public string TopicId { get; set; } = "G";

    [StringLength(50)] 
    public string TopicName { get; set; } = "General";
    
}