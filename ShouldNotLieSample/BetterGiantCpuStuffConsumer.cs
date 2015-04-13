using System.Threading.Tasks;

namespace ShouldNotLieSample
{
    public class BetterGiantCpuStuffConsumer
    {
        private readonly BetterGiantCpuStuff _betterGiantCpuStuff;

        public BetterGiantCpuStuffConsumer(BetterGiantCpuStuff betterGiantCpuStuff)
        {
            _betterGiantCpuStuff = betterGiantCpuStuff;
        }

        public Task DoStuff()
        {
            // I am the consumer inside the application code.
            // I know what I am doing and I want to offload this work to another thread.
            // Let's do it!

            return Task.Run(() => _betterGiantCpuStuff.DoWork());
        }
    }
}
