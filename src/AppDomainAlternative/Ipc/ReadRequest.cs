using System;
using System.Threading;
using System.Threading.Tasks;

namespace AppDomainAlternative.Ipc;

internal class ReadRequest : TaskCompletionSource<int>, IAsyncResult
{
    WaitHandle IAsyncResult.AsyncWaitHandle => ((IAsyncResult)Task).AsyncWaitHandle;
    bool IAsyncResult.CompletedSynchronously => ((IAsyncResult)Task).CompletedSynchronously;
    bool IAsyncResult.IsCompleted => Task.IsCompleted;
    object IAsyncResult.AsyncState => Task.AsyncState;

    public ReadRequest(long id, ArraySegment<byte> buffer, AsyncCallback callback, object state)
        : base(state)
    {
        if (callback != null)
        {
            Task.ContinueWith(_ => callback(this));
        }
        Buffer = buffer;
        Id = id;
    }
    public ArraySegment<byte> Buffer { get; }
    public long Id { get; }
    public int ReadBytes { get; set; }
}