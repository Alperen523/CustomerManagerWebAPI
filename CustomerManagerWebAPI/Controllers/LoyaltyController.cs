using AutoMapper;
using CustomerManagerWebApiByAlp.Models;
using CustomerManagerWebApiByAlp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerManagerWebApiByAlp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoyaltyController : ControllerBase
    {
        private readonly ILoyaltyService _loyaltyService;
        private readonly IMapper _mapper;

        public LoyaltyController(ILoyaltyService loyaltyService, IMapper mapper)
        {
            _loyaltyService = loyaltyService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LoyaltyProgramDto>>> GetLoyaltyPrograms()
        {
            var loyaltyPrograms = await _loyaltyService.GetAllLoyaltyProgramsAsync();
            var loyaltyProgramDtos = _mapper.Map<IEnumerable<LoyaltyProgramDto>>(loyaltyPrograms);
            return Ok(loyaltyProgramDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LoyaltyProgramDto>> GetLoyaltyProgram(int id)
        {
            var loyaltyProgram = await _loyaltyService.GetLoyaltyProgramByIdAsync(id);
            if (loyaltyProgram == null)
            {
                return NotFound();
            }
            var loyaltyProgramDto = _mapper.Map<LoyaltyProgramDto>(loyaltyProgram);
            return Ok(loyaltyProgramDto);
        }

        [HttpPost]
        public async Task<ActionResult<LoyaltyProgramDto>> CreateLoyaltyProgram(LoyaltyProgramDto loyaltyProgramDto)
        {
            var loyaltyProgram = _mapper.Map<LoyaltyProgram>(loyaltyProgramDto);
            await _loyaltyService.CreateLoyaltyProgramAsync(loyaltyProgram);
            var createdLoyaltyProgramDto = _mapper.Map<LoyaltyProgramDto>(loyaltyProgram);
            return CreatedAtAction(nameof(GetLoyaltyProgram), new { id = createdLoyaltyProgramDto.Id }, createdLoyaltyProgramDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLoyaltyProgram(int id, LoyaltyProgramDto loyaltyProgramDto)
        {
            if (id != loyaltyProgramDto.Id)
            {
                return BadRequest();
            }
            var loyaltyProgram = _mapper.Map<LoyaltyProgram>(loyaltyProgramDto);
            var result = await _loyaltyService.UpdateLoyaltyProgramAsync(loyaltyProgram);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLoyaltyProgram(int id)
        {
            var result = await _loyaltyService.DeleteLoyaltyProgramAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
