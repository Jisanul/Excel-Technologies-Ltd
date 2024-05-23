using LibraryManagementSystem.API_Setup;
using LibraryManagementSystem.Repository;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.APIs.Allergies_Details
{
    public class DeleteAllergies_Details : IWebApi
    {
        public void Register(WebApplication app)
        {
            app.MapDelete("/DeleteAllergies_Details/{id}", async (int id,
                                                                 [FromServices] IAllergies_DetailsRepository allergiesDetailsRepository,
                                                                 [FromServices] LinkGenerator linkGenerator) =>
            {
                await allergiesDetailsRepository.DeleteAllergies_Details(id);
                return Results.Ok();
            })
            .WithMetadata(new EndpointNameMetadata("DeleteAllergies_Details"));
        }
    }

}
