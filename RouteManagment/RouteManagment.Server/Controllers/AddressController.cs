
using ManejoRutas.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using RouteManagment.Core.Entities;
using RouteManagment.Core.DTOs;
using AutoMapper;
using RouteManagment.Core.Interfaces;
using RouteManagment.Server.Responses;



namespace RouteManagment.Server.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]

    //Request Managment

    public class AddressController : ControllerBase
    {
        private readonly IRepository<Address> _addressRepository;
        private readonly IMapper _mapper;

        public AddressController(IRepository<Address> addressRepository, IMapper mapper)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
        }
        //Request to get all address

        [HttpGet]
        public IActionResult GetAll()
        {
            var addresses =  _addressRepository.GetAll();
            var addressesDto = _mapper.Map<IEnumerable<AddressDto>>(addresses);
            var response = new ApiResponse<IEnumerable<AddressDto>>(addressesDto);
            return Ok(response);
        }

        //Request to get address by id 

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var address = await _addressRepository.GetById(id);
            var addressesDto = _mapper.Map<AddressDto>(address);
            var response = new ApiResponse<AddressDto>(addressesDto);


            return Ok(response);
        }

        //Request to create address
        [HttpPost]
        public async Task<IActionResult> Add(AddressDto addressDto)
        {
            var address = _mapper.Map<Address>(addressDto);
            await _addressRepository.Add(address);

            var response = new ApiResponse<AddressDto>(addressDto);

            return Ok(response);
        }

        //Request to update address
        [HttpPut("{id}")]

        public async Task<IActionResult> Update(int id, AddressDto addressDto)
        {
            var address = _mapper.Map<Address>(addressDto);
            address.Id = id;

            var result = await _addressRepository.Update(address);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
        //Request to remove address by id 
        [HttpDelete("{id}")]

        public void Delete(int id)
        {
           var repository =  _addressRepository.Delete(id);
           var response = new ApiResponse<bool>(repository);
           return Ok(response);
        }

    }
}

