using ClientService.DataAccess.Enums;

namespace ClientService.Business.DTOs;

public class ClientsByGenderDto
{
    public int PageSize { get; set; }

    public int PageNumber { get; set; }

    public ClientGender ClientGender { get; set; }
}
