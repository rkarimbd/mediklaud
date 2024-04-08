
namespace Doctor.API.Doctors.DeleteDoctor;

//public record DeleteDoctorRequest(Guid Id);
public record DeleteDoctorResponse(bool IsSuccess);

public class DeleteDoctorEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/Doctors/{id}", async (Guid id, ISender sender) =>
        {
            var result = await sender.Send(new DeleteDoctorCommand(id));

            var response = result.Adapt<DeleteDoctorResponse>();

            return Results.Ok(response);
        })
        .WithName("DeleteDoctor")
        .Produces<DeleteDoctorResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Delete Doctor")
        .WithDescription("Delete Doctor");
    }
}
