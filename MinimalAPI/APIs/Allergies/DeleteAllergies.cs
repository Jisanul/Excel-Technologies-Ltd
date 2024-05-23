using LibraryManagementSystem.API_Setup;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Repository;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.APIs.Allergies
{
    public class DeleteAllergies : IWebApi
    {
        public void Register(WebApplication app)
        {
            app.MapDelete("/Deleteallergies/{id}", async (int id,
                                            [FromServices] IAllergiesRepository allergiesRepository,
                                            [FromServices] LinkGenerator linkGenerator) =>
            {

                await allergiesRepository.DeleteAllergies(id);
                return Results.Ok();
            })
            .WithMetadata(new EndpointNameMetadata("Deleteallergies"));
        }
    }
}
