namespace Doctor.API.Doctors.GetDoctorById;

public record GetDoctorByIdQuery(Guid Id) : IQuery<GetDoctorByIdResult>;
public record GetDoctorByIdResult(DoctorModel Doctor);

internal class GetDoctorByIdQueryHandler
    (IDocumentSession session)
    : IQueryHandler<GetDoctorByIdQuery, GetDoctorByIdResult>
{
    public async Task<GetDoctorByIdResult> Handle(GetDoctorByIdQuery query, CancellationToken cancellationToken)
    {
        var Doctor = await session.LoadAsync<DoctorModel>(query.Id, cancellationToken);

        if (Doctor is null)
        {
            //throw new DoctorNotFoundException(query.Id);
        }

        return new GetDoctorByIdResult(Doctor);
    }
}
