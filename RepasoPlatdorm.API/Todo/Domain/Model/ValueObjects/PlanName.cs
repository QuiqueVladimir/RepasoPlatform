namespace RepasoPlatdorm.API.Todo.Domain.Model.ValueObjects;
public record PlanName(string Name)
{
    public PlanName() : this(string.Empty)
    {
    }
    public string FullName => $"{Name}";
}