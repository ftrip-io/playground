using ftrip.io.framework.jobs.Attributes;
using ftrip.io.framework.jobs.Contracts.ScheduledJobs;
using System;

namespace ftrip.io.framework_playground.Jobs
{
    [RunOnStartup]
    public class ScheduledJob : IScheduledJob
    {
        public string Name => "Test Scheduled Job";

        public TimeSpan In => TimeSpan.FromSeconds(20);

        public ScheduledJob(IServiceProvider serviceProvider)
        {
        }

        public void Execute()
        {
            Console.WriteLine("Testing Scheduled Job Job");
        }
    }
}