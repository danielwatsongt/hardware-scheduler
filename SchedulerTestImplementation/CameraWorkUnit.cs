using Scheduler;

namespace SchedulerTestImplementation
{
    public class CameraWorkUnit : IWorkUnit
    {
        public IResource RequiredResource { get; set; }
        public ISensor? RequiredSensor { get; }
        public int Priority { get; set; }


        public bool CanRun()
        {
            return true;
        }

        public CameraWorkUnit(IResource requiredResource, int priority)
        {
            RequiredResource = requiredResource;
            Priority = priority;
        }

    }
}
