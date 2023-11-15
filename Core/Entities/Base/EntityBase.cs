namespace MasterAuth.Core.Entities.Base
{
    public abstract class EntityBase : ISqlEntity
    {
        public Guid Id { get; set; }
    }
}
