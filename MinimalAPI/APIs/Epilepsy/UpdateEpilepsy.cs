using LibraryManagementSystem.API_Setup;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Repository;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.APIs.Epilepsy
{
    public class UpdateEpilepsy : IWebApi
    {
        public void Register(WebApplication app)
        {
            app.MapPut("/UpdateEpilepsy/{id}", async ([FromRoute] int id,
                                                    [FromBody] PatientManagementSystem.Models.Epilepsy epilepsy,
                                                    [FromServices] IEpilepsyRepository epilepsyRepository) =>
            {
                var existingEpilepsy = await epilepsyRepository.GetEpilepsyByIdAsync(id);
                if (existingEpilepsy is null)
                {
                    return Results.NotFound();
                }

                await epilepsyRepository.UpdateEpilepsyAsync(id, epilepsy);
                return Results.NoContent();
            });
        }
    }

}
