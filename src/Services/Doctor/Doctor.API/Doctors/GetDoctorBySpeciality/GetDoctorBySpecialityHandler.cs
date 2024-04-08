
namespace Doctor.API.Doctors.GetDoctorBySpeciality;

public record GetDoctorBySpecialityQuery(string Speciality) : IQuery<GetDoctorBySpecialityResult>;
public record GetDoctorBySpecialityResult(IEnumerable<DoctorModel> Doctors);

internal class GetDoctorBySpecialityQueryHandler
    (IDocumentSession session)
    : IQueryHandler<GetDoctorBySpecialityQuery, GetDoctorBySpecialityResult>
{
    public async Task<GetDoctorBySpecialityResult> Handle(GetDoctorBySpecialityQuery query, CancellationToken cancellationToken)
    {
        var Doctors = await session.Query<DoctorModel>()
            .Where(p => p.Speciality.Contains(query.Speciality))
            .ToListAsync(cancellationToken);

        return new GetDoctorBySpecialityResult(Doctors);
    }
}
