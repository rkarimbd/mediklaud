namespace Doctor.API.Models;

public class DoctorModel
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!; 
    public string Email { get; set; } = default!;
    public string Mobile { get; set; } = default!;
    public string Address { get; set; } = default!;
    public List<string> Speciality { get; set; } = new();
    public string Qualification { get; set; } = default!;
}
