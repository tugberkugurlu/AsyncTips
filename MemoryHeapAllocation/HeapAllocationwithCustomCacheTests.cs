using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace MemoryHeapAllocation
{
    /// <summary>
    /// Refer to: https://channel9.msdn.com/Series/Three-Essential-Tips-for-Async/Async-libraries-APIs-should-be-chunky
    /// </summary>
    public class HeapAllocationwithCustomCacheTests
    {
        private static readonly byte[] Data = new byte[0x10000000];
        private const int Iterations = 100;

        [Test]
        public void SuckyMemoryStream_vs_CleverMemoryStream()
        {
            TrackGarbageCollections(new SuckyMemoryStream(Data));
            TrackGarbageCollections(new CleverMemoryStream(Data));
        }

        private void TrackGarbageCollections(Stream stream)
        {
            GC.Collect();

            int gen0 = GC.CollectionCount(0),
                gen1 = GC.CollectionCount(1),
                gen2 = GC.CollectionCount(2);

            for (int i = 0; i < Iterations; i++)
            {
                stream.Position = 0;
                stream.CopyToAsync(Stream.Null).Wait();
            }

            int newGen0 = GC.CollectionCount(0), 
                newGen1 = GC.CollectionCount(1), 
                newGen2 = GC.CollectionCount(2);

            Console.WriteLine("{0}\tGen0:{1}   Gen1:{2}   Gen2:{3}", 
                stream.GetType().Name, 
                newGen0 - gen0, 
                newGen1 - gen1, 
                newGen2 - gen2);
        }
    }

    public class SuckyMemoryStream : MemoryStream
    {
        public SuckyMemoryStream(byte[] data) : base(data)
        {
        }

        public override async Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
        {
            return Read(buffer, offset, count);
        }
    }

    public class CleverMemoryStream : MemoryStream
    {
        private Task<int> _cachedTask;

        public CleverMemoryStream(byte[] data) : base(data)
        {
        }

        public override Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
        {
            int numberOfBytesRead = Read(buffer, offset, count);
            if (_cachedTask == null || _cachedTask.Result != numberOfBytesRead)
            {
                _cachedTask = Task.FromResult(numberOfBytesRead);
            }

            return _cachedTask;
        }
    }
}
