using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using webApis.net.Repositories;

namespace webApis.net.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WalksController : Controller
    {
        private readonly IWalksRepository walksRepository;
        private readonly IMapper mapper;

        public WalksController(IWalksRepository walksRepository, IMapper mapper)
        {
            this.walksRepository = walksRepository;
            this.mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllWalks()
        {
            var walks = await walksRepository.GetAll();

            var walksDTO = mapper.Map<List<Models.DTO.Walks>>(walks);

            return Ok(walksDTO);
        }

        [HttpGet]
        [Route("GetById/{id:Guid}")]
        [ActionName("GetWalkById")]
        public async Task<IActionResult> GetWalkById(Guid id)
        {
            var walks = await walksRepository.GetWalkById(id);

            if (walks == null)
            {
                return NotFound();
            }

            var walkDTO = mapper.Map<Models.DTO.Walks>(walks);

            return Ok(walkDTO);
        }

        [HttpPost]
        public async Task<IActionResult> AddWalk([FromBody] Models.DTO.AddWalkReuqest addedWalk)
        {
            var walk = mapper.Map<Models.Domain.Walks>(addedWalk);

            walk = await walksRepository.AddWalk(walk);

            return CreatedAtAction(nameof(GetWalkById), new { id = walk.Id }, walk);

            var walkDTO = mapper.Map<Models.DTO.Walks>(walk);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateWalk([FromRoute] Guid id, [FromBody] Models.DTO.UpdateWalkRequest updateWalkRequest)
        {
            var walk = mapper.Map<Models.Domain.Walks>(updateWalkRequest);

            walk = await walksRepository.UpdateWalk(id, walk);

            if (walk == null)
            {
                return NotFound();
            }

            var WalkDTO = mapper.Map<Models.DTO.Walks>(walk);

            return Ok(WalkDTO);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteWalk([FromRoute] Guid id)
        {
            var walk = await walksRepository.DeleteWalk(id);

            if(walk == null)
            {
                return null;
            }

            var walkDTO = mapper.Map<Models.DTO.Walks>(walk);

            return Ok(walkDTO);
        }
    }
}
