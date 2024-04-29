using Scheduler;

namespace SchedulerTestImplementation;

class Program
{
    static void Main(string[] args)
    {
        List<ISample> samples = [];

        IResource camera1 = new Camera1();
        IResource camera2 = new Camera2();
        IResource liquidDispenser = new LiquidDispenser();
        ISensor heatSensor = new HeatSensor();

        for (int i = 0; i < 10; i++)
        {
            samples.Add(new Sample("Sample " + (i + 1), [ 
                new CameraWorkUnit(camera1, 5), 
                new LiquidHandlingWorkUnit(liquidDispenser, 4, heatSensor, 50), 
                new CameraWorkUnit(camera2, 3), 
                new LiquidHandlingWorkUnit(liquidDispenser, 1, heatSensor, 80), 
                new CameraWorkUnit(camera1, 1) 
            ]));
        }

        RunScheduler.SetResources(new List<IResource> { camera1, camera2, liquidDispenser });
        RunScheduler.SetSensors(new List<ISensor> { heatSensor });
        RunScheduler.SetSamples(samples);
        RunScheduler.Start();

        Console.ReadLine();
    }
}