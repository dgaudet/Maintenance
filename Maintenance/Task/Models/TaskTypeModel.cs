using Maintenance.Models;

namespace Maintenance.Task.Models
{
    public class TaskTypeModel
    {
        private TaskType _taskType;
        public TaskType Type { get { return _taskType; } }

        public string Description { get { return _taskType.GetDescription(); } }

        public TaskTypeModel(TaskType type)
        {
            _taskType = type;
        }
    }
}