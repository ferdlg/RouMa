using RouteManagment.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManejoRutas.Core.Interfaces
{
    public interface IDocumentTypeRepository
    {
        Task<IEnumerable<DocumentType>> GetDocumentTypes();
        Task<DocumentType> GetDocumentType(int id);
        Task PostDocumentType(DocumentType DocumentType);
        Task<DocumentType> PutDocumentType(int id);

        Task<DocumentType> DeleteDocumentType(int id);
    }
}
