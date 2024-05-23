using LibraryManagementSystem.API_Setup;
using LibraryManagementSystem.Repository;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.APIs.Patients
{
    public class DeletePatient : IWebApi
    {
        public void Register(WebApplication app)
        {
            app.MapDelete("/DeletePatient/{id}", async (int id,
                                                        [FromServices] IPatientsRepository patientRepository,
                                                        [FromServices] LinkGenerator linkGenerator) =>
            {
                await patientRepository.DeletePatient(id);
                return Results.Ok();
            })
            .WithMetadata(new EndpointNameMetadata("DeletePatient"));
        }
    }


}
