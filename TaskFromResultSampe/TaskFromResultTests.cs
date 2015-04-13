using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskFromResultSampe
{
    public class TaskFromResultTests
    {
    }

    public class File
    {
        public File(string id, string name)
        {
            Id = id;
            Name = name;
        }

        public string Id { get; private set; }
        public string Name { get; private set; }
    }

    public interface IFileManager
    {
        Task<IEnumerable<File>> GetFilesAsync();
    }

    public class WorstInMemoryFileManager : IFileManager
    {
        private readonly IEnumerable<File> _files = new List<File> { /* ... */ };

        public Task<IEnumerable<File>> GetFilesAsync()
        {
            return Task<IEnumerable<File>>.Factory.StartNew(() => _files);
        }
    }

    public class SuckyInMemoryFileManager : IFileManager
    {
        private readonly IEnumerable<File> _files = new List<File> { /* ... */ };

        public async Task<IEnumerable<File>> GetFilesAsync()
        {
            return _files;
        }
    }

    public class InMemoryFileManagerWithTcs : IFileManager
    {
        private readonly IEnumerable<File> _files = new List<File> { /* ... */ };

        public Task<IEnumerable<File>> GetFilesAsync()
        {
            var tcs = new TaskCompletionSource<IEnumerable<File>>();
            tcs.SetResult(_files);

            return tcs.Task;
        }
    }

    public class InMemoryFileManager : IFileManager
    {
        private readonly IEnumerable<File> _files = new List<File> { /* ... */ };

        public async Task<IEnumerable<File>> GetFilesAsync()
        {
            return await Task.FromResult(_files);
        }
    }
}