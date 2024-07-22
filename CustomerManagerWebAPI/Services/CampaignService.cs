using System.Collections.Generic;
using System.Linq;
using CustomerManagerWebApiByAlp.Data;
using CustomerManagerWebApiByAlp.Models;
using CustomerManagerWebApiByAlp.Services;

namespace CustomerManagerWebApiByAlp.Services
{
    public class CampaignService : ICampaignService
    {
        private readonly ApplicationDbContext _context;

        public CampaignService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Campaign> GetAllCampaigns()
        {
            return _context.Campaigns.ToList();
        }

        public Campaign GetCampaignById(int id)
        {
            return _context.Campaigns.Find(id);
        }

        public void CreateCampaign(Campaign campaign)
        {
            _context.Campaigns.Add(campaign);
            _context.SaveChanges();
        }

        public void UpdateCampaign(Campaign campaign)
        {
            _context.Campaigns.Update(campaign);
            _context.SaveChanges();
        }

        public void DeleteCampaign(int id)
        {
            var campaign = _context.Campaigns.Find(id);
            if (campaign != null)
            {
                _context.Campaigns.Remove(campaign);
                _context.SaveChanges();
            }
        }
    }
}
