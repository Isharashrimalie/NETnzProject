using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.Models.DTO;
using NZWalks.Models.Domain;
using NZWalks.Repositories;

namespace NZWalks.Controllers
{
    // /api/walks
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IWalkRepository walkRepository;

        public WalksController(IMapper mapper, IWalkRepository walkRepository)
        {
            this.mapper = mapper;
            this.walkRepository = walkRepository;
        }

        //Create walk
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddWalksRequestDto addWalkRequestDto)
        {
            if (ModelState.IsValid)
            {
                //map dto to domain model using automapper
                var walkDomainModel = mapper.Map<Walk>(addWalkRequestDto);

                await walkRepository.CreateAsync(walkDomainModel);

                //map domain model back to dto
                return Ok(mapper.Map<WalkDto>(walkDomainModel));

            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        //Get walks
        //GET: /api/walks?filterOn=Name&filterQuery=Track
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? filterOn, [FromQuery] string? filterQuery,
            [FromQuery] string? sortBy, [FromQuery] bool? isAscending)

        {
            try
            {
                var walksDomainModel = await walkRepository.GetAllAsync(filterOn, filterQuery, sortBy, isAscending ?? true);

                // Debug: Log the count
                Console.WriteLine($"Found {walksDomainModel?.Count ?? 0} walks");
                
                if (walksDomainModel == null || !walksDomainModel.Any())
                {
                    return Ok(new List<WalkDto>());
                }

                // Temporarily return raw data without mapping
                var walkDtos = walksDomainModel.Select(w => new WalkDto
                {
                    Id = w.Id,
                    Name = w.Name,
                    Description = w.Description,
                    LengthInKm = w.LengthInKm,
                    WalkImageUrl = w.WalkImageUrl,
                    Region = w.Region != null ? new RegionDto
                    {
                        Id = w.Region.Id,
                        Code = w.Region.Code,
                        Name = w.Region.Name,
                        RegionImageUrl = w.Region.RegionImageUrl
                    } : null,
                    Difficulity = w.Difficulity != null ? new DifficulityDto
                    {
                        Id = w.Difficulity.Id,
                        Name = w.Difficulity.Name
                    } : null
                }).ToList();
                
                // Debug: Log the mapped DTOs
                Console.WriteLine($"Mapped {walkDtos?.Count ?? 0} walk DTOs");
                
                return Ok(walkDtos);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetAll: {ex.Message}");
                Console.WriteLine($"StackTrace: {ex.StackTrace}");
                return StatusCode(500, new { error = ex.Message, details = ex.StackTrace });
            }
        }

        //Get walk by id
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var walkDomainModel = await walkRepository.GetByIdAsync(id);
            if (walkDomainModel == null)
            {
                return NotFound();
            }
            //map domain model to dto
            return Ok(mapper.Map<WalkDto>(walkDomainModel));
        }

        //Update walk
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, UpdateWalkRequestDto updateWalkRequestDto)
        {
            if (!ModelState.IsValid)
            {//map dto to domain model
                var walkDomainModel = mapper.Map<Walk>(updateWalkRequestDto);
                walkDomainModel = await walkRepository.UpdateAsync(id, walkDomainModel);


                if (walkDomainModel == null)
                {
                    return NotFound();
                }
                //map domain model to dto
                return Ok(mapper.Map<WalkDto>(walkDomainModel));
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        //Delete walk
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var deletedWalk = await walkRepository.DeleteAsync(id);
            if (deletedWalk == null)
            {
                return NotFound();
            }
            //map domain model to dto
            return Ok(mapper.Map<WalkDto>(deletedWalk));
        }

    }

}
