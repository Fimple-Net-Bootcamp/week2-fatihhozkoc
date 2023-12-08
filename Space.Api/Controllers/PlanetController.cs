using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Space.Core.DTOs;
using Space.Core.Models;
using Space.Core.Services;

namespace Space.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanetController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IService<Planet> _service;

        public PlanetController(IService<Planet> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> All([FromQuery] int page = 1, [FromQuery] int size = 10, [FromQuery] string status = null, [FromQuery] string sort = null)
        {
            var planets = await _service.GetAllAsync();

            // Filtreleme
            if (!string.IsNullOrEmpty(status))
            {
                planets = planets.Where(p => p.Habitable == true).ToList();
            }

            // Sıralama
            if (!string.IsNullOrEmpty(sort))
            {
                planets = sort switch
                {
                    "name_asc" => planets.OrderBy(p => p.Name).ToList(),
                    "name_desc" => planets.OrderByDescending(p => p.Name).ToList(),
                    _ => planets
                };
            }

            // Sayfalama
            var pagedPlanets = planets.Skip((page - 1) * size).Take(size);

            var planetDtos = _mapper.Map<List<PlanetDto>>(pagedPlanets);
            return CreateActionResult(CustomResponseDto<List<PlanetDto>>.Success(200, planetDtos));
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var planet = await _service.GetByIdAsync(id);
            var planetDto = _mapper.Map<PlanetDto>(planet);
            return CreateActionResult(CustomResponseDto<PlanetDto>.Success(200, planetDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(PlanetDto planetDto)
        {
            var planets = await _service.AddAsync(_mapper.Map<Planet>(planetDto));
            var planetsDto = _mapper.Map<PlanetDto>(planets);
            return CreateActionResult(CustomResponseDto<PlanetDto>.Success(201, planetsDto));      // 201 oluşturuldu 
        }

        [HttpPut]
        public async Task<IActionResult> Update(PlanetDto planetDto)
        {
            await _service.UpdateAsync(_mapper.Map<Planet>(planetDto));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));      // 204 başarılı oldu, geriye bir şey dönmedi 
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var planet = await _service.GetByIdAsync(id);
            //var userDto = _mapper.Map<UserDto>(user);      // remove metodu geriye bir şey dönmüyor

            await _service.RemoveAsyn(planet);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(200));
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchPlanet(int id, [FromBody] PlanetPatchDto planetPatchDto)
        {
            var existingPlanet = await _service.GetByIdAsync(id);
            if (existingPlanet == null)
            {
                return NotFound();
            }

            // DTO'daki null olmayan değerleri entity'ye aktarın
            _mapper.Map(planetPatchDto, existingPlanet);

            await _service.UpdateAsync(existingPlanet);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}
