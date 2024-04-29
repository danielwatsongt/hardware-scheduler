
namespace Scheduler
{
    public interface IResource
    {
        string Name { get; }
        public ResourceStatus Status { get; set; }

        public void Connect();
        public Task PerformWork(ISample sample, CancellationToken token);
    }

    public enum ResourceStatus
    {
        Idle,
        Busy
    }
}
