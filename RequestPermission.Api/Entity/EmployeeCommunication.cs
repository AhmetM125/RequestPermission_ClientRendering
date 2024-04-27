namespace RequestPermission.Api.Entity
{
    public class EmployeeCommunication : BaseEntity
    {
        private EmployeeCommunication(Guid eC_ID, string eC_PHONE, string eC_ADDRESS, string eC_CITY, string eC_COUNTRY, string eC_MOBILE_PHONE, string eC_EMAIL)
        {
            EC_ID = eC_ID;
            EC_PHONE = eC_PHONE;
            EC_ADDRESS = eC_ADDRESS;
            EC_CITY = eC_CITY;
            EC_COUNTRY = eC_COUNTRY;
            EC_MOBILE_PHONE = eC_MOBILE_PHONE;
            EC_EMAIL = eC_EMAIL;
        }
        // this page can be develop more like i add more table for let say phone and connect them one to many relationship and others to and we can have multiples address, phone, email etc.
        // but for now i just keep it simple and this is only learning purpose.
        public Guid EC_ID { get; set; }
        public string EC_PHONE { get; set; }
        public string EC_ADDRESS { get; set; }
        public string EC_CITY { get; set; }
        public string EC_COUNTRY { get; set; }
        public string EC_MOBILE_PHONE { get; set; }
        public string EC_EMAIL { get; set; }
        public Employee EMPLOYEE { get; set; }

        public static EmployeeCommunication CreateEmployeeCommunication_Email(string email)
        {
            return new EmployeeCommunication(Guid.NewGuid(), string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, email);
        }
    }
}
