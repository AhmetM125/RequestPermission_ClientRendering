﻿namespace RequestPermission_ClientRendering.ViewModels.Employees;

public record EmployeeModifyVM
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string Position { get; set; }
    public string Title { get; set; }
}
