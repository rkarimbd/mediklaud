
namespace Doctor.API.Doctors.UpdateDoctor;

public record UpdateDoctorRequest(Guid Id, string Name, string Email, string Mobile, string Address, List<string> Speciality, string Qualification);
public record UpdateDoctorResponse(bool IsSuccess);

public class UpdateDoctorEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/Doctors", 
            async (UpdateDoctorRequest request, ISender sender) =>
            {
                var command = request.Adapt<UpdateDoctorCommand>();

                var result = await sender.Send(command);

                var response = result.Adapt<UpdateDoctorResponse>();

                return Results.Ok(response);
            })
            .WithName("UpdateDoctor")
            .Produces<UpdateDoctorResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("Update Doctor")
            .WithDescription("Update Doctor");
    }
}
