using System.ComponentModel.DataAnnotations;

namespace Blazor_Automated_Email_Marketing_System.Models;

public class Subscriber
{
        [Key]
        public int SubscriberId { get; set; }

        public string Email { get; set; }
        public char Gender { get; set; }
        public bool OptIn { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Country { get; set; }

        public List<SubscriberSegment> SubscriberSegments { get; set; } = new();
        public List<SegmentInterest> Interests { get; set; } = new();
}


public class Segment
{
        [Key]
        public int SegmentId { get; set; }

        public string Name { get; set; }
        public List<SubscriberSegment> SubscriberSegments { get; set; } = new();
        public List<CampaignSegment> CampaignSegments { get; set; } = new();
        public List<SegmentInterest> Interests { get; set; } = new();
}


public class Campaign
{
        [Key] public int CampaignId { get; set; }

        public string Name { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public DateTime ScheduledTime { get; set; }

        public List<CampaignSegment> CampaignSegments { get; set; } = new();
}

public class SegmentInterest
{
        [Key]
        public int SegmentInterestId { get; set; }

        public int SegmentId { get; set; }
        public Segment Segment { get; set; }

        public string Interest { get; set; }
}


public class SubscriberSegment
{
        public int SubscriberId { get; set; }
        public Subscriber Subscriber { get; set; }

        public int SegmentId { get; set; }
        public Segment Segment { get; set; }
}

public class CampaignSegment
{
        public int CampaignId { get; set; }
        public Campaign Campaign { get; set; }

        public int SegmentId { get; set; }
        public Segment Segment { get; set; }
}

