using Job.Hangfire.Backend.Application.Models.Request;
using Job.Hangfire.Backend.Application.Models.Response;
using Job.Hangfire.Backend.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Job.Hangfire.Backend.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmailController : ControllerBase
{
    private readonly IEmailService _emailService;

    public EmailController(IEmailService emailService)
    {
        _emailService = emailService;
    }

    /// <summary> Cria um novo e-mail </summary>
    /// <remarks>
    /// Exemplo de requisição:
    /// 
    ///     POST /api/email
    ///     {
    ///        "recipient": "john.doe@example.com",
    ///        "subject": "Bem-vindo!",
    ///        "body": "Obrigado por se cadastrar no nosso serviço."
    ///     }
    ///     
    /// </remarks>
    /// <param name="request">Dados do e-mail</param>
    /// <returns>Retorna o e-mail criado</returns>
    /// <response code="200">OK - E-mail criado com sucesso</response>
    /// <response code="400">Bad Request - Requisição do E-mail é Inválida</response>
    [HttpPost]
    [ProducesResponseType(typeof(GenericHttpResponse<EmailResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(GenericHttpResponse<>), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateEmailAsync([FromBody] EmailRequest request)
    {
        var response = await _emailService.CreateAsync(request);
        return Ok(new GenericHttpResponse<EmailResponse>
        {
            Data = response
        });
    }

    /// <summary> Obtém um e-mail pelo ID </summary>
    /// <remarks>
    /// Exemplo de requisição:
    /// 
    ///     GET /api/email/{id}
    ///     
    /// </remarks>
    /// <param name="id">ID do e-mail</param>
    /// <returns>Retorna o e-mail correspondente</returns>
    /// <response code="200">OK - E-mail encontrado</response>
    /// <response code="400">Bad Request - Requisição do E-mail é Inválida</response>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(GenericHttpResponse<EmailResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(GenericHttpResponse<>), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetEmailByIdAsync(Guid id)
    {
        var response = await _emailService.GetByIdAsync(id);
        return Ok(new GenericHttpResponse<EmailResponse>
        {
            Data = response
        });
    }

    /// <summary> Obtém todos os e-mails </summary>
    /// <remarks>
    /// Exemplo de requisição:
    /// 
    ///     GET /api/email
    ///     
    /// </remarks>
    /// <returns>Retorna uma lista de e-mails</returns>
    /// <response code="200">OK - E-mails encontrados</response>
    /// <response code="400">Bad Request - Requisição do E-mail é Inválida</response>
    [HttpGet]
    [ProducesResponseType(typeof(GenericHttpResponse<IEnumerable<EmailResponse>>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(GenericHttpResponse<>), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetAllEmailsAsync()
    {
        var response = await _emailService.GetAllAsync();
        return Ok(new GenericHttpResponse<IEnumerable<EmailResponse>>
        {
            Data = response
        });
    }

    /// <summary> Atualiza um e-mail pelo ID </summary>
    /// <remarks>
    /// Exemplo de requisição:
    /// 
    ///     PUT /api/email/{id}
    ///     {
    ///        "recipient": "john.doe@example.com",
    ///        "subject": "Assunto Atualizado",
    ///        "body": "Conteúdo atualizado do corpo do e-mail."
    ///     }
    ///     
    /// </remarks>
    /// <param name="id">ID do e-mail</param>
    /// <param name="request">Dados do e-mail</param>
    /// <returns>Retorna o e-mail atualizado</returns>
    /// <response code="200">OK - E-mail atualizado com sucesso</response>
    /// <response code="400">Bad Request - Requisição do E-mail é Inválida</response>
    [HttpPut("{id}")]
    [ProducesResponseType(typeof(GenericHttpResponse<EmailResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(GenericHttpResponse<>), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateEmailAsync(Guid id, [FromBody] EmailRequest request)
    {
        var response = await _emailService.UpdateAsync(id, request);
        return Ok(new GenericHttpResponse<EmailResponse>
        {
            Data = response
        });
    }

    /// <summary> Deleta um e-mail pelo ID </summary>
    /// <remarks>
    /// Exemplo de requisição:
    /// 
    ///     DELETE /api/email/{id}
    ///     
    /// </remarks>
    /// <param name="id">ID do e-mail</param>
    /// <response code="204">No Content - E-mail deletado com sucesso</response>
    /// <response code="400">Bad Request - Requisição do E-mail é Inválida</response>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(GenericHttpResponse<>), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> DeleteEmailAsync(Guid id)
    {
        await _emailService.DeleteByIdAsync(id);
        return NoContent();
    }
}
