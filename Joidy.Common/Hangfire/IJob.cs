namespace Joidy.Common.Hangfire
{
    public interface IJob
    {
        Task Run(CancellationToken cancellationToken = default);
    }

    public interface IJob<in T>
        where T : IJobArgs
    {
        Task Run(T data, CancellationToken cancellationToken = default);
    }
}
