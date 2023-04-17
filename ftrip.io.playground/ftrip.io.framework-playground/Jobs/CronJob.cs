using ftrip.io.framework.jobs.Attributes;
using ftrip.io.framework.jobs.Contracts.ChronJobs;
using System;

namespace ftrip.io.framework_playground.Jobs
{
    [RunOnStartup]
    public class CronJob : ICronJob
    {
        public string Name => "Test Cron Job";

        public string Cron => Hangfire.Cron.Minutely();

        public CronJob(IServiceProvider serviceProvider)
        {
        }

        public void Execute()
        {
            Console.WriteLine("Testing Cron Job on every minute");
        }
    }
}