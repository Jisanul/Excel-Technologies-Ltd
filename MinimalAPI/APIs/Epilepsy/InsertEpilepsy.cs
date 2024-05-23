using LibraryManagementSystem.API_Setup;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Repository;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.APIs.Epilepsy
{
    public class InsertEpilepsy : IWebApi
    {
        public void Register(WebApplication app)
        {
            app.MapPost("/InsertEpilepsy", async ([FromBody] PatientManagementSystem.Models.Epilepsy epilepsy,
                                                   [FromServices] IEpilepsyRepository epilepsyRepository) =>
            {
                await epilepsyRepository.InsertEpilepsyAsync(epilepsy);
                return Results.Created($"/GetEpilepsyById/{epilepsy}", epilepsy);
            });
        }
    }

}
