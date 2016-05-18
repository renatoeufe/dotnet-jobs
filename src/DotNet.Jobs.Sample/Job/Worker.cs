using System;

namespace DotNet.Jobs.Sample.Job
{
    public interface IWorker
    {
        void Execute();
    }

    public class Worker : IWorker
    {
        public void Execute()
        {
            // implement your custom logic here

            Console.WriteLine("test");
        }
    }
}