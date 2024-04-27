namespace RequestPermission.Api.Entity;

public class Employee : BaseEntity
{


    public Guid E_ID { get; set; }
    public string E_NAME { get; set; }
    public string E_SURNAME { get; set; }
    public string E_TITLE { get; set; }
    public int? E_DEPARTMENT { get; set; }
    public Guid? E_EMP_COMM_ID { get; set; }
    public Department DEPARTMENT { get; set; }
    public IEnumerable<Vacation> VACATIONS { get; set; }
    public IEnumerable<UserRole> USER_ROLES { get; set; }
    public EmployeeCommunication EMPLOYEE_COMMUNICATION { get; set; }
    public Security Security { get; set; }


    private Employee(Guid e_ID, string e_NAME, string e_SURNAME, EmployeeCommunication employeeCommunication)
    {
        E_ID = e_ID;
        E_NAME = e_NAME;
        E_SURNAME = e_SURNAME;
    }
    public Employee() { }
    internal static Employee CreateEmployeeForRegister(string lastName, string firstName, string email)
    {
        return new Employee(employeeCommunication: EmployeeCommunication.CreateEmployeeCommunication_Email(email), e_ID: Guid.NewGuid(), e_NAME: firstName, e_SURNAME: lastName);
    }
    internal  void UpdateEmployee(string lastName, string firstName, string email)
    {
        E_NAME = firstName;
        E_SURNAME = lastName;
        EMPLOYEE_COMMUNICATION.EC_EMAIL = email;
    }

}
