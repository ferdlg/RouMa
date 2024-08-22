
using ManejoRutas.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using RouteManagment.Core.Entities;
using RouteManagment.Core.DTOs;
using AutoMapper;
using RouteManagment.Core.Interfaces;



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
        public async Task<IActionResult> GetAll()
        {
            var addresses = await _addressRepository.GetAll();
            var addressesDto = _mapper.Map<IEnumerable<AddressDto>>(addresses);
            return Ok(addressesDto);
        }

        //Request to get address by id 

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var address = await _addressRepository.GetById(id);
            var addressesDto = _mapper.Map<AddressDto>(address);

            return Ok(address);
        }

        //Request to create address
        [HttpPost]
        public async Task<IActionResult> Add(AddressDto addressDto)
        {
            var address = _mapper.Map<Address>(addressDto);

            await _addressRepository.Add(address);
            return Ok(address);
        }

        //Request to update address
        [HttpPut("{id}")]

        public async Task<IActionResult> Update(int id, AddressDto addressDto)
        {
            var address = _mapper.Map<Address>(addressDto);
            address.Id = id;

            await _addressRepository.Update(address);
            return Ok(address);
        }
        //Request to remove address by id 
        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
            {
                
                await _addressRepository.Delete(id);
                return Ok();
            }
        }

    }
}

