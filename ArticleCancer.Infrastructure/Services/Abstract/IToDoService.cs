using ArticleCancer.Application.DTOs.ToDos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleCancer.Infrastructure.Services.Abstract
{
    public interface IToDoService
    {
        Task<List<ToDoDto>> GetAllToDosNonDeletedAsync();
        Task<List<ToDoDto>> GetAllToDosNonDeletedByUserAsync();
        Task<List<ToDoDto>> GetAllCompletedToDosNonDeletedByUserAsync();
        Task<List<ToDoDto>> GetAllNonCompletedToDosNonDeletedByUserAsync();
        Task<List<ToDoDto>> GetAllToDosNonDeletedTake24();
        Task<List<ToDoDto>> GetAllToDosDeleted();
        Task<List<ToDoDto>> GetAllToDosDeletedByUserAsync();
        Task CreateToDoAsync(ToDoAddDto toDoAddDto);
        Task<ToDoDto> GetToDoByID(Guid toDoId);
        Task<string> ChangeStatusCompletedAsync(Guid toDoId);
        Task<string> ChangeStatusNonCompletedAsync(Guid toDoId);
        Task<string> UpdateToDoAsync(ToDoUpdateDto toDoUpdateDto);
        Task<string> SafeDeleteToDoAsync(Guid todoId);
        Task<string> UndoDeleteToDoAsync(Guid todoId);
    }
}
