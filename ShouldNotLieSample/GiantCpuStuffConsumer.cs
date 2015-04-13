using System.Threading.Tasks;

namespace ShouldNotLieSample
{
    public class GiantCpuStuffConsumer
    {
        private readonly GiantCpuStuff _giantCpuStuff;

        public GiantCpuStuffConsumer(GiantCpuStuff giantCpuStuff)
        {
            _giantCpuStuff = giantCpuStuff;
        }

        public Task DoStuff()
        {
            return _giantCpuStuff.DoWorkAsync();
        }
    }
}
