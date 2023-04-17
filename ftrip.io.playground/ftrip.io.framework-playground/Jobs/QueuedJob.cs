using ftrip.io.framework.jobs.Attributes;
using ftrip.io.framework.jobs.Contracts.QueuedJobs;
using System;
using System.Threading.Tasks;

namespace ftrip.io.framework_playground.Jobs
{
    [RunOnStartup(Should = false)]
    public class QueuedJob : IAsyncQueuedJob
    {
        public string Name => "Test Queued Job";

        public QueuedJob(IServiceProvider serviceProvider)
        {
        }

        public async Task Execute()
        {
            Console.WriteLine("Testing Queued Job");
            await Task.CompletedTask;
        }
    }
}