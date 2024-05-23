using LibraryManagementSystem.API_Setup;
using LibraryManagementSystem.Repository;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.APIs.InformationAPI
{
    public class DeleteDiseaseInformation : IWebApi
    {
        public void Register(WebApplication app)
        {
            app.MapDelete("/DeleteDiseaseInformation/{id}", async (int id,
                                                                  [FromServices] IDiseaseInformationRepository diseaseInformationRepository,
                                                                  [FromServices] LinkGenerator linkGenerator) =>
            {
                await diseaseInformationRepository.DeleteDiseaseInformation(id);
                return Results.Ok();
            })
            .WithMetadata(new EndpointNameMetadata("DeleteDiseaseInformation"));
        }
    }

}
