using RepasoPlatdorm.API.Todo.Domain.Model.Commands;
using RepasoPlatdorm.API.Todo.Domain.Model.ValueObjects;

namespace RepasoPlatdorm.API.Todo.Domain.Model.Entities;

public class Plan
{
    public int Id { get; private set; }
    public PlanName Name { get; private set; }
    public int MaxUsers { get; private set; }
    public int IsDefault { get; private set; }

    public Plan(CreatePlanCommand command) : this(command.Name, command.MaxUsers, command.IsDefault)
    {
    }
    
    public void Update(UpdateCommand command)
    {
        Id = command.Id;
        Name = command.Name;
        MaxUsers = command.MaxUsers;
        IsDefault = command.IsDefault;
    }
    
    public Plan(PlanName name, int maxUsers, int isDefault)
    {
        if (maxUsers <= 0)
        {
            throw new ArgumentException("MaxUsers must be greater than zero", nameof(maxUsers));
        }

        if (isDefault != 0 && isDefault != 1)
        {
            throw new ArgumentException("IsDefault must be either 0 or 1", nameof(isDefault));
        }

        Name = name;
        MaxUsers = maxUsers;
        IsDefault = isDefault;
    }
    
}
