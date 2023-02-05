namespace Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string HashedPassword { get; set; }
        public string Email { get; set; }
    }
}

//bool czy ma ważną subskrypcje 