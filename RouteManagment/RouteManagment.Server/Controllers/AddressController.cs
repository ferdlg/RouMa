
using ManejoRutas.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using RouteManagment.Core.Entities;
using RouteManagment.Core.DTOs;
using AutoMapper;



namespace RouteManagment.Server.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]

    //Request Managment

    public class AddressController : ControllerBase
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;

        public AddressController(IAddressRepository addressRepository, IMapper mapper)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
        }
        //Request to get all address

        [HttpGet]
        public async Task<IActionResult> GetAddresses()
        {
            var addresses = await _addressRepository.GetAddresses();
            var addressesDto = _mapper.Map<IEnumerable<AddressDto>>(addresses);
            return Ok(addressesDto);
        }

        //Request to get address by id 

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAddresses(int id)
        {
            var address = await _addressRepository.GetAddress(id);
            var addressesDto = _mapper.Map<AddressDto>(address);

            return Ok(address);
        }

        //Request to create address
        [HttpPost]
        public async Task<IActionResult> PostAddress(AddressDto addressDto)
        {
            var address = _mapper.Map<Address>(addressDto);

            await _addressRepository.PostAddress(address);
            return Ok(address);
        }

        //Request to update address
        [HttpPut("{id}")]

        public async Task<IActionResult> PutAddress(int id)
        {
            var address = await _addressRepository.PutAddress(id);
            var addressesDto = _mapper.Map<AddressDto>(address);
            return Ok(addressesDto);
        }
        //Request to remove address by id 
        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteAddress(int id)
        {
            {
                var address = await _addressRepository.DeleteAddress(id);
                var addressesDto = _mapper.Map<AddressDto>(address);
                return Ok(addressesDto);
            }
        }

    }
}
