using System;
using System.Diagnostics;
using Traveller.Core.Providers;

namespace Traveller.Core
{
    public class DecoratedEngine : IEngine
    {
        private readonly IEngine engine;
        private readonly IWriter writer;

        public DecoratedEngine(IEngine engine, IWriter writer)
        {
            this.engine = engine ?? throw new ArgumentNullException();
            this.writer = writer ?? throw new ArgumentNullException();
        }

        public void Start()
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            this.writer.Write("The Engine is starting...\n");
            
            engine.Start();

            timer.Stop();
            this.writer.Write(string.Format("The Engine worked for {0} milliseconds.\n",timer.ElapsedMilliseconds));
        }
    }
}