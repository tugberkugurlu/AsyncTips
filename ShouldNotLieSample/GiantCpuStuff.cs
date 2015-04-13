using System.Threading;
using System.Threading.Tasks;

namespace ShouldNotLieSample
{
    public class GiantCpuStuff
    {
        public Task DoWorkAsync()
        {
            return Task.Run(() =>
            {
                // Giant CPU work here as it must be better not to block to main thread, right?
                // Answer: NO!
            });
        }
    }

    public class BetterGiantCpuStuff
    {
        public void DoWork()
        {
            // Giant CPU work here...

            Thread.Sleep(5000);
        }
    }
}
