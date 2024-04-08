
namespace Doctor.API.Doctors.GetDoctorById;

//public record GetDoctorByIdRequest();
public record GetDoctorByIdResponse(DoctorModel Doctor);

public class GetDoctorByIdEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/Doctors/{id}", async (Guid id, ISender sender) =>
        {
            var result = await sender.Send(new GetDoctorByIdQuery(id));

            var response = result.Adapt<GetDoctorByIdResponse>();

            return Results.Ok(response);
        })
        .WithName("GetDoctorById")
        .Produces<GetDoctorByIdResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Get Doctor By Id")
        .WithDescription("Get Doctor By Id");
    }
}
