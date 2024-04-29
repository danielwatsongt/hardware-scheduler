using Scheduler;

namespace SchedulerTestImplementation
{
    public class LiquidHandlingWorkUnit : IWorkUnit
    {
        public IResource RequiredResource { get; set; }
        public ISensor? RequiredSensor { get; }
        public int Priority { get; set; }
        private int MinimumTemperature { get; }

        public bool CanRun()
        {
            if (RequiredSensor == null)
            {
                Logger.LogError("No Temperature sensor found for Liquid Handling Work Unit");
                return false;
            }
            
            int temperature = (int)RequiredSensor.GetData();

            if (temperature < MinimumTemperature)
            {
                Logger.LogWarning("Temperature is too low. Required temperature: " + MinimumTemperature + " Current temperature: " + temperature);
                return false;
            }
            
            return true;
        }

        public LiquidHandlingWorkUnit(IResource requiredResource, int priority, ISensor requiredSensor, int minimumTemperature)
        {
            RequiredResource = requiredResource;
            Priority = priority;
            RequiredSensor = requiredSensor;
            MinimumTemperature = minimumTemperature;
        }

    }
}
