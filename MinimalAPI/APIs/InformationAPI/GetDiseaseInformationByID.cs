using LibraryManagementSystem.API_Setup;
using LibraryManagementSystem.Repository;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.APIs.InformationAPI
{
    public class GetDiseaseInformationByID : IWebApi
    {
        public void Register(WebApplication app)
        {
            app.MapGet("/GetDiseaseInformationByID/{id}", async (int id, [FromServices] IDiseaseInformationRepository diseaseInformationRepository) =>
            {
                var diseaseInfo = await diseaseInformationRepository.GetDiseaseInformationByID(id);
                return Results.Ok(diseaseInfo);
            })
            .WithMetadata(new EndpointNameMetadata("GetDiseaseInformationByID"));
        }
    }

}
