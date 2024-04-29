using System.Collections.Generic;

namespace Scheduler
{
    public class RunManager
    {
        public List<IResource> Resources { get; private set; } = [];
        public List<ISample> Samples { get; private set; } = [];

        private CancellationTokenSource tokenSource = new CancellationTokenSource();
        private List<Task> tasks = new();
        
        public void SetSamples(List<ISample> samples)
        {
            Samples = samples;
        }

        public void SetResources(List<IResource> resources)
        {
            Resources = resources;
        }

        public void RunSamples()
        {
            while (Samples.Any(s => s.Status != SampleStatus.Complete))
            {
                foreach (var resource in Resources)
                {
                    if (resource.Status == ResourceStatus.Busy) continue;

                    var idleSamples = Samples.Where(s => s.Status == SampleStatus.Idle 
                                                    && s.CurrentWork.RequiredResource == resource 
                                                    && s.CurrentWork.CanRun() == true)
                                                    .ToList();

                    if (idleSamples.Count == 0) continue;

                    var sample = idleSamples.MaxBy(p => p.CurrentWork.Priority);
                    if (sample == null) continue;

                    resource.Status = ResourceStatus.Busy;

                    Task task = Task.Run(() => resource.PerformWork(sample, tokenSource.Token), tokenSource.Token);
                    tasks.Add(task);
                }
            }

            Logger.LogMessage("All samples are complete");
        }
    }
}
