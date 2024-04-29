
namespace Scheduler
{
    public static class RunScheduler
    {
        public static readonly RunManager Manager = new();
        public static List<ISample> Samples { get; private set; } = [];
        public static List<IResource> Resources { get; private set; } = [];
        public static List<ISensor> Sensors { get; private set; } = [];

        public static void SetSamples(List<ISample> samples)
        {
            Samples = samples;
        }

        public static void SetResources(List<IResource> resources)
        {
            Resources = resources;
        }

        public static void SetSensors(List<ISensor> sensors)
        {
            Sensors = sensors;
        }

        public static void Start()
        {
            foreach (var resource in Resources)
            {
                resource.Connect();
            }

            foreach (var sensor in Sensors)
            {
                sensor.Connect();
            }

            Manager.SetResources(Resources);
            Manager.SetSamples(Samples);
            Manager.RunSamples();
        }
    }
}
