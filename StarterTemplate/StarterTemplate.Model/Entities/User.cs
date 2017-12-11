namespace StarterTemplate.Model
{
    public class User : AuditableEntity<long>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string EmailAddress { get; set; }

        public string PhoneNumber { get; set; }

        public string Password { get; set; }
    }
}
