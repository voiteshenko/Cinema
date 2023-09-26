using System;
using Hangfire;
using Joidy.Cinema.Host.Jobs;

namespace CyberCube.Rewards.Host.Jobs
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
