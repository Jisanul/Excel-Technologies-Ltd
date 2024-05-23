using LibraryManagementSystem.API_Setup;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Repository;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.APIs.Allergies
{
    public class GetAllergies : IWebApi
    {
        public void Register(WebApplication app)
        {
            app.MapGet("/GetAllergies", async ([FromServices] IAllergiesRepository allergiesRepository) =>
            {
                var allergies = await allergiesRepository.GetAllergies();
                return Results.Ok(allergies);
            })
        .WithMetadata(new EndpointNameMetadata("GetAllergies"));
        }
    }

}
