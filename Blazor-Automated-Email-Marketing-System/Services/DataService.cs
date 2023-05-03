using Blazor_Automated_Email_Marketing_System.dbContext;
using Microsoft.EntityFrameworkCore;

public class DataService
{
    private readonly AppDbContext _databaseContext;

    public DataService(AppDbContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    // Create Campaign
    public async Task<Campaign> CreateCampaign(Campaign campaign)
    {
        if (campaign == null) throw new ArgumentNullException(nameof(campaign));

        // Check each field for null
        var newCampaign = new Campaign
        {
            Name = campaign.Name ?? throw new ArgumentNullException(nameof(campaign.Name)),
            Description = campaign.Description ?? throw new ArgumentNullException(nameof(campaign.Description)),
            SendDate = campaign.SendDate != DateTime.MinValue
                ? campaign.SendDate
                : throw new ArgumentNullException(nameof(campaign.SendDate)),
            SubscriberSegmentIds = campaign.SubscriberSegmentIds ?? Array.Empty<int>(),
            EmailMessageIds = campaign.EmailMessageIds ?? Array.Empty<int>()
        };

        await _databaseContext.Campaigns.AddAsync(newCampaign);
        await _databaseContext.SaveChangesAsync();
        return newCampaign;
    }

    // Create Subscriber
    public async Task<Subscriber> CreateSubscriber(Subscriber subscriber)
    {
        await _databaseContext.Subscribers.AddAsync(subscriber);
        await _databaseContext.SaveChangesAsync();
        return subscriber;
    }

    // Create Segment
    public async Task<SubscriberSegment> CreateSegment(SubscriberSegment subscriberSegment)
    {
        if (subscriberSegment == null) throw new ArgumentNullException(nameof(subscriberSegment));

        var newSegment = new SubscriberSegment
        {
            Name = subscriberSegment.Name ?? throw new ArgumentNullException(nameof(subscriberSegment.Name)),
            Description = subscriberSegment.Description ??
                          throw new ArgumentNullException(nameof(subscriberSegment.Description))
        };

        if (subscriberSegment.SegmentCriteriaIds != null && subscriberSegment.SegmentCriteriaIds.Length > 0)
            newSegment.SegmentCriteriaIds = subscriberSegment.SegmentCriteriaIds;
        else
            throw new ArgumentNullException(nameof(subscriberSegment.SegmentCriteriaIds));

        if (subscriberSegment.SubscriberIds != null && subscriberSegment.SubscriberIds.Length > 0)
            newSegment.SubscriberIds = subscriberSegment.SubscriberIds;
        else
            throw new ArgumentNullException(nameof(subscriberSegment.SubscriberIds));

        await _databaseContext.SubscriberSegments.AddAsync(newSegment);
        await _databaseContext.SaveChangesAsync();
        return newSegment;
    }

    // Create Email Message
    public async Task<EmailMessage> CreateEmail(EmailMessage emailMessage)
    {
        await _databaseContext.EmailMessages.AddAsync(emailMessage);
        await _databaseContext.SaveChangesAsync();
        return emailMessage;
    }

    // Get Segment by SegmentId
    public async Task<SubscriberSegment> GetSegmentById(int? segmentId)
    {
        return await _databaseContext.SubscriberSegments.FindAsync(segmentId);
    }

    // Get EmailMessage by EmailMessageId
    public async Task<EmailMessage> GetEmailById(int emailMessageId)
    {
        return await _databaseContext.EmailMessages.FindAsync(emailMessageId);
    }

    // Get all Campaigns
    public async Task<List<Campaign>> GetAllCampaigns()
    {
        return await _databaseContext.Campaigns.ToListAsync();
    }

    // Get all SubscriberSegments
    public async Task<List<SubscriberSegment>> GetAllSegments()
    {
        return await _databaseContext.SubscriberSegments.ToListAsync();
    }

    // Get all EmailMessages
    public async Task<List<EmailMessage>> GetAllEmailMessages()
    {
        return await _databaseContext.EmailMessages.ToListAsync();
    }

}