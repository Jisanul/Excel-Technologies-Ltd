using LibraryManagementSystem.API_Setup;
using LibraryManagementSystem.Repository;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.APIs.Allergies
{
    public class InsertAllergies : IWebApi
    {
        public void Register(WebApplication app)
        {
            app.MapPost("/InsertAllergies", async ([FromBody] Models.Allergies allergies,
                                            [FromServices] IAllergiesRepository allergiesRepository,
                                            [FromServices] LinkGenerator linkGenerator) =>
            {
                allergies.AllergiesID = 0;
                await allergiesRepository.InsertAllergies(allergies);
                return Results.Created($"/GetAllergiesByID/{allergies.AllergiesID}", allergies);

            })
        .WithMetadata(new EndpointNameMetadata("InsertAllergies"));
        }
    }

}
