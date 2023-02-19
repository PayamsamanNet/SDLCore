namespace Core.Base
{
    public interface IEntity
    {

    }

    public abstract class BaseEntity<TKey> : IEntity
    {
        public TKey Id { get; set; }
        public DateTime DateOfOperation { get; set; }= DateTime.Now;

    }

    public abstract class BaseEntity : BaseEntity<Guid>
    {

    }
}
