using Hangfire;

namespace Joidy.Common.Hangfire
{
    public abstract class RecurringJobBase : IJob
    {
        [AutomaticRetry(Attempts = 0, OnAttemptsExceeded = AttemptsExceededAction.Delete)]
        [DisableConcurrentExecution(10 * 60)]
        public abstract Task Run(CancellationToken cancellationToken = default);
    }
}
