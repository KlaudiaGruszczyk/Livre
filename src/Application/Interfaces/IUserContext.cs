namespace Infrastructure.Identity
{
    public interface IUserContext
    {
        public string UserId { get; set; }
        public string GetUserId();
    }
}
