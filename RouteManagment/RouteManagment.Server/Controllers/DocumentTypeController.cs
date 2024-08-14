
using AutoMapper;
using ManejoRutas.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using RouteManagment.Core.DTOs;
using RouteManagment.Core.Entities;



namespace RouteManagment.Server.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]

    //Request Managment

    public class DocumentTypeController : ControllerBase
    {
        private readonly IDocumentTypeRepository _DocumentTypeRepository;
        private readonly IMapper _mapper;

        public DocumentTypeController(IDocumentTypeRepository DocumentTypeRepository, IMapper mapper)
        {
            _DocumentTypeRepository = DocumentTypeRepository;
            _mapper = mapper;
        }
        //Request to get all DocumentTypes

        [HttpGet]
        public async Task<IActionResult> GetdocumentTypes()
        {
            var documentType = await _DocumentTypeRepository.GetDocumentTypes();
            var documentTypeDto = _mapper.Map<IEnumerable<DocumentTypeDto>>(documentType);
            return Ok(documentTypeDto);
        }
        //Request to get DocumentType by id

        [HttpGet("{id}")]

        public async Task<IActionResult> GetdocumentType(int id)
        {
            var documentType = await _DocumentTypeRepository.GetDocumentType(id);
            var documenTypeDto = _mapper.Map<DocumentTypeDto>(documentType);
            return Ok(documentType);
        }

        //Request to create DocumentType

        [HttpPost]

        public async Task<IActionResult> PostDocumentType(DocumentTypeDto DocumentTypeDto)
        {
            var documentType = _mapper.Map<DocumentType>(DocumentTypeDto);
            await _DocumentTypeRepository.PostDocumentType(documentType);
            return Ok(documentType);
        }

        //Request to update DocumentType
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDocumentType(int id)
        {
            var documentType = await _DocumentTypeRepository.PutDocumentType(id);
            var documenTypeDto = _mapper.Map<DocumentTypeDto>(documentType);
            return Ok(documenTypeDto);
        }

        //Request to remove DocumentType 
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDocumentType(int id)
        {
            var documentType = await _DocumentTypeRepository.DeleteDocumentType(id);
            var documenTypeDto = _mapper.Map<DocumentTypeDto>(documentType);
            return Ok(documenTypeDto);
        }

    } 
}

