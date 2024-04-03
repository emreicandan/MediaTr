using System;
namespace MedaitorAPI.Features.UserFeature.DTOs;

public class UserGetByIdDto
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}

