using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.ActivityLayer.Services.Interfaces
{
    public interface ITaskCreationService
    {
        bool CreateTask(string taskData, int taskType, string taskName);
    }
}
