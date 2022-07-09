namespace DataAccess.Entities
{
    public class BaseModel
    {
        public long Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? UpdatedOn { get; set; }
    }
}
