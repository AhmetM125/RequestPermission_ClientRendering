using System.Text.Json.Serialization;

namespace RequestPermission_ClientRendering.ViewModels.Employees;

public class EmployeesGridVM
{
    public EmployeesGridVM(string name, string surname, string email, int department, string title)
    {
        Name = name;
        Surname = surname;
        Email = email;
        Department = department;
        Title = title;
        FullName = $"{name} {surname}";
    }

    public Guid Id { get; init; }
    public string Name { get; init; }
    public string Surname { get; init; }

    public string Email { get; init; }
    public int Department { get; init; }
    public string Title { get; init; }

    [JsonIgnore]
    public string FullName { get; init; }
}
