using System.Threading.Tasks;

namespace ShouldLieSample
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
