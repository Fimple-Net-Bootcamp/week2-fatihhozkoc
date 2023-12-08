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
    public class WeatherConditionController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IService<WeatherCondition> _service;

        public WeatherConditionController(IService<WeatherCondition> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> All([FromQuery] int page = 1, [FromQuery] int size = 10, [FromQuery] string someFilter = null, [FromQuery] string sort = null)
        {
            var weatherConditions = await _service.GetAllAsync();
            // Filtreleme
            if (!string.IsNullOrEmpty(someFilter))
            {
                weatherConditions = weatherConditions.Where(wc => wc.SurfaceTemperature == 100).ToList();
            }


            // Sıralama
            if (!string.IsNullOrEmpty(sort))
            {
                weatherConditions = sort switch
                {
                    "property_asc" => weatherConditions.OrderBy(wc => wc.AtmosphericPressure).ToList(),
                    "property_desc" => weatherConditions.OrderByDescending(wc => wc.AtmosphericPressure).ToList(),
                    _ => weatherConditions
                };
            }

            // Sayfalama
            var pagedWeatherConditions = weatherConditions.Skip((page - 1) * size).Take(size);

            var wcDtos = _mapper.Map<List<WeatherConditonDto>>(pagedWeatherConditions);
            return CreateActionResult(CustomResponseDto<List<WeatherConditonDto>>.Success(200, wcDtos));
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var wc = await _service.GetByIdAsync(id);
            var wcDto = _mapper.Map<WeatherConditonDto>(wc);
            return CreateActionResult(CustomResponseDto<WeatherConditonDto>.Success(200, wcDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(WeatherConditonDto wc)
        {
            var wcs = await _service.AddAsync(_mapper.Map<WeatherCondition>(wc));
            var wcDto = _mapper.Map<WeatherConditonDto>(wcs);
            return CreateActionResult(CustomResponseDto<WeatherConditonDto>.Success(201, wcDto));      // 201 oluşturuldu 
        }

        [HttpPut]
        public async Task<IActionResult> Update(WeatherConditonDto wcDto)
        {
            await _service.UpdateAsync(_mapper.Map<WeatherCondition>(wcDto));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));      // 204 başarılı oldu, geriye bir şey dönmedi 
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var wc = await _service.GetByIdAsync(id);
            await _service.RemoveAsyn(wc);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(200));
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchPlanet(int id, [FromBody] WheatherConditionPatchDto wcPatchDto)
        {
            var existingWc = await _service.GetByIdAsync(id);
            if (existingWc == null)
            {
                return NotFound();
            }

            // DTO'daki null olmayan değerleri entity'ye aktarın
            _mapper.Map(wcPatchDto, existingWc);

            await _service.UpdateAsync(existingWc);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}
