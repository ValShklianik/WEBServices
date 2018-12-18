namespace Scheduler
{
    public interface IScheduler<T>
    {
        long SendMessage(T value);
    }
}