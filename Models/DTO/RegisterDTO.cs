namespace Models.DTO
{
    public class RegisterDTO
    {
        public required string UserName { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string MobileNumber { get; set; }
        public required string Password { get; set; }
    }
}
