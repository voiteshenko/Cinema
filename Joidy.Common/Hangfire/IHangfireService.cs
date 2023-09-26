namespace Joidy.Common.Hangfire
{
    public interface IHangfireService
    {
        bool Delete(string jobId);

        string Enqueue<T>(CancellationToken cancellationToken = default)
           where T : IJob;

        string Enqueue<T, TA>(TA args, CancellationToken cancellationToken = default)
            where T : IJob<TA>
            where TA : IJobArgs;

        string Schedule<T>(TimeSpan delay, CancellationToken cancellationToken = default)
            where T : IJob;

        string Schedule<T, TA>(TA args, TimeSpan delay, CancellationToken cancellationToken = default)
            where T : IJob<TA>
            where TA : IJobArgs;
    }
}