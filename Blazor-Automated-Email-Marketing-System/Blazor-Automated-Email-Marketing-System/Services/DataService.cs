using Blazor_Automated_Email_Marketing_System.dbContext;
using Blazor_Automated_Email_Marketing_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Blazor_Automated_Email_Marketing_System.Services
{
    public class DataService
    {
        private readonly AppDbContext _context;

        public DataService(AppDbContext context)
        {
            _context = context;
        }

        // Subscriber methods
        public async Task<List<Subscriber>?> GetAllSubscribers()
        {
            return await _context.Subscribers.ToListAsync();
        }

        public async Task<Subscriber> GetSubscriberByEmail(string email)
        {
            return await _context.Subscribers.FirstOrDefaultAsync(s => s.EmailAddress == email);
        }

        public async Task<Subscriber> CreateSubscriber(Subscriber subscriber)
        {
            _context.Subscribers.Add(subscriber);
            await _context.SaveChangesAsync();
            return subscriber;
        }

        // Campaign methods
        public async Task<List<Campaign>> GetAllCampaigns()
        {
            return await _context.Campaigns.ToListAsync();
        }

        public async Task<Campaign> GetCampaignByName(string name)
        {
            return await _context.Campaigns.FirstOrDefaultAsync(c => c.Name == name);
        }

        public async Task<Campaign> CreateCampaign(Campaign campaign)
        {
            _context.Campaigns.Add(campaign);
            await _context.SaveChangesAsync();
            return campaign;
        }

        // Tag methods
        public async Task<List<Tag>> GetAllTags()
        {
            return await _context.Tags.ToListAsync();
        }

        public async Task<Tag> GetTagByName(string name)
        {
            return await _context.Tags.FirstOrDefaultAsync(t => t.Name == name);
        }

        public async Task<Tag> CreateTag(Tag tag)
        {
            _context.Tags.Add(tag);
            await _context.SaveChangesAsync();
            return tag;
        }

        // Subscriber Segment methods
        public async Task<List<Segment>> GetAllSegments()
        {
            return await _context.Segments.ToListAsync();
        }

        public async Task<Segment> GetSegmentByName(string name)
        {
            return await _context.Segments.FirstOrDefaultAsync(s => s.Name == name);
        }

        public async Task<Segment> CreateSubscriberSegment(Segment segment)
        {
            _context.Segments.Add(segment);
            await _context.SaveChangesAsync();
            return segment;
        }

        // Email Message methods
        public async Task<List<EmailMessage>?> GetAllEmailMessages()
        {
            return await _context.EmailMessages.ToListAsync();
        }

        public async Task<EmailMessage> GetEmailMessageBySubject(string subject)
        {
            return await _context.EmailMessages.FirstOrDefaultAsync(e => e.Subject == subject);
        }

        public async Task<EmailMessage> CreateEmailMessage(EmailMessage emailMessage)
        {
            _context.EmailMessages.Add(emailMessage);
            await _context.SaveChangesAsync();
            return emailMessage;
        }
    }
}
