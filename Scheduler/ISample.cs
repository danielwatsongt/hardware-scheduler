
namespace Scheduler
{
    public interface ISample
    {
        public string Name { get; }
        public SampleStatus Status { get; set; }
        public List<IWorkUnit> Work { get; }
        public IWorkUnit CurrentWork { get; }

        public void CompleteWork();
    }

    public enum SampleStatus
    {
        Idle,
        Busy,
        Complete
    }
}
