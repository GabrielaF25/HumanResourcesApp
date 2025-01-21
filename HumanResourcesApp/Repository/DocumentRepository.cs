using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public class DocumentRepository : IDocumentRepository
{
    private readonly HRDbContext _context;

    public DocumentRepository(HRDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Document>> GetAllDocumentsAsync()
    {
        // Ensure Documents table exists and is mapped in HRDbContext
        return await _context.Set<Document>() // Use DbSet<T> through Set<T>()
            .Include(d => d.Angajat)  // Include the related Angajat
            .ToListAsync();
    }

    public async Task<Document> GetDocumentByIdAsync(int id)
    {
        return await _context.Set<Document>()  // Use DbSet<T> through Set<T>()
            .Include(d => d.Angajat)  // Include the related Angajat
            .FirstOrDefaultAsync(d => d.Id == id);
    }

    public async Task<Document> CreateDocumentAsync(Document document)
    {
        _context.Set<Document>().Add(document);  // Use DbSet<T> through Set<T>()
        await _context.SaveChangesAsync();
        return document;
    }

    public async Task UpdateDocumentAsync(Document document)
    {
        var existingDocument = await _context.Set<Document>()  // Use DbSet<T> through Set<T>()
            .Include(d => d.Angajat)  // Include the related Angajat
            .FirstOrDefaultAsync(d => d.Id == document.Id);

        if (existingDocument != null)
        {
            _context.Entry(existingDocument).CurrentValues.SetValues(document);
            await _context.SaveChangesAsync();
        }
    }

    public async Task DeleteDocumentAsync(int id)
    {
        var document = await _context.Set<Document>().FindAsync(id);  // Use DbSet<T> through Set<T>()
        if (document != null)
        {
            _context.Set<Document>().Remove(document);  // Use DbSet<T> through Set<T>()
            await _context.SaveChangesAsync();
        }
        else
        {
            throw new KeyNotFoundException($"Documentul cu ID-ul {id} nu a fost găsit.");
        }
    }

    public async Task<bool> DocumentExistsAsync(int id)
    {
        return await _context.Set<Document>().AnyAsync(d => d.Id == id);  // Use DbSet<T> through Set<T>()
    }
}
