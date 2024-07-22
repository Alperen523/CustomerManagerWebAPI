using System.Collections.Generic;
using CustomerManagerWebApiByAlp.Models;

namespace CustomerManagerWebApiByAlp.Repositories
{
    public interface ICampaignRepository
    {
        IEnumerable<Campaign> GetAllCampaigns();
        Campaign GetCampaignById(int id);
        void CreateCampaign(Campaign campaign);
        void UpdateCampaign(Campaign campaign);
        void DeleteCampaign(int id);

    }
}