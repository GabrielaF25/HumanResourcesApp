using AutoMapper;
using HumanResourcesApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class DocumentController : ControllerBase
{
    private readonly IDocumentRepository _repository;
    private readonly IMapper _mapper;

    public DocumentController(IDocumentRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    // GET: api/Document
    [HttpGet]
    public async Task<ActionResult<IEnumerable<DocumentDTO>>> GetDocuments()
    {
        var documents = await _repository.GetAllDocumentsAsync();
        var documentDtos = _mapper.Map<IEnumerable<DocumentDTO>>(documents);
        return Ok(documentDtos);
    }

    // GET: api/Document/5
    [HttpGet("{id}", Name = "GetDocumentById")]
    public async Task<ActionResult<DocumentDTO>> GetDocumentById(int id)
    {
        var document = await _repository.GetDocumentByIdAsync(id);

        if (document == null)
        {
            return NotFound();
        }

        var documentDto = _mapper.Map<DocumentDTO>(document);
        return Ok(documentDto);
    }

    // GET: api/Document/count
    [HttpGet("count")]
    public async Task<IActionResult> GetDocumentCount()
    {
        var documents = await _repository.GetAllDocumentsAsync();
        var count = documents.Count();

        return Ok(count);
    }

    // POST: api/Document
    [HttpPost]
    public async Task<ActionResult<DocumentDTO>> PostDocument(DocumentDTO documentDto)
    {
        // Validate the input
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        // Map DTO to entity
        var document = _mapper.Map<Document>(documentDto);

        // Create the document through the repository
        var createdDocument = await _repository.CreateDocumentAsync(document);

        // Map back to DTO for response
        var createdDocumentDto = _mapper.Map<DocumentDTO>(createdDocument);

        // Return the created document with location in the response
        return CreatedAtAction(nameof(GetDocumentById), new { id = createdDocumentDto.Id }, createdDocumentDto);
    }

    // PUT: api/Document/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutDocument(int id, DocumentDTO documentDto)
    {
        if (id != documentDto.Id)
        {
            return BadRequest();
        }

        if (!await _repository.DocumentExistsAsync(id))
        {
            return NotFound();
        }

        var document = _mapper.Map<Document>(documentDto);
        await _repository.UpdateDocumentAsync(document);
        return NoContent();
    }

    // DELETE: api/Document/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDocument(int id)
    {
        if (!await _repository.DocumentExistsAsync(id))
        {
            return NotFound();
        }

        await _repository.DeleteDocumentAsync(id);
        return NoContent();
    }
}
