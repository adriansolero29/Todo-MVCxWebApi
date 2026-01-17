using Todo.Interfaces.Repositories;

namespace Todo.UseCases.TaskUseCases
{
    public class SetAssignee
    {
        private readonly ITaskInfoRepository taskInfoRepository;

        public SetAssignee(ITaskInfoRepository taskInfoRepository)
        {
            this.taskInfoRepository = taskInfoRepository;
        }

        public async Task ExecuteAsync(long taskId, long memberId)
        {
            var task = await taskInfoRepository.GetById(taskId);
            if (task == null) return;

            task.SetAssignee(memberId);
            await taskInfoRepository.Update(task);
        }
    }
}
