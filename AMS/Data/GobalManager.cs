using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Data
{
    public static class GobalManager
    {
        private static bool eventsSuspended;
        public static bool EventsSuspended
        {
            get { return eventsSuspended; }
        }

        private static bool controlsSuspended;
        public static bool ControlsSuspended
        {
            get { return controlsSuspended; }
        }

        public static bool SuspendEvents()
        {
            eventsSuspended = true;
            return eventsSuspended;
        }

        public static bool ResumeEvents()
        {
            eventsSuspended = false;
            return eventsSuspended;
        }

        public static bool SuspendControls()
        {
            controlsSuspended = true;
            return controlsSuspended;
        }

        public static bool ResumeControls()
        {
            controlsSuspended = false;
            return controlsSuspended;
        }

        public static event Action UpdateIndexer;
        public static void RaiseUpdateIndexer() => UpdateIndexer?.Invoke();
    }
}
