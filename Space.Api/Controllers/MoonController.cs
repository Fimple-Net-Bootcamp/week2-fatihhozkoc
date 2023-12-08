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
    public class MoonController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IService<Moon> _service;

        public MoonController(IService<Moon> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> All([FromQuery] int page = 1, [FromQuery] int size = 10, [FromQuery] string someFilter = null, [FromQuery] string sort = null)
        {
            var moons = await _service.GetAllAsync();

            // Filtreleme
            if (!string.IsNullOrEmpty(someFilter))
            {
                moons = moons.Where(m => m.IsTidallyLocked == true).ToList();
            }

            // Sıralama
            if (!string.IsNullOrEmpty(sort))
            {
                moons = sort switch
                {
                    "name_asc" => moons.OrderBy(m => m.Name).ToList(),
                    "name_desc" => moons.OrderByDescending(m => m.Name).ToList(),
                    _ => moons
                };
            }

            // Sayfalama
            var pagedMoons = moons.Skip((page - 1) * size).Take(size);

            var moonDtos = _mapper.Map<List<MoonDto>>(pagedMoons);
            return CreateActionResult(CustomResponseDto<List<MoonDto>>.Success(200, moonDtos));
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var moon = await _service.GetByIdAsync(id);
            var moonDto = _mapper.Map<MoonDto>(moon);
            return CreateActionResult(CustomResponseDto<MoonDto>.Success(200, moonDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(MoonDto moonDto)
        {
            var moons = await _service.AddAsync(_mapper.Map<Moon>(moonDto));
            var moonsDto = _mapper.Map<PlanetDto>(moons);
            return CreateActionResult(CustomResponseDto<PlanetDto>.Success(201, moonsDto));      // 201 oluşturuldu 
        }

        [HttpPut]
        public async Task<IActionResult> Update(MoonDto moonDto)
        {
            await _service.UpdateAsync(_mapper.Map<Moon>(moonDto));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));      // 204 başarılı oldu, geriye bir şey dönmedi 
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var moon = await _service.GetByIdAsync(id);
            await _service.RemoveAsyn(moon);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(200));
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchPlanet(int id, [FromBody] MoonPatchDto moonPatchDto)
        {
            var existingMoon = await _service.GetByIdAsync(id);
            if (existingMoon == null)
            {
                return NotFound();
            }

            // DTO'daki null olmayan değerleri entity'ye aktarın
            _mapper.Map(moonPatchDto, existingMoon);

            await _service.UpdateAsync(existingMoon);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}
