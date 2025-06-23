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
            //map dto to domain model using automapper
            var walkDomainModel = mapper.Map<Walk>(addWalkRequestDto);

            await walkRepository.CreateAsync(walkDomainModel);

            //map domain model back to dto
            return Ok(mapper.Map<WalkDto>(walkDomainModel));

        }

        //Get walks
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var walksDomainModel = await walkRepository.GetAllAsync();

            //map domain model to dto
            return Ok(mapper.Map<List<WalkDto>>(walksDomainModel));

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
            //map dto to domain model
            var walkDomainModel = mapper.Map<Walk>(updateWalkRequestDto);
            walkDomainModel = await walkRepository.UpdateAsync(id, walkDomainModel);


            if (walkDomainModel == null)
            {
                return NotFound();
            }
            //map domain model to dto
            return Ok(mapper.Map<WalkDto>(walkDomainModel));
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
