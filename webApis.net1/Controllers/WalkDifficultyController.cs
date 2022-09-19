
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using webApis.net.Repositories;

namespace webApis.net.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WalkDifficultyController : Controller
    {
        private readonly IWalkDifficultyRepository walkDifficultyRepository;
        private readonly IMapper mapper;

        public WalkDifficultyController(IWalkDifficultyRepository walkDifficultyRepository, IMapper mapper)
        {
            this.walkDifficultyRepository = walkDifficultyRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetWalkDifficulties()
        {
            var walksDifficulties = await walkDifficultyRepository.GetAll();

            var walksDTO = mapper.Map<List<Models.DTO.WalkDifficulty>>(walksDifficulties);

            return Ok(walksDTO);
        }

        [HttpGet]
        [Route("GetById/{id:Guid}")]
        [ActionName("GetById")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var walkDificulty = await walkDifficultyRepository.GetById(id);

            if(walkDificulty == null)
            {
                return NotFound();
            }

            var walkDifficultyDto = mapper.Map<Models.DTO.WalkDifficulty>(walkDificulty);

            return Ok(walkDifficultyDto);
        }

        [HttpPost]
        public async Task<IActionResult> AddWalkDifficulty([FromBody] Models.DTO.AddWalkDifficulty addWalkDifficulty)
        {
            var walkDifficulty = mapper.Map<Models.Domain.WalkDifficulty>(addWalkDifficulty);

            walkDifficulty = await walkDifficultyRepository.AddWalkDifficulty(walkDifficulty);

            var walkDifficultyDto = mapper.Map<Models.DTO.WalkDifficulty>(walkDifficulty);

            return CreatedAtAction(nameof(GetById),new {id = walkDifficulty.Id }, walkDifficultyDto);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateWalkDifficulty([FromRoute] Guid id, [FromBody] Models.DTO.UpdateWalkDifficulty updateWalkDifficulty)
        {
            var walkDifficulty = mapper.Map<Models.Domain.WalkDifficulty>(updateWalkDifficulty);

            walkDifficulty = await walkDifficultyRepository.UpdateWalkDifficulty(id, walkDifficulty);

            if(walkDifficulty == null)
            {
                return NotFound();
            }

            var walkDifficultyDto = mapper.Map<Models.DTO.WalkDifficulty>(walkDifficulty);

            return CreatedAtAction(nameof(GetById), new { id = id }, walkDifficultyDto);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteWalkDifficulty([FromRoute] Guid id)
        {
            var deleteWalk = await walkDifficultyRepository.DeleteWalkDifficulty(id);

            if(deleteWalk == null)
            {
                return NotFound();
            }

            return Ok(deleteWalk);
        }
    }
}
