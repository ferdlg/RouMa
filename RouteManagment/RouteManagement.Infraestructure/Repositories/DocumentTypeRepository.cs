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

        //Update DocumentType 

        public async Task<DocumentType> PutDocumentType(int id)
        {
            var DocumentType = _appDbContext.DocumentTypes.FirstOrDefaultAsync(DocumentType_x => DocumentType_x.DocumentTypeId == id);
            _appDbContext.DocumentTypes.Update(await DocumentType);
            await _appDbContext.SaveChangesAsync();
            return await DocumentType;
        }

        //Remove DocumentType by id 

        public async Task<DocumentType> DeleteDocumentType(int id)
        {
            var DocumentType = await _appDbContext.DocumentTypes.FirstOrDefaultAsync(DocumentType_x => DocumentType_x.DocumentTypeId == id);
            _appDbContext.DocumentTypes.Remove(DocumentType);
            await _appDbContext.SaveChangesAsync();
            return DocumentType;
        }
    }
}
