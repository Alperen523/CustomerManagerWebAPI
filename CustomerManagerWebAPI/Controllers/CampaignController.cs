using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using CustomerManagerWebApiByAlp.Models;
using CustomerManagerWebApiByAlp.Services;

namespace CustomerManagerWebApiByAlp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CampaignController : ControllerBase
    {
        private readonly ICampaignService _campaignService;

        public CampaignController(ICampaignService campaignService)
        {
            _campaignService = campaignService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Campaign>> GetCampaigns()
        {
            return Ok(_campaignService.GetAllCampaigns());
        }

        [HttpGet("{id}")]
        public ActionResult<Campaign> GetCampaign(int id)
        {
            var campaign = _campaignService.GetCampaignById(id);
            if (campaign == null)
            {
                return NotFound();
            }
            return Ok(campaign);
        }

        [HttpPost]
        public ActionResult<Campaign> CreateCampaign(Campaign campaign)
        {
            _campaignService.CreateCampaign(campaign);
            return CreatedAtAction(nameof(GetCampaign), new { id = campaign.Id }, campaign);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCampaign(int id, Campaign campaign)
        {
            if (id != campaign.Id)
            {
                return BadRequest();
            }
            _campaignService.UpdateCampaign(campaign);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCampaign(int id)
        {
            _campaignService.DeleteCampaign(id);
            return NoContent();
        }
    }
}
