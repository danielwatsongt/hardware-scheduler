﻿using Scheduler;

namespace SchedulerTestImplementation
{
    public class Camera2 : IResource
    {
        public string Name { get; } = "Camera 2";

        public ResourceStatus Status { get; set; } = ResourceStatus.Idle;

        public void Connect()
        {
            Thread.Sleep(1000);
            Logger.LogMessage(string.Format("Connected to {0}", Name));
        }

        public async Task PerformWork(ISample sample, CancellationToken token)
        {
            Logger.LogMessage(string.Format("{0} beginning work on {1}", Name, sample.Name));
            sample.Status = SampleStatus.Busy;

            Random rnd = new Random();
            int randomTimer = rnd.Next(6) + 3;

            for (int i = 0; i < randomTimer; i++)
            {
                if (token.IsCancellationRequested)
                {
                    Logger.LogError(string.Format("{0} was cancelled while working on {1}", Name, sample.Name));
                    return;
                }

                Thread.Sleep(1000);
            }

            Logger.LogMessage(string.Format("{0} finishing work on {1}", Name, sample.Name));
            sample.CompleteWork();
            Status = ResourceStatus.Idle;
        }
    }
}
