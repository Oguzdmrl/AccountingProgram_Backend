namespace AccountingSolutions.Domain.Abstractions
{
    public abstract class Entity
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}