namespace Scheduler
{
    public interface IScheduler<T>
    {
        void SendMessage(T value);
    }
}