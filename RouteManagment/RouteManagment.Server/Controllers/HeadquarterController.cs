
using AutoMapper;
using ManejoRutas.Core.Interfaces;
using ManejoRutas.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using RouteManagment.Core.DTOs;
using RouteManagment.Core.Entities;



namespace RouteManagment.Server.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]

    //Request Managment

    public class HeadquarterController : ControllerBase
    {
        private readonly IHeadquarterRespository _HeadquarterRepository;
        private readonly IMapper _mapper;

        public HeadquarterController(IHeadquarterRespository HeadquarterRepository, IMapper mapper)
        {
            _HeadquarterRepository = HeadquarterRepository;
            _mapper = mapper;
        }
        //Request to get all Headquarters

        [HttpGet]
        public async Task<IActionResult> GetHeadquarters()
        {
            var Headquarter = await _HeadquarterRepository.GetHeadquarters();
            var HeadquarterDto = _mapper.Map<IEnumerable<HeadquarterDto>>(Headquarter);
            return Ok(HeadquarterDto);
        }
        //Request to get Headquarter by id

        [HttpGet("{id}")]

        public async Task<IActionResult> GetHeadquarter(int id)
        {
            var Headquarter = await _HeadquarterRepository.GetHeadquarter(id);
            var documenTypeDto = _mapper.Map<HeadquarterDto>(Headquarter);
            return Ok(Headquarter);
        }

        //Request to create Headquarter

        [HttpPost]

        public async Task<IActionResult> PostHeadquarter(HeadquarterDto HeadquarterDto)
        {
            var Headquarter = _mapper.Map<Headquarter>(HeadquarterDto);
            await _HeadquarterRepository.PostHeadquarter(Headquarter);
            return Ok(Headquarter);
        }
            //Request to update Headquarter
            [HttpPut("{id}")]

            public async Task<IActionResult> UpdateHeadquarter(int id, HeadquarterDto HeadquarterDto)
            {
                var Headquarter = _mapper.Map<Headquarter>(HeadquarterDto);
                Headquarter.HeadQuarterId = id;

                await _HeadquarterRepository.UpdateHeadquarter(Headquarter);
                return Ok(Headquarter);
            }
            //Request to remove Headquarter by id 
            [HttpDelete("{id}")]

            public async Task<IActionResult> DeleteHeadquarter(int id)
            {
                {

                    var result = await _HeadquarterRepository.DeleteHeadquarter(id);
                    return Ok(result);
                }
            }
    } 
}

