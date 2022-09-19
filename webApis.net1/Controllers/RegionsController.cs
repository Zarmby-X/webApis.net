using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using webApis.net.Repositories;

namespace webApis.net.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegionsController : Controller
    {
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;

        public RegionsController(IRegionRepository regionRepository, IMapper mapper)
        {
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> getAllReions()
        {
            var regions = await regionRepository.GetAll();

            var regionsDTO = mapper.Map<List<Models.DTO.Region>>(regions);

            return Ok(regionsDTO);
        }

        [HttpGet]
        [Route("getById/{id:Guid}")]
        [ActionName("GetRegionById")]
        public async Task<IActionResult> GetRegionById(Guid id)
        {
            var region = await regionRepository.GetRegionById(id);

            if (region == null)
            {
                return NotFound();
            }

            var regionDTO = mapper.Map<Models.DTO.Region>(region);

            return Ok(regionDTO);
        }

        [HttpPost]
        public async Task<IActionResult> AddRegion(Models.DTO.AddRegionRequest addRegionRequest)
        {
            var region = mapper.Map<Models.Domain.Region>(addRegionRequest);

            region = await regionRepository.AddRegion(region);

            var regionDTO = mapper.Map<Models.DTO.Region>(region);

            return CreatedAtAction(nameof(GetRegionById), new { id = regionDTO.Id }, regionDTO);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> RemoveRegion(Guid id)
        {
            var region = await regionRepository.DeleteRegion(id);

            if (region == null)
            {
                return NotFound();
            }

            var regionDTO = mapper.Map<Models.DTO.Region>(region);

            return Ok(regionDTO);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateRegion([FromRoute] Guid id, [FromBody] Models.DTO.UpdateRegionRequest updatedRegion)
        {
            var region = mapper.Map<Models.Domain.Region>(updatedRegion);

            region = await regionRepository.UpdateRegion(id, region);

            if (region == null)
            {
                return NotFound();
            }

            var regionDTO = mapper.Map<Models.DTO.Region>(region);

            return Ok(regionDTO);
        }
    }
}
