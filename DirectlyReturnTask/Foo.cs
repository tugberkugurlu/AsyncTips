using System.Threading.Tasks;

namespace DirectlyReturnTask
{
    public class Bar
    {
    }

    public interface IBar
    {
        Task<Bar> GetBarAsync(string id);
    }

    public class FooWrong
    {
        private const string FooBar = "foobar";
        private readonly IBar _bar;

        public FooWrong(IBar bar)
        {
            _bar = bar;
        }

        public async Task<Bar> GetBarsAsync()
        {
            Bar bar = await _bar.GetBarAsync(FooBar);
            return bar;
        }
    }

    public class FooCorrect
    {
        private const string FooBar = "foobar";
        private readonly IBar _bar;

        public FooCorrect(IBar bar)
        {
            _bar = bar;
        }

        public Task<Bar> GetBarsAsync()
        {
            return _bar.GetBarAsync(FooBar);
        }
    }
}
