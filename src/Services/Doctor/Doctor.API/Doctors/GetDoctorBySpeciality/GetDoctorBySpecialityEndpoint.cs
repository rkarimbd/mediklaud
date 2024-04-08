
namespace Doctor.API.Doctors.GetDoctorBySpeciality;

//public record GetDoctorBySpecialityRequest();
public record GetDoctorBySpecialityResponse(IEnumerable<DoctorModel> Doctors);

public class GetDoctorBySpecialityEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/Doctors/Speciality/{Speciality}", 
            async (string Speciality, ISender sender) =>
        {
            var result = await sender.Send(new GetDoctorBySpecialityQuery(Speciality));
            
            var response = result.Adapt<GetDoctorBySpecialityResponse>();
            
            return Results.Ok(response);
        })
        .WithName("GetDoctorBySpeciality")
        .Produces<GetDoctorBySpecialityResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Get Doctor By Speciality")
        .WithDescription("Get Doctor By Speciality");
    }
}
