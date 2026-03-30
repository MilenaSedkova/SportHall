using ClientService.Business.DTOs;
using ClientService.Business.Interfaces;
using ClientService.DataAccess.Enums;
using ClientService.DataAccess.PagedResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClientService.API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class ClientController(IClientService clientService): ControllerBase
{
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<ClientForAdminDto>> GetClientByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var client = await clientService.GetClientByIdAsync(id, cancellationToken);
        return Ok(client);
    }

    [HttpGet]
    public async Task<ActionResult<PagedResult<ClientForAdminDto>>> GetAllClientsAsync(int pageSize, int pageNumber, CancellationToken cancellationToken)
    {
        var result = await clientService.GetAllAsync(pageSize, pageNumber, cancellationToken);
        return Ok(result);
    }

    [HttpPut]
    public async Task<ActionResult> UpdateClientAsync(UpdateDto updateDto, CancellationToken cancellationToken)
    {
        await clientService.UpdateClientAsync(updateDto, cancellationToken);
        return NoContent();
    }

    [HttpPost]
    public async Task<ActionResult<ClientForAdminDto>> CreateClientAsync(CreateClientDto createClientDto, CancellationToken cancellationToken)
    {
        var created = await clientService.CreateClientAsync(createClientDto, cancellationToken);
        return Ok(created);
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> DeleteClientAsync(Guid id, CancellationToken cancellationToken)
    {
        await clientService.DeleteClientAsync(id, cancellationToken);
        return NoContent();
    }

    [HttpGet("gender/{clientGender}/count")]
    public async Task<ActionResult<int>> CountOfClientByGenderasync(ClientGender clientGender, CancellationToken cancellationToken)
    {
        var count = await clientService.CountByGenderAsync(clientGender, cancellationToken);
        return Ok(count);
    }

    [HttpGet("gender/{clientGender}")]
    public async Task<ActionResult> GetClientsByGender(int pageSize, int pageNumber, ClientGender clientGender, CancellationToken cancellationToken)
    {
       var client = await clientService.GetClientByGenderAsync(pageSize, pageNumber, clientGender, cancellationToken);
        return Ok(client);
    }
}
