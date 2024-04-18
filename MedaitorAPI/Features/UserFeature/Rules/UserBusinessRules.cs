using System;
using MedaitorAPI.Entities;

namespace MedaitorAPI.Features.UserFeature.Rules;

public class UserBusinessRules
{
       public void UserNotBeEmpty(User? user)
    {
        if(user == null)
        {
            throw new Exception("User must not be empty");
        }
    }
}

