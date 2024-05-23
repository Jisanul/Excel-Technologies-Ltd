using LibraryManagementSystem.API_Setup;
using LibraryManagementSystem.Repository;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.APIs.Allergies
{
    public class GetAllergiesByID : IWebApi
    {
        public void Register(WebApplication app)
        {
            app.MapGet("/GetAllergiesByID", async (int id, [FromServices] IAllergiesRepository allergiesRepository) =>
            {
                var person = await allergiesRepository.GetAllergiesByID(id);
                return Results.Ok(person);
            })
        .WithMetadata(new EndpointNameMetadata("GetAllergiesByID"));
        }
    }
}
