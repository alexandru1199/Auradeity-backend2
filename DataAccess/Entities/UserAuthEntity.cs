namespace DataAccess.Entities
{
    public class UserAuthEntity : BaseModel
    {
        public string Email { get; set; }

        public byte[] KeyPassword { get; set; }

        public byte[] HashPassword { get; set; }
    }
}
