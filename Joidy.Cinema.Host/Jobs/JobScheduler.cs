using Hangfire;

namespace Cinema.Host.Jobs
{
    public class JobScheduler
    {
        public static void SetupSchedule()
        {
            var removeUnapprovedReservationJob = nameof(RemoveUnapprovedReservationJob);

            RecurringJob.RemoveIfExists(removeUnapprovedReservationJob);
            RecurringJob.AddOrUpdate<RemoveUnapprovedReservationJob>(removeUnapprovedReservationJob, j => j.Run(default), Cron.Minutely, TimeZoneInfo.Local);
        }
    }
}
