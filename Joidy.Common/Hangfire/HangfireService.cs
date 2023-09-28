using Hangfire;

namespace Common.Hangfire
{
    public class HangfireService : IHangfireService
    {
        public bool Delete(string jobId)
        {
            return BackgroundJob.Delete(jobId);
        }

        public string Enqueue<T>(CancellationToken cancellationToken = default)
            where T : IJob
        {
            return BackgroundJob.Enqueue<T>(j => j.Run(cancellationToken));
        }

        public string Enqueue<T, TA>(TA args, CancellationToken cancellationToken = default)
            where T : IJob<TA>
            where TA : IJobArgs
        {
            return BackgroundJob.Enqueue<T>(j => j.Run(args, cancellationToken));
        }

        public string Schedule<T>(TimeSpan delay, CancellationToken cancellationToken = default)
            where T : IJob
        {
            return BackgroundJob.Schedule<T>(j => j.Run(cancellationToken), delay);
        }

        public string Schedule<T, TA>(TA args, TimeSpan delay, CancellationToken cancellationToken = default)
            where T : IJob<TA>
            where TA : IJobArgs
        {
            return BackgroundJob.Schedule<T>(j => j.Run(args, cancellationToken), delay);
        }
    }
}
