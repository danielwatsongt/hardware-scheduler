
namespace Scheduler
{
    public interface ISensor
    {
        public void Connect();

        public object GetData();
    }
}
