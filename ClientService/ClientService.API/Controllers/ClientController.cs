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
    public async Task<ActionResult<PagedResult<ClientForAdminDto>>> GetAllClientsAsync([FromQuery] GetClientDto getClient, CancellationToken cancellationToken)
    {
        var result = await clientService.GetAllAsync(
            getClient.PageNumber,
            getClient.PageSize, 
            cancellationToken);
         
        return Ok(result);
    }

    [HttpPut]
    public async Task<ActionResult> UpdateClientAsync(UpdateClientDto updateDto, CancellationToken cancellationToken)
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
    public async Task<ActionResult<int>> CountByGenderAsync(ClientGender clientGender, CancellationToken cancellationToken)
    {
        var count = await clientService.CountByGenderAsync(clientGender, cancellationToken);
        return Ok(count);
    }

    [HttpGet("gender/{clientGender}")]
    public async Task<ActionResult> GetClientsByGender([FromQuery] ClientsByGenderDto query, CancellationToken cancellationToken)
    {
       var client = await clientService.GetClientByGenderAsync(
           query.PageNumber,
           query.PageSize,
           query.ClientGender,
           cancellationToken);

        return Ok(client);
    }
}
