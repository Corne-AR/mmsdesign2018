using AMS.Data;
using AMS.Data.People;
using AMS.Data.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS
{
    public static class aDMS
    {
        private static DataManager<aPerson> peopleManager;
        public static DataManager<aPerson> PeopleManager
        {
            get
            {
                if (peopleManager == null) peopleManager = new DataManager<aPerson>(DataType.Person);
                return peopleManager;
            }
        }

        private static DataManager<aClient> clientManager;
        public static DataManager<aClient> ClientManager
        {
            get
            {
                if (clientManager == null) clientManager = new DataManager<aClient>(DataType.Client);
                return clientManager;
            }
        }

        private static DataManager<aTask> taskManager;
        public static DataManager<aTask> TaskManager
        {
            get
            {
                if (taskManager == null) taskManager = new DataManager<aTask>(DataType.Task);
                return taskManager;
            }
        }

        private static DataManager<aTaskItem> tasItemkManager;
        public static DataManager<aTaskItem> TaskItemManager
        {
            get
            {
                if (tasItemkManager == null) tasItemkManager = new DataManager<aTaskItem>(DataType.TaskItem);
                return tasItemkManager;
            }
        }
    }
}