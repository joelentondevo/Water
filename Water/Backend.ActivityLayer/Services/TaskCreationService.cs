using Backend.ActivityLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.ActivityLayer.Services
{
    public class TaskCreationService : ITaskCreationService
    {
        public TaskCreationService() { }

        public bool CreateTask(string taskData, int taskType,  string taskName) { return false; }
    }
}
