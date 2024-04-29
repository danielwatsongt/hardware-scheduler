using Scheduler;

namespace SchedulerTestImplementation
{
    public class Sample(string name, List<IWorkUnit> work) : ISample
    {
        public string Name { get; set; } = name;
        public SampleStatus Status { get; set; } = SampleStatus.Idle;

        public List<IWorkUnit> Work { get; set; } = work;

        public IWorkUnit CurrentWork
        {
            get => Work[currentWorkCount];
        }

        public void CompleteWork()
        {
            currentWorkCount++;
            if (currentWorkCount == Work.Count)
            {
                Status = SampleStatus.Complete;
                Logger.LogMessage(string.Format("{0} is complete", Name));
            }
            else
            {
                Status = SampleStatus.Idle;
            }
        }

        private int currentWorkCount = 0;
    }
}
