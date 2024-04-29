using Scheduler;

namespace SchedulerTestImplementation
{
    public class HeatSensor : ISensor
    {
        public string Name { get; set; } = "Heat Sensor";
        public int Temperature { get; private set; }
        public void Connect()
        {
            Thread.Sleep(1000);
            Logger.LogMessage(string.Format("Connected to {0}", Name));
        }

        public object GetData()
        {
            Temperature = new Random().Next(100);
            return Temperature;
        }
    }
}
