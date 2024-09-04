
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RouteManagment.Core.DTOs;
using RouteManagment.Core.Entities;
using RouteManagment.Core.Interfaces;
using RouteManagment.Server.Responses;



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
        public IActionResult GetAll()
        {
            var Headquarter =  _HeadquarterRepository.GetAll();
            var HeadquarterDto = _mapper.Map<IEnumerable<HeadquarterDto>>(Headquarter);
            var response = new ApiResponse<IEnumerable<HeadquarterDto>>(HeadquarterDto);
            return Ok(response);
        }
        //Request to get Headquarter by id

        [HttpGet("{id}")]

        public async Task<IActionResult> GetById(int id)
        {
            var Headquarter = await _HeadquarterRepository.GetById(id);
            var headQuarterDto = _mapper.Map<HeadquarterDto>(Headquarter);
            var response = new ApiResponse<HeadquarterDto>(headQuarterDto);
            return Ok(response);
        }

        //Request to create Headquarter

        [HttpPost]

        public async Task<IActionResult> Add(HeadquarterDto HeadquarterDto)
        {
            var Headquarter = _mapper.Map<Headquarter>(HeadquarterDto);
            await _HeadquarterRepository.Add(Headquarter);

            HeadquarterDto = _mapper.Map<HeadquarterDto>(Headquarter);
            var response = new ApiResponse<HeadquarterDto>(HeadquarterDto);
            return Ok(response);
        }
            //Request to update Headquarter
            [HttpPut("{id}")]

            public async Task<IActionResult> Update(int id, HeadquarterDto HeadquarterDto)
            {
                var Headquarter = _mapper.Map<Headquarter>(HeadquarterDto);
                Headquarter.Id = id;

                var result = await _HeadquarterRepository.Update(Headquarter);
                var response = new ApiResponse<bool>(result);
                return Ok(response);
            }
            //Request to remove Headquarter by id 
            [HttpDelete("{id}")]

            public async Task<IActionResult> Delete(int id)
            { 
               var result = await _HeadquarterRepository.Delete(id);
               var response = new ApiResponse<bool>(result);
               return Ok(response);
            }
    } 
}

