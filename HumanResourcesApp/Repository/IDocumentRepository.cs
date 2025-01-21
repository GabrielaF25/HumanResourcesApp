using System.Collections.Generic;
using System.Threading.Tasks;

public interface IDocumentRepository
{
    Task<IEnumerable<Document>> GetAllDocumentsAsync();
    Task<Document> GetDocumentByIdAsync(int id);
    Task<Document> CreateDocumentAsync(Document document);
    Task UpdateDocumentAsync(Document document);
    Task DeleteDocumentAsync(int id);
    Task<bool> DocumentExistsAsync(int id);
}
