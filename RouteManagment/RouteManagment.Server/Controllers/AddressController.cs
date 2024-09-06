
using ManejoRutas.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using RouteManagment.Core.Entities;
using RouteManagment.Core.DTOs;
using AutoMapper;
using RouteManagment.Core.Interfaces;
using RouteManagment.Server.Responses;
using Microsoft.AspNetCore.Hosting.Server;



namespace RouteManagment.Server.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]

    //Request Managment

    public class AddressController : ControllerBase
    {
        private readonly IServiceR<Address> _addressService;
        private readonly IMapper _mapper;

        public AddressController(IServiceR<Address> addressService, IMapper mapper)
        {
            _addressService = addressService;
            _mapper = mapper;
        }
        //Request to get all address

        [HttpGet]
        public IActionResult GetAll()
        {
            var addresses =  _addressService.GetAll();
            var addressesDto = _mapper.Map<IEnumerable<AddressDto>>(addresses);
            var response = new ApiResponse<IEnumerable<AddressDto>>(addressesDto);
            return Ok(response);
        }

        //Request to get address by id 

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var address = await _addressService.GetById(id);
            var addressesDto = _mapper.Map<AddressDto>(address);
            var response = new ApiResponse<AddressDto>(addressesDto);


            return Ok(response);
        }

        //Request to create address
        [HttpPost]
        public async Task<IActionResult> Add(AddressDto addressDto)
        {
            var address = _mapper.Map<Address>(addressDto);
            await _addressService.Add(address);

            var response = new ApiResponse<AddressDto>(addressDto);

            return Ok(response);
        }

        //Request to update address
        [HttpPut("{id}")]

        public async Task<IActionResult> Update(int id, AddressDto addressDto)
        {
            var address = _mapper.Map<Address>(addressDto);
            address.Id = id;

            var result = await _addressService.Update(address);
            var response = new ApiResponse<Address>(result);
            return Ok(response);
        }
        //Request to remove address by id 
        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
           var result = await _addressService.Delete(id);
           var response = new ApiResponse<Address>(result);
           return Ok(response);
        }

    }
}

