using System;
using System.IO;

namespace AsyncProgrammingModels
{
    public class ApmSample
    {
        static readonly byte[] Buffer = new byte[100];

        static void Main(string[] args)
        {
            const string filePath = @"C:\Apps\Foo.txt";

            FileStream fileStream = new FileStream(filePath,
                FileMode.Open, FileAccess.Read, FileShare.Read, 1024,
                FileOptions.Asynchronous);

            IAsyncResult result = fileStream.BeginRead(Buffer, 0, Buffer.Length,
                    new AsyncCallback(CompleteRead), fileStream);
        }

        static void CompleteRead(IAsyncResult result)
        {
            Console.WriteLine("Read Completed");
            FileStream strm = (FileStream)result.AsyncState;
            int numBytes = strm.EndRead(result);
            strm.Close();

            Console.WriteLine("Read {0} Bytes", numBytes);
            Console.WriteLine(BitConverter.ToString(Buffer));
        }
    }
}
