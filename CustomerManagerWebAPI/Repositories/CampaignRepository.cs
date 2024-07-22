using System.Collections.Generic;
using System.Linq;
using CustomerManagerWebApiByAlp.Models;

namespace CustomerManagerWebApiByAlp.Repositories
{
    public class CampaignRepository : ICampaignRepository
    {
        private readonly List<Campaign> _campaigns = new List<Campaign>();

        public IEnumerable<Campaign> GetAllCampaigns()
        {
            return _campaigns;
        }

        public Campaign GetCampaignById(int id)
        {
            return _campaigns.FirstOrDefault(c => c.Id == id);
        }

        public void CreateCampaign(Campaign campaign)
        {
            _campaigns.Add(campaign);
        }

        public void UpdateCampaign(Campaign campaign)
        {
            var existingCampaign = GetCampaignById(campaign.Id);
            if (existingCampaign != null)
            {
                existingCampaign.Name = campaign.Name;
                existingCampaign.Description = campaign.Description;
                existingCampaign.EndDate = campaign.EndDate;
                existingCampaign.StartDate = campaign.StartDate;
            }
        }

        public void DeleteCampaign(int id)
        {
            var campaign = GetCampaignById(id);
            if (campaign != null)
            {
                _campaigns.Remove(campaign);
            }
        }
    }
}