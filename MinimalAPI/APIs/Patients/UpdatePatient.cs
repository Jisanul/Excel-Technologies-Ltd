using LibraryManagementSystem.API_Setup;
using LibraryManagementSystem.Repository;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.APIs.Patients
{
    public class UpdatePatient : IWebApi
    {
        public void Register(WebApplication app)
        {
            app.MapPut("/UpdatePatient", async ([FromBody] Models.Patient patient,
                                                [FromServices] IPatientsRepository patientRepository) =>
            {
                if (patient != null)
                {
                    await patientRepository.UpdatePatient(patient);
                    return Results.Ok();
                }
                return Results.NoContent();
            })
            .WithMetadata(new EndpointNameMetadata("UpdatePatient"));
        }
    }

}
