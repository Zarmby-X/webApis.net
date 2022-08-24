using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using webApis.net.Models.Domain;
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
    }
}
