using Todo.Entities;
using Todo.Interfaces.Repositories;

namespace Todo.UseCases.SubTaskUseCases
{
    public class CreateSubTask
    {
        private readonly ISubTaskInfoRepository subTaskInfoRepository;
        private readonly ITaskInfoRepository taskInfoRepository;

        public CreateSubTask(ISubTaskInfoRepository subTaskInfoRepository, ITaskInfoRepository taskInfoRepository)
        {
            this.subTaskInfoRepository = subTaskInfoRepository;
            this.taskInfoRepository = taskInfoRepository;
        }

        public async Task ExecuteAsync(long taskId, string name)
        {
            try
            {
                var task = await taskInfoRepository.GetById(taskId);
                if (task == null)
                {
                    // no task found
                    return;
                }

                var toAdd = new SubTaskInfo(task.Id, name);
                task.AddSubTask(toAdd);

                await taskInfoRepository.Update(task);
            }
            catch (Exception ex)
            {
                throw new Exception("Use case error: " + ex.Message);
            }
        }
    }
}
