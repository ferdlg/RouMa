using ManejoRutas.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using RouteManagment.Core.Entities;
using RouteManagment.Server.Data;

namespace ManejoRutas.Infrastructure.Repositories
{
    public class DocumentTypeRepository : IDocumentTypeRepository
    {
        //logic for Crud Methods 

        private readonly AppDbContext _appDbContext;

        public DocumentTypeRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        //List all DocumentTypes
        public async Task<IEnumerable<DocumentType>> GetDocumentTypes()
        {
            var DocumentTypes = await _appDbContext.DocumentTypes.ToListAsync();
            return DocumentTypes;
        }

        //List DocumentType by id 
        public async Task<DocumentType> GetDocumentType(int id)
        {
            var DocumentType = await _appDbContext.DocumentTypes.FirstOrDefaultAsync(DocumentType_x => DocumentType_x.DocumentTypeId == id);
            return DocumentType;
        }

        // Create DocumentType

        public async Task PostDocumentType(DocumentType DocumentType)
        {
            _appDbContext.DocumentTypes.Add(DocumentType);
            await _appDbContext.SaveChangesAsync();

        }

        // Update documentType by id 
        public async Task<bool> UpdateDocumentType(DocumentType documentType)
        {
            var up_documentType = await GetDocumentType(documentType.DocumentTypeId);
            up_documentType.Name = documentType.Name;
            up_documentType.Description = documentType.Description;

            int rows = await _appDbContext.SaveChangesAsync();
            return rows > 0;
        }


        // Remove documentType by id
        public async Task<bool> DeleteDocumentType(int id)
        {
            var up_documentType = await GetDocumentType(id);
            _appDbContext.DocumentTypes.Remove(up_documentType);
            int rows = await _appDbContext.SaveChangesAsync();
            return rows > 0;
        }
    }
}
