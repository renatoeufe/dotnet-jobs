using DotNet.Jobs.Sample.Job;
using FluentScheduler;
using Serilog;

namespace DotNet.Jobs.Sample
{
    public class Main : Registry
    {
        private readonly SchedulerRegistry _registry;

        public Main(SchedulerRegistry registry)
        {
            _registry = registry;

            // https://github.com/serilog/serilog
            Log.Logger =
                new LoggerConfiguration()
                    .WriteTo.ColoredConsole()
                    //.WriteTo.RollingFile(@"C:\Jobs\Worker-{Date}.txt")
                    .CreateLogger();

            JobManager.JobException += info => { Log.Fatal(info.Exception, "JobManager.JobException"); };
        }

        public void Start()
        {
            Log.Information($"Starting {Constants.JobName}");
            JobManager.Initialize(_registry);
        }

        public void Stop()
        {
            Log.Information($"Stopping {Constants.JobName}");
            JobManager.Stop();
        }
    }
}