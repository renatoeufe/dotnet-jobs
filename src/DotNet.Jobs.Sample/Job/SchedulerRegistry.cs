using FluentScheduler;
using Serilog;
using System;

namespace DotNet.Jobs.Sample.Job
{
    public class SchedulerRegistry : Registry
    {
        public SchedulerRegistry(IWorker worker)
        {
            // https://github.com/fluentscheduler/FluentScheduler
            Schedule(() =>
            {
                try
                {
                    worker.Execute();
                }
                catch (Exception e)
                {
                    Log.Fatal(e, "Execute");
                }
            }).NonReentrant().ToRunNow().AndEvery(5).Seconds();
        }
    }
}