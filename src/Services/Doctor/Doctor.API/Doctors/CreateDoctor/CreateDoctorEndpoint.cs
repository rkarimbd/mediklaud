using Doctor.API.Doctors.CreateDoctor;
using MediatR;
using Carter;
using Mapster;

namespace Doctor.API.Doctors.CreateDoctor;



public record CreateDoctorRequest(string Name, string Email, string Mobile, string Address, List<string> Speciality, string Qualification);

public record CreateDoctorResponse(Guid Id);

public class CreateDoctorEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/doctors",
            async (CreateDoctorRequest request, ISender sender) =>
            {
                var command = request.Adapt<CreateDoctorCommand>();

                var result = await sender.Send(command);

                var response = result.Adapt<CreateDoctorResponse>();

                return Results.Created($"/doctors/{response.Id}", response);

            })
        .WithName("CreateDoctor")
        .Produces<CreateDoctorResponse>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Create Doctor")
        .WithDescription("Create Doctor");
    }
}
