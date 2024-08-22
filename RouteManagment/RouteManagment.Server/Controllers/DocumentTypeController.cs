
using AutoMapper;
using ManejoRutas.Core.Interfaces;
using ManejoRutas.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using RouteManagment.Core.DTOs;
using RouteManagment.Core.Entities;
using RouteManagment.Core.Interfaces;



namespace RouteManagment.Server.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]

    //Request Managment

    public class DocumentTypeController : ControllerBase
    {
        private readonly IRepository<DocumentType> _DocumentTypeRepository;
        private readonly IMapper _mapper;

        public DocumentTypeController(IRepository<DocumentType> DocumentTypeRepository, IMapper mapper)
        {
            _DocumentTypeRepository = DocumentTypeRepository;
            _mapper = mapper;
        }
        //Request to get all DocumentTypes

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var documentType = await _DocumentTypeRepository.GetAll();
            var documentTypeDto = _mapper.Map<IEnumerable<DocumentTypeDto>>(documentType);
            return Ok(documentTypeDto);
        }
        //Request to get DocumentType by id

        [HttpGet("{id}")]

        public async Task<IActionResult> GetById(int id)
        {
            var documentType = await _DocumentTypeRepository.GetById(id);
            var documenTypeDto = _mapper.Map<DocumentTypeDto>(documentType);
            return Ok(documentType);
        }

        //Request to create DocumentType

        [HttpPost]

        public async Task<IActionResult> Add(DocumentTypeDto DocumentTypeDto)
        {
            var documentType = _mapper.Map<DocumentType>(DocumentTypeDto);
            await _DocumentTypeRepository.Add(documentType);
            return Ok(documentType);
        }
            //Request to update documentType
            [HttpPut("{id}")]

            public async Task<IActionResult> Update(int id, DocumentTypeDto documentTypeDto)
            {
                var documentType = _mapper.Map<DocumentType>(documentTypeDto);
                documentType.Id = id;

                await _DocumentTypeRepository.Update(documentType);
                return Ok(documentType);
            }
            //Request to remove documentType by id 
            [HttpDelete("{id}")]

            public async Task<IActionResult> Delete(int id)
            {
                {

                    await _DocumentTypeRepository.Delete(id);
                    return Ok();
                }
            }
    } 
}

