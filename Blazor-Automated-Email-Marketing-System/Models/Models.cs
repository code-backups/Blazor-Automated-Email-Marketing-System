using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public enum Gender
{
    Male,
    Female,
    Other
}

public class Subscriber
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Email { get; set; }

    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

    public string Country { get; set; }

    public Gender Gender { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public bool OptIn { get; set; }

    public int TagId { get; set; }

    [ForeignKey(nameof(TagId))]
    public Tag Tag { get; set; }

    [NotMapped]
    public int[] SegmentIds { get; set; }
}

public class Tag
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    public string Description { get; set; }

    [NotMapped]
    public int[] SubscriberIds { get; set; }

    [NotMapped]
    public int[] SegmentCriteriaIds { get; set; }
}

public class SegmentCriteria
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    public string Description { get; set; }

    public int TagId { get; set; }

    [ForeignKey(nameof(TagId))]
    public Tag Tag { get; set; }

    [NotMapped]
    public int[] SubscriberSegmentIds { get; set; }
}

public class SubscriberSegment
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    public string Description { get; set; }

    public int TagId { get; set; }

    [ForeignKey(nameof(TagId))]
    public Tag Tag { get; set; }

    [NotMapped]
    public int[] SubscriberIds { get; set; }

    [NotMapped]
    public int[] SegmentCriteriaIds { get; set; }

    [NotMapped]
    public int[] EmailMessageIds { get; set; }
}

public class EmailMessage
{
    [Key]
    public int Id { get; set; }

    public int SubscriberSegmentId { get; set; }

    [ForeignKey(nameof(SubscriberSegmentId))]
    public SubscriberSegment SubscriberSegment { get; set; }

    public DateTime SendDate { get; set; }

    [Required]
    public string Subject { get; set; }

    [Required]
    public string Body { get; set; }
}

public class Campaign
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    public string Description { get; set; }

    public DateTime SendDate { get; set; }

    [NotMapped]
    public int[] SubscriberSegmentIds { get; set; }

    [NotMapped]
    public int[] EmailMessageIds { get; set; }
}
