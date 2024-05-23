using LibraryManagementSystem.API_Setup;
using LibraryManagementSystem.Repository;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.APIs.Epilepsy
{
    public class DeleteEpilepsy : IWebApi
    {
        public void Register(WebApplication app)
        {
            app.MapDelete("/DeleteEpilepsy/{id}", async ([FromRoute] int id,
                                                          [FromServices] IEpilepsyRepository epilepsyRepository) =>
            {
                var existingEpilepsy = await epilepsyRepository.GetEpilepsyByIdAsync(id);
                if (existingEpilepsy is null)
                {
                    return Results.NotFound();
                }

                await epilepsyRepository.DeleteEpilepsyAsync(id);
                return Results.NoContent();
            });
        }
    }


}
