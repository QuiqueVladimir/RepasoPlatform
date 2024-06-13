using RepasoPlatdorm.API.Shared.Domain.Repositories;
using RepasoPlatdorm.API.Todo.Domain.Model.Commands;
using RepasoPlatdorm.API.Todo.Domain.Model.Entities;
using RepasoPlatdorm.API.Todo.Domain.Repositories;
using RepasoPlatdorm.API.Todo.Domain.Services;

namespace RepasoPlatdorm.API.Todo.Application.Internal.CommandServices;

public class PlanCommandService(IPlanRepository planRepository, IUnitOfWork unitOfWork) : IPlanCommandService
{
    public async Task<Plan?> Handle(CreatePlanCommand command)
    {
        var plan = new Plan(command);
        try
        {
            await planRepository.AddAsync(plan);
            await unitOfWork.CompleteAsync();
            return plan;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while creating the category: {e.Message}");
            return null;
        }
    }

    public async Task<Plan?> Handle(UpdateCommand command)
    {
        var plan = await planRepository.FindAsync(command.Id);
        if (plan == null)
        {
            Console.WriteLine("Plan not found");
            return null;
        }

        plan.Update(command);
        try
        {
            await unitOfWork.CompleteAsync();
            return plan;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while updating the plan: {e.Message}");
            return null;
        }
    }
    

    public async Task Handle(DeletePlanCommand command)
    {
        var plan = await planRepository.FindAsync(command.Id);
        if (plan == null)
        {
            Console.WriteLine("Plan not found");
            return;
        }

        try
        {
            planRepository.Delete(plan);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while deleting the plan: {e.Message}");
        }
    }
}