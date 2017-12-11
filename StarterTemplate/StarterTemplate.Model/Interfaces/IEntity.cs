namespace StarterTemplate.Model
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}
