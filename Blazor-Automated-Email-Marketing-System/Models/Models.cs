namespace Blazor_Automated_Email_Marketing_System.Models
{
    public class Subscriber
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string TagIdsCsv { get; set; }
    }

    public class Campaign
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string SegmentIdsCsv { get; set; }
        public string EmailMessageIdsCsv { get; set; }
    }

    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Segment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SubscriberIdsCsv { get; set; }
        public string TagIdsCsv { get; set; }
    }

    public class EmailMessage
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}