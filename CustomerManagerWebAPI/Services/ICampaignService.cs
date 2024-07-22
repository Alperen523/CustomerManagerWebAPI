using CustomerManagerWebApiByAlp.Models;

namespace CustomerManagerWebApiByAlp.Services
{
    public interface ICampaignService
    {
        // Campaign ile ilgili methodları tanımlayın
        IEnumerable<Campaign> GetAllCampaigns();
        Campaign GetCampaignById(int id);
        void CreateCampaign(Campaign campaign);
        void UpdateCampaign(Campaign campaign);
        void DeleteCampaign(int id);
    }
}
