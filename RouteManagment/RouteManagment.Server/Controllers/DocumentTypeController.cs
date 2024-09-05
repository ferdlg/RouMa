
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

    public class DocumentTypeController : ControllerBase
    {
        private readonly IService<DocumentType> _documentTypeService;
        private readonly IMapper _mapper;

        public DocumentTypeController(IService<DocumentType> documentTypeService, IMapper mapper)
        {
            _documentTypeService = documentTypeService;
            _mapper = mapper;
        }
        //Request to get all DocumentTypes

        [HttpGet]
        public IActionResult GetAll()
        {
            var documentType =  _documentTypeService.GetAll();
            var documentTypeDto = _mapper.Map<IEnumerable<DocumentTypeDto>>(documentType);
            var response = new ApiResponse<IEnumerable<DocumentTypeDto>>(documentTypeDto);  

            return Ok(response);
        }
        //Request to get DocumentType by id

        [HttpGet("{id}")]

        public async Task<IActionResult> GetById(int id)
        {
            var documentType = await _documentTypeService.GetById(id);
            var documenTypeDto = _mapper.Map<DocumentTypeDto>(documentType);
            var response = new ApiResponse<DocumentTypeDto>(documenTypeDto);
            
            return Ok(response);
        }

        //Request to create DocumentType

        [HttpPost]

        public async Task<IActionResult> Add(DocumentTypeDto DocumentTypeDto)
        {
            var documentType = _mapper.Map<DocumentType>(DocumentTypeDto);
            await _documentTypeService.Add(documentType);
            return Ok(documentType);
        }
            //Request to update documentType
            [HttpPut("{id}")]

            public async Task<IActionResult> Update(int id, DocumentTypeDto documentTypeDto)
            {
                var documentType = _mapper.Map<DocumentType>(documentTypeDto);
                documentType.Id = id;

                var result= await _documentTypeService.Update(documentType);
                var response = new ApiResponse<DocumentType>(result);
            return Ok(response);
            }
            //Request to remove documentType by id 
            [HttpDelete("{id}")]

            public async Task<IActionResult> Delete(int id)
            {
                var repository= await _documentTypeService.Delete(id);
                var result = new ApiResponse<DocumentType>(repository);
                return Ok(result);
             
            }
    } 
}

