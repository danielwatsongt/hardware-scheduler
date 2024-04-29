
namespace Scheduler
{
    public interface IWorkUnit
    {
        public IResource RequiredResource { get; }
        public ISensor? RequiredSensor { get; }
        public int Priority { get; set; }

        public bool CanRun();
    }

}
