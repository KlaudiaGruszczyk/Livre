namespace Domain.Entities
{
    public class ActivationLink
    {
        public Guid Id { get; set; }
        public Guid Token { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
