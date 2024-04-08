using Marten.Pagination;

namespace Doctor.API.Doctors.GetDoctors;

public record GetDoctorsQuery(int? PageNumber = 1, int? PageSize = 10) : IQuery<GetDoctorsResult>;
public record GetDoctorsResult(IEnumerable<DoctorModel> Doctors);

internal class GetDoctorsQueryHandler
    (IDocumentSession session)
    : IQueryHandler<GetDoctorsQuery, GetDoctorsResult>
{
    public async Task<GetDoctorsResult> Handle(GetDoctorsQuery query, CancellationToken cancellationToken)
    {
        var Doctors = await session.Query<DoctorModel>()
            .ToPagedListAsync(query.PageNumber ?? 1, query.PageSize ?? 10, cancellationToken);

        return new GetDoctorsResult(Doctors);
    }
}
