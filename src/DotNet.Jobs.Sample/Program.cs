using DotNet.Jobs.Sample.Job;
using Topshelf;

namespace DotNet.Jobs.Sample
{
    internal class Program
    {
        public static void Main()
        {
            // para instalar: C:\>DotNet.Jobs.Sample.exe install start
            // https://github.com/Topshelf/Topshelf
            HostFactory.Run(x =>
            {
                x.Service<Main>(s =>
                {
                    s.ConstructUsing(name => new Main(new SchedulerRegistry(new Worker())));
                    s.WhenStarted(m => m.Start());
                    s.WhenStopped(m => m.Stop());
                });
                x.RunAsLocalSystem();

                x.SetDescription(Constants.JobDescription);
                x.SetDisplayName(Constants.JobName);
                x.SetServiceName(Constants.JobName);
                x.StartAutomatically();

                x.EnableServiceRecovery(r =>
                {
                    r.RestartService(1);
                    r.RestartService(2);
                });
            });
        }
    }
}