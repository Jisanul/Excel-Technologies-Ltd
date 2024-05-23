using LibraryManagementSystem.API_Setup;
using LibraryManagementSystem.Repository;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.APIs.InformationAPI
{
    public class UpdateDiseaseInformation : IWebApi
    {
        public void Register(WebApplication app)
        {
            app.MapPut("/UpdateDiseaseInformation", async ([FromBody] Models.DiseaseInformation diseaseInformation,
                                                           [FromServices] IDiseaseInformationRepository diseaseInformationRepository) =>
            {
                if (diseaseInformation != null)
                {
                    await diseaseInformationRepository.UpdateDiseaseInformation(diseaseInformation);
                    return Results.Ok();
                }
                return Results.NoContent();
            })
            .WithMetadata(new EndpointNameMetadata("UpdateDiseaseInformation"));
        }
    }

}
