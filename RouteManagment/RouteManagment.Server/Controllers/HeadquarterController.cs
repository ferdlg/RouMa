
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RouteManagment.Core.DTOs;
using RouteManagment.Core.Entities;
using RouteManagment.Core.Interfaces;



namespace RouteManagment.Server.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]

    //Request Managment

    public class HeadquarterController : ControllerBase
    {
        private readonly IRepository<Headquarter> _HeadquarterRepository;
        private readonly IMapper _mapper;

        public HeadquarterController(IRepository<Headquarter> HeadquarterRepository, IMapper mapper)
        {
            _HeadquarterRepository = HeadquarterRepository;
            _mapper = mapper;
        }
        //Request to get all Headquarters

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Headquarter = await _HeadquarterRepository.GetAll();
            var HeadquarterDto = _mapper.Map<IEnumerable<HeadquarterDto>>(Headquarter);
            return Ok(HeadquarterDto);
        }
        //Request to get Headquarter by id

        [HttpGet("{id}")]

        public async Task<IActionResult> GetById(int id)
        {
            var Headquarter = await _HeadquarterRepository.GetById(id);
            var documenTypeDto = _mapper.Map<HeadquarterDto>(Headquarter);
            return Ok(Headquarter);
        }

        //Request to create Headquarter

        [HttpPost]

        public async Task<IActionResult> Add(HeadquarterDto HeadquarterDto)
        {
            var Headquarter = _mapper.Map<Headquarter>(HeadquarterDto);
            await _HeadquarterRepository.Add(Headquarter);
            return Ok(Headquarter);
        }
            //Request to update Headquarter
            [HttpPut("{id}")]

            public async Task<IActionResult> Update(int id, HeadquarterDto HeadquarterDto)
            {
                var Headquarter = _mapper.Map<Headquarter>(HeadquarterDto);
                Headquarter.Id = id;

                await _HeadquarterRepository.Update(Headquarter);
                return Ok(Headquarter);
            }
            //Request to remove Headquarter by id 
            [HttpDelete("{id}")]

            public async Task<IActionResult> Delete(int id)
            {
                {

                    await _HeadquarterRepository.Delete(id);
                    return Ok();
                }
            }
    } 
}

